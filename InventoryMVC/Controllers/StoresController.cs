using InventoryDAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace InventoryMVC.Controllers
{
    public class StoresController : Controller
    {
      
        private Uri _baseUrl = new Uri("http://localhost:51634/api/services/stores");
        private Uri _baseUrlArticles = new Uri("http://localhost:51634/api/services/articles/store/");


        // GET: Stores
        public async Task<ActionResult> Index()
        {
            StoreJSONResponse responseStore = null;
            var client = new HttpClient();
            try
            {
                var response = await client.GetAsync(_baseUrl);
                if (response.IsSuccessStatusCode)
                {
                    responseStore = JsonConvert.DeserializeObject<StoreJSONResponse>(await response.Content.ReadAsStringAsync());
                    if (responseStore.success)
                    {
                        return View(responseStore.stores.ToList());
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return HttpNotFound();
        }

        // GET: Store/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            StoreJSONResponse responseStore = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = new HttpClient();
            var response = await client.GetAsync($"{_baseUrl}/{id.Value}");
            if (response.IsSuccessStatusCode)
            {
                responseStore = JsonConvert.DeserializeObject<StoreJSONResponse>(await response.Content.ReadAsStringAsync());
                return View(responseStore.stores.ToList().FirstOrDefault());
            }
            return HttpNotFound();
        }


        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "name,address")] table_stores store)
        {
            if (!ModelState.IsValid) return View(store);
            try
            {
                var client = new HttpClient();
                string json = JsonConvert.SerializeObject(store);
                var response = await client.PostAsync(_baseUrl, new StringContent(json, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Unable to create record: {ex.Message}");
            }
            return View(store);
        }

        // GET: Store/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            StoreJSONResponse responseStore = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = new HttpClient();
            var response = await client.GetAsync($"{_baseUrl}/{id.Value}");
            if (response.IsSuccessStatusCode)
            {
                 responseStore = JsonConvert.DeserializeObject<StoreJSONResponse>(await response.Content.ReadAsStringAsync());
                return View(responseStore.stores.ToList().FirstOrDefault());
            }
            return new HttpNotFoundResult();
        }
        // POST: Store/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,name,address")] table_stores store)
        {
            if (!ModelState.IsValid) return View(store);
            var client = new HttpClient();
            string json = JsonConvert.SerializeObject(store);
            var response = await client.PutAsync($"{_baseUrl}/{store.Id}", new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(store);
        }



        // GET: Store/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = new HttpClient();
            var response = await client.GetAsync($"{_baseUrl}/{id.Value}");
            if (response.IsSuccessStatusCode)
            {
                var store = JsonConvert.DeserializeObject<StoreJSONResponse>(await response.Content.ReadAsStringAsync());
                return View(store.stores.FirstOrDefault());
            }
            return new HttpNotFoundResult();
        }

        // POST: Store/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete([Bind(Include = "Id")] table_stores store)
        {
            try
            {
                var client = new HttpClient();

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, $"{_baseUrl}/{store.Id}")
                {
                    Content = new StringContent(JsonConvert.SerializeObject(store), Encoding.UTF8, "application/json")
                };
                var s = int.Parse("12a");
                var response = await client.SendAsync(request);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Unable to create record: {ex.Message}");
            }

           
            return HttpNotFound();

        }

        //Implementar un método para obtener los artículos de una tienda en particular

        // GET: articles/Store/5
        public async Task<ActionResult> Articles(int? id)
        {

            ArticleJSONResponse responseStore = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = new HttpClient();
            var response = await client.GetAsync($"{_baseUrlArticles}/{id.Value}");
            if (response.IsSuccessStatusCode)
            {
                responseStore = JsonConvert.DeserializeObject<ArticleJSONResponse>(await response.Content.ReadAsStringAsync());
                return View(responseStore.articles.ToList());
            }
            return HttpNotFound();
        }




    }
}