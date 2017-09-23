using ASF.Data;
using ASF.Entities;
using System.Collections.Generic;


namespace ASF.Services.Http
{
  public class ClientBussiness
    {
        public List<Client> All()
        {
            var clientDac = new ClientDAC();
            var result = clientDac.Select();
            return result;
        }

    }
    
}