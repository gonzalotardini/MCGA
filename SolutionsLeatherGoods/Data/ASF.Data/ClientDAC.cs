using ASF.Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Data
{
    public class ClientDAC :DataAccessComponent
    {
        public List<Client> Select()
        {
            
            const string sqlStatement = "select id, FirstName, LastName,Email, CountryId as 'Pais',AspNetUsers as 'User', City, SignupDate, Rowid, OrderCount, CreatedOn, CreatedBy,ChangedOn,ChangedBy from client";

            var result = new List<Client>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var client = LoadClient(dr); // Mapper
                        result.Add(client);
                    }
                }
            }

            return result;
        }

        private static Client LoadClient(IDataReader dr)
        {
            var client = new Client
            {
                Id = GetDataValue<int>(dr, "Id"),
                FirstName = GetDataValue<string>(dr, "FirstName"),
                CountryId = GetDataValue<int>(dr, "Pais"),
                Email = GetDataValue<string>(dr, "Email"),
                AspNetUsers = GetDataValue<string>(dr, "User"),
                City = GetDataValue<string>(dr, "City"),
                SignupDate = GetDataValue<DateTime>(dr, "SignupDate"),
                Rowid = GetDataValue<Guid>(dr, "RowId"),
                OrderCount = GetDataValue<int>(dr, "OrderCount"),                
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return client;
        }
    }
}
