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
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            return View(LoadRole());
        }

        public JsonResult LoadRole()
        {
            IEnumerable<RoleVM> roleVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var responseTask = client.GetAsync("Roles");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<RoleVM>>();
                readTask.Wait();
                roleVM = readTask.Result;
            }
            else
            {
                roleVM = Enumerable.Empty<RoleVM>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(roleVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(RoleVM roleVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var myContent = JsonConvert.SerializeObject(roleVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (roleVM.Id.Equals(0))
            {
                var result = client.PostAsync("Roles", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Roles/" + roleVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            RoleVM roleVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var responseTask = client.GetAsync("Roles/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<RoleVM>();
                readTask.Wait();
                roleVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(roleVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var result = client.DeleteAsync("Roles/" + id).Result;
        }
    }
}