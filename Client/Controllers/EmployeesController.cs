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
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            return View(LoadEmployee());
        }

        public JsonResult LoadEmployee()
        {
            IEnumerable<Employee> employee = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var responseTask = client.GetAsync("Employees");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Employee>>();
                readTask.Wait();
                employee = readTask.Result;
            }
            else
            {
                employee = Enumerable.Empty<Employee>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            var jsonResult = Json(employee, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public void InsertOrUpdate(EmployeeVM employeeVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var myContent = JsonConvert.SerializeObject(employeeVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (employeeVM.Id.Equals(0))
            {
                var result = client.PostAsync("Employees", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Employees/" + employeeVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            Employee employee = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var responseTask = client.GetAsync("Employees/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Employee>();
                readTask.Wait();
                employee = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(employee, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var result = client.DeleteAsync("Employees/" + id).Result;
        }
    }
}