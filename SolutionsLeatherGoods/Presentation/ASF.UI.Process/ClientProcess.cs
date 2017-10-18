using ASF.Entities;
using ASF.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.UI.Process
{
  public class ClientProcess :ProcessComponent
    {
        public List<Data.DbContext.Client> SelectList()
        {
            var response = HttpGet<AllResponse>("rest/Client/All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultClient;
        }
    }
}
