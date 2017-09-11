using ASF.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ASF.Services.Http
{
    [RoutePrefix("rest/Client")]
    public class ClientService :ApiController
    {
        [HttpGet]
        [Route("All")]
        public AllResponse All()
        {
            try
            {
                var response = new AllResponse();
                var bclient = new ClientBussiness();
                response.ResultClient = bclient.All();
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }
    }
}
