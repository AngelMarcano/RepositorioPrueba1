using InventoryDAL.Models;
using InventoryDAL.Repos;
using InventoryWebAPI.App_Start;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using static InventoryWebAPI.FilterConfig;

namespace InventoryWebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:51634", headers: "*", methods: "*")]
    [AllowCrossSiteJsonAttribute ]
    [RoutePrefix("api/services/stores")]
    public class StoresController : ApiController
    {
        private readonly StoreRepo _repo = new StoreRepo();


        [HttpGet, Route("")]
        public StoreJSONResponse Get()
        {
            StoreJSONResponse response = new StoreJSONResponse();

            try
            {
                var stores = _repo.GetAll();
                response.stores = _repo.GetAll().ToArray();
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
        [HttpGet, Route("{id}", Name = "DisplayRoute")]
        [ResponseType(typeof(table_stores))]
        public IHttpActionResult Get(int id)
        {
            StoreJSONResponse response = new StoreJSONResponse();
            table_stores[] table_storeTemp = new table_stores[1];
            table_stores store = _repo.GetOne(id);
            if (store == null)
            {
                return Ok(new JSONErrorResponse() { error_code = 404, error_msg = "Record not found", success = false });
            }
            table_storeTemp[0] = store;
            response.stores = table_storeTemp;
            response.success = true;
            response.total_elements = 1;
            
            return Ok(response);
        }
        
        // PUT: api/Stores/5
        [HttpPut, Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, table_stores store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != store.Id)
            {
                return BadRequest();
            }
            try
            {
                _repo.Save(store);
            }
            catch (Exception ex)
            {
                
                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Stores
        [HttpPost, Route("", Name = "CreateRoute")]
        [ResponseType(typeof(table_stores))]
        public IHttpActionResult Post(table_stores store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _repo.Add(store);
            }
            catch (Exception ex)
            {
                
                throw;
            }
            return CreatedAtRoute("DisplayRoute", new { id = store.Id }, store);
        }

        // DELETE: api/Inventory/5
        [HttpDelete, Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id, table_stores store)
        {
            if (id != store.Id)
            {
                return BadRequest();
            }
            try
            {
                _repo.Delete(store);
            }
            catch (Exception ex)
            {
                
                throw;
            }
            return Ok();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
