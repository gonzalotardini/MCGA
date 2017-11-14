using ASF.Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Data.DbContext;


namespace ASF.Data
{
    public class ClientDAC :DataAccessComponent
    {
        public List<ASF.Entities.Client> Select2()
        {

            const string sqlStatement = "select id, FirstName, LastName,Email, CountryId as 'Pais',AspNetUsers as 'User', City, SignupDate, Rowid, OrderCount, CreatedOn, CreatedBy,ChangedOn,ChangedBy from client";

            var result = new List<Entities.Client>();
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

        public List<DbContext.Client> Select()
        {
            //List<Entities.Client> ListaClient = new List<Entities.Client>();
            var modelo = new LeatherGoodsEntities();
            var lista = new List<DbContext.Client>();

            lista= modelo.Client.ToList();
            //ListaClient = Mapper(lista);

            return lista;
           
        }
        
        private static List<Entities.Client> Mapper( List<DbContext.Client> listaRecibida)
        {
            Entities.Client Client;
            List<Entities.Client> listaDevuelta = new List<Entities.Client>();

          

            foreach (DbContext.Client item in listaRecibida)
            {
                Client = new Entities.Client();

                Client.AspNetUsers= item.AspNetUsers;
                Client.ChangedBy= item.ChangedBy;
                Client.ChangedOn = Convert.ToDateTime(item.ChangedOn);
                Client.City = item.City;
                Client.CountryId = Convert.ToInt32(item.CountryId);                
                Client.CreatedBy = item.CreatedBy;
                Client.CreatedOn = Convert.ToDateTime(item.CreatedOn);
                Client.Email = item.Email;
                Client.FirstName = item.FirstName;
                Client.Id = item.Id;
                Client.LastName= item.LastName;
                Client.OrderCount = Convert.ToInt32(item.OrderCount);
                //Client.Rowid = item.Rowid;
                Client.SignupDate= Convert.ToDateTime(item.SignupDate);

                listaDevuelta.Add(Client);
            }

            return listaDevuelta;
        }

        private static Entities.Client LoadClient(IDataReader dr)
        {
            var client = new Entities.Client
            {
                Id = GetDataValue<int>(dr, "Id"),
                FirstName = GetDataValue<string>(dr, "FirstName"),
                LastName = GetDataValue<string>(dr, "LastName"),
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
