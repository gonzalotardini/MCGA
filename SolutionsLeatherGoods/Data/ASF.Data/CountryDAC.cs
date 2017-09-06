using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ASF.Data
{
    public class CountryDAC:DataAccessComponent
    {
        public List<Country> All()
        {

            const string sqlStatement = "SELECT [Id], [Name], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Country order by Name ";

            var result = new List<Country>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var country = LoadCountry(dr); // Mapper
                        result.Add(country);
                    }
                }
            }

            return result;

        }

        public Country Create(Country country)
        {
            const string sqlStatement = "INSERT INTO dbo.Country ([Name], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]) " +
               "VALUES(@Name, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Name", DbType.String, country.Name);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, country.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, country.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, country.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, country.ChangedBy);
                // Obtener el valor de la primary key.
                country.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return country;

        }

        private static  Country LoadCountry(IDataReader dr)
        {
            var country = new Country
            {
                Id = GetDataValue<int>(dr, "Id"),
                Name = GetDataValue<string>(dr, "Name"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return country;
        }

        
    }
}
