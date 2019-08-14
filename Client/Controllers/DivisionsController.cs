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
    public class DivisionsController : Controller
    {
        // GET: Divisions
        public ActionResult Index()
        {
            return View(LoadDivision());
        }

        public JsonResult LoadDivision()
        {
            IEnumerable<DivisionVM> divisionVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var responseTask = client.GetAsync("Divisions");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<DivisionVM>>();
                readTask.Wait();
                divisionVM = readTask.Result;
            }
            else
            {
                divisionVM = Enumerable.Empty<DivisionVM>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(divisionVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(DivisionVM divisionVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var myContent = JsonConvert.SerializeObject(divisionVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (divisionVM.Id.Equals(0))
            {
                var result = client.PostAsync("Divisions", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Divisions/" + divisionVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            DivisionVM divisionVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var responseTask = client.GetAsync("Divisions/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<DivisionVM>();
                readTask.Wait();
                divisionVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(divisionVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var result = client.DeleteAsync("Divisions/" + id).Result;
        }
    }
}