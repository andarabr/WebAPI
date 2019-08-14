using BootcampManagement.Client.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using DataAccess.Models;

namespace BootcampManagement.Client.Controllers
{
    public class RegenciesController : Controller
    {
        // GET: Regencies
        public ActionResult Index()
        {
            return View(LoadRegency());
        }

        public JsonResult LoadRegency()
        {
            IEnumerable<Regency> regency = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var responseTask = client.GetAsync("Regencies");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Regency>>();
                readTask.Wait();
                regency = readTask.Result;
            }
            else
            {
                regency = Enumerable.Empty<Regency>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(regency, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(RegencyVM regencyVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var myContent = JsonConvert.SerializeObject(regencyVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (regencyVM.Id.Equals(0))
            {
                var result = client.PostAsync("Regencies", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Regencies/" + regencyVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            Regency regency = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var responseTask = client.GetAsync("Regencies/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Regency>();
                readTask.Wait();
                regency = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(regency, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var result = client.DeleteAsync("Regencies/" + id).Result;
        }
    }
}