using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using BootcampManagement.Client.ViewModels;
using Newtonsoft.Json;

namespace Client.Controllers
{
    public class ApplicationsController : Controller
    {
        // GET: Applications
        public ActionResult Index()
        {
            return View(LoadApplication());
        }

        public JsonResult LoadApplication()
        {
            IEnumerable<ApplicationVM> applicationVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var responseTask = client.GetAsync("Applications");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ApplicationVM>>();
                readTask.Wait();
                applicationVM = readTask.Result;
            }
            else
            {
                applicationVM = Enumerable.Empty<ApplicationVM>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(applicationVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(ApplicationVM applicationVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var myContent = JsonConvert.SerializeObject(applicationVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (applicationVM.Id.Equals(0))
            {
                var result = client.PostAsync("Applications", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Applications/" + applicationVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            ApplicationVM applicationVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var responseTask = client.GetAsync("Applications/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<ApplicationVM>();
                readTask.Wait();
                applicationVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(applicationVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var result = client.DeleteAsync("Applications/" + id).Result;
        }
    }
}