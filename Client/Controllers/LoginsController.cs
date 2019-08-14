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
    public class LoginsController : Controller
    {
        // GET: Logins
        public ActionResult Index()
        {
            return View(LoadLogin());
        }

        public JsonResult LoadLogin()
        {
            IEnumerable<LoginVM> loginVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var responseTask = client.GetAsync("Logins");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<LoginVM>>();
                readTask.Wait();
                loginVM = readTask.Result;
            }
            else
            {
                loginVM = Enumerable.Empty<LoginVM>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(loginVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(LoginVM loginVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var myContent = JsonConvert.SerializeObject(loginVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (loginVM.Id.Equals(0))
            {
                var result = client.PostAsync("Logins", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Logins/" + loginVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            LoginVM loginVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var responseTask = client.GetAsync("Logins/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<LoginVM>();
                readTask.Wait();
                loginVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(loginVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var result = client.DeleteAsync("Logins/" + id).Result;
        }
    }
}