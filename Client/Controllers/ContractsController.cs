using Client.ViewModels;
using DataAccess.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class ContractsController : Controller
    {
        // GET: Contracts
        public ActionResult Index()
        {
            return View(LoadContract());
        }

        public JsonResult LoadContract()
        {
            IEnumerable<Contract> contract = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var responseTask = client.GetAsync("Contracts");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Contract>>();
                readTask.Wait();
                contract = readTask.Result;
            }
            else
            {
                contract = Enumerable.Empty<Contract>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(contract, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(ContractVM contractVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var myContent = JsonConvert.SerializeObject(contractVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (contractVM.Id.Equals(0))
            {
                var result = client.PostAsync("Contracts", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Contracts/" + contractVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            Contract contract = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var responseTask = client.GetAsync("Contracts/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Contract>();
                readTask.Wait();
                contract = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(contract, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var result = client.DeleteAsync("Contracts/" + id).Result;
        }
    }
}