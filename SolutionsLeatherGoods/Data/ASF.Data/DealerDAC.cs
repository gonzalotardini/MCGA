using ASF.Data.DbContext;
using ASF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ASF.Data
{
   public class DealerDAC : DataAccessComponent
    {
        public List<Entities.Dealer> SelectAll()
        {
            var Context = new LeatherGoodsEntities();
            var listaDealers = Context.Dealer.ToList();
            var ListaDevuelta = new List<Entities.Dealer>();

            ListaDevuelta = MapperDealer(listaDealers);
            return ListaDevuelta;
        }

        private List<Entities.Dealer> MapperDealer (List<DbContext.Dealer> ListaRecibida)
        {
            List<Entities.Dealer> ListaDealer = new List<Entities.Dealer>();

            foreach (DbContext.Dealer i in ListaRecibida)
            {
                var Dealer = new Entities.Dealer();

                Dealer.CategoryId = i.CategoryId;
                Dealer.ChangedBy = i.ChangedBy;
                Dealer.ChangedOn = i.ChangedOn;
                Dealer.CountryId = i.CountryId;
                Dealer.CreatedBy = i.CreatedBy;
                Dealer.CreatedOn = i.CreatedOn;
                Dealer.Description = i.Description;
                Dealer.FirstName = i.FirstName;
                Dealer.Id = i.Id;
                //Dealer.Rowid = i.Rowid;
                Dealer.TotalProducts = i.TotalProducts;

                ListaDealer.Add(Dealer);                    
            }

            return ListaDealer;
        }
    }
}
