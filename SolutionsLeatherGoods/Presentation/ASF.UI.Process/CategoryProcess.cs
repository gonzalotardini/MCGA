using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using ASF.Entities;
using ASF.Services.Contracts;
using ASF.UI.Process;

namespace ASF.UI.Process
{
    public class CategoryProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Category> SelectList()
        {
            var response = HttpGet<AllResponse>("rest/Category/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public void Create(Category Category)
        {
            var response = HttpPost<Category>("rest/Category/Add",Category, MediaType.Json);


        }

        public void Edit(Category category)
        {
            var response = HttpGet<Category>("rest/Category/Find/"+ category.Id, MediaType.Json);
        }
    }
}