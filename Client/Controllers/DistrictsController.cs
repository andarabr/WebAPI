﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using DataAccess.Models;
using DataAccess.ViewModels;
using Newtonsoft.Json;
using DistrictVM = BootcampManagement.Client.ViewModels.DistrictVM;

namespace Client.Controllers
{
    public class DistrictsController : Controller
    {
        // GET: Districts
        public ActionResult Index()
        {
            return View(LoadDistrict());
        }

        public JsonResult LoadDistrict()
        {
            IEnumerable<District> district = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var responseTask = client.GetAsync("Districts");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<District>>();
                readTask.Wait();
                district = readTask.Result;
            }
            else
            {
                district = Enumerable.Empty<District>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(district, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(DistrictVM districtVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var myContent = JsonConvert.SerializeObject(districtVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (districtVM.Id.Equals(0))
            {
                var result = client.PostAsync("Districts", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Districts/" + districtVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            District district = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var responseTask = client.GetAsync("Districts/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<District>();
                readTask.Wait();
                district = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(district, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52777/api/");
            var result = client.DeleteAsync("Districts/" + id).Result;
        }
    }
}