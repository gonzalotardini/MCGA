using ASF.Entities;
using ASF.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.UI.Process
{
    public class DelaerProcess : ProcessComponent
    {
        public List<Dealer> SelectAll()
        {
            var response = HttpGet<AllResponse>("rest/Dealer/All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultDealer;
        }
    }
}
