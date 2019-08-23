using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class LoginApplicationsController : Controller
    {
        // GET: LoginApplications
        public ActionResult Index()
        {
            return View(LoadDepartment());
        }

        public JsonResult LoadDepartment()
        {
            IEnumerable<Department> department = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.128.222:9810/api/");
            var responseTask = client.GetAsync("Departments");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Department>>();
                readTask.Wait();
                department = readTask.Result;
            }
            else
            {
                department = Enumerable.Empty<Department>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(department, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(DepartmentVM departmentVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.128.222:9810/api/");
            var myContent = JsonConvert.SerializeObject(departmentVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (departmentVM.Id.Equals(0))
            {
                var result = client.PostAsync("Departments", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Departments/" + departmentVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            Department department = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.128.222:9810/api/");
            var responseTask = client.GetAsync("Departments/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Department>();
                readTask.Wait();
                department = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(department, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.128.222:9810/api/");
            var result = client.DeleteAsync("Departments/" + id).Result;
        }
    }
}