using InventoryDAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace InventoryMVC.Controllers
{
    public class ArticlesController : Controller
    {
        private Uri _baseUrlArticle = new Uri("http://localhost:51634/api/services/articles");
        private Uri _baseUrlStore = new Uri("http://localhost:51634/api/services/stores");
        // GET: Articles
        public async Task<ActionResult> Index()
        {
            ArticleJSONResponse responseArticle = null;
         

            var client = new HttpClient();
            try
            {
                var response = await client.GetAsync(_baseUrlArticle);
                if (response.IsSuccessStatusCode)
                {
                    responseArticle = JsonConvert.DeserializeObject<ArticleJSONResponse>(await response.Content.ReadAsStringAsync());
                    if (responseArticle.success)
                    {
                        return View(responseArticle.articles.ToList());
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return HttpNotFound();
        }
    }
}