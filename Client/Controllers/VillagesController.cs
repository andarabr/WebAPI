using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using BootcampManagement.Client.ViewModels;
using DataAccess.Models;
using Newtonsoft.Json;

namespace Client.Controllers
{
    public class VillagesController : Controller
    {
        // GET: Villages
        public ActionResult Index()
        {
            return View(LoadVillage());
        }

        public JsonResult LoadVillage()
        {
            IEnumerable<Village> village = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var responseTask = client.GetAsync("Villages");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Village>>();
                readTask.Wait();
                village = readTask.Result;
            }
            else
            {
                village = Enumerable.Empty<Village>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(village, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(VillageVM villageVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var myContent = JsonConvert.SerializeObject(villageVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (villageVM.Id.Equals(0))
            {
                var result = client.PostAsync("Villages", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Villages/" + villageVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            Village village = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var responseTask = client.GetAsync("Villages/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Village>();
                readTask.Wait();
                village = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(village, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var result = client.DeleteAsync("Villages/" + id).Result;
        }
    }
}