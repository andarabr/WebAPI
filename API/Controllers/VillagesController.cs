using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogic.Services.Interfaces;
using DataAccess.ViewModels;

namespace API.Controllers
{
    public class VillagesController : ApiController
    {
        private readonly IVillageService _iVillageService;

        public VillagesController() { }

        public VillagesController(IVillageService iVillageService)
        {
            _iVillageService = iVillageService;
        }

        public HttpResponseMessage Get()
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data Not Found");
            var get = _iVillageService.Get();
            if (get != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, get);
                return message;
            }
            return message;
        }

        public HttpResponseMessage Get(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data Not Found");
            var get = _iVillageService.Get(id);
            if (get != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, get);
                return message;
            }
            return message;
        }

        public HttpResponseMessage GetByDistrict(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data Not Found");
            var get = _iVillageService.GetByDistrict(id);
            if (get != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, get);
                return message;
            }
            return message;
        }


        [HttpPut]
        public HttpResponseMessage Update(int id, VillageVM villageVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Bad Request");
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Id");
            }
            else
            {
                var get = _iVillageService.Update(id, villageVM);
                if (get)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, get);
                    return message;
                }
            }
            return message;
        }

        public HttpResponseMessage Insert(VillageVM villageVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Wrong Parameters");
            var result = _iVillageService.Insert(villageVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, "Successfully Added");
            }

            return message;
        }

        public HttpResponseMessage Delete(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Id");
            }
            else
            {
                var result = _iVillageService.Delete(id);
                if (result)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            return message;
        }

    }
}