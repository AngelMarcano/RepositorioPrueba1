using InventoryDAL.Models;
using InventoryDAL.Repos;
using InventoryWebAPI.App_Start;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Script.Serialization;
using static InventoryWebAPI.FilterConfig;

namespace InventoryWebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:51634", headers: "*", methods: "*")]
    [RoutePrefix("api/services/articles")]
    [AllowCrossSiteJsonAttribute]
    public class ArticlesController : ApiController
    {
        private readonly ArticleRepo _repo = new ArticleRepo();
        

        [HttpGet, Route("")]

        public ArticleJSONResponse Get()
        {
            ArticleJSONResponse response = new ArticleJSONResponse();

            try
            {
                var article = _repo.GetAll();
                response.articles = _repo.GetAll().ToArray();
                response.success = true;
                response.total_elements = _repo.GetAll().Count;

            }
            catch (Exception)
            {
                response.success = false;
            }
            return response;
        }

        // GET: api/Stores/5
        [HttpGet, Route("store/{id}", Name = "DisplayRoute2")]
        [ResponseType(typeof(ArticleJSONResponse))]
        public IHttpActionResult Get(int id)
        {
            ArticleJSONResponse response = new ArticleJSONResponse();
           
            table_articles[] articles = _repo.GetAll().Where(x=> x.store_id == id).ToArray();
            if (articles == null)
            {
                return Ok(new JSONErrorResponse() { error_code = 404, error_msg = "Record not found", success = false });
            }
           
            response.articles = articles;
            response.success = true;
            response.total_elements = articles.Length;

            return Ok(response);
        }
    }
}
