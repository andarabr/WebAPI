using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogic.Services.Interfaces;
using DataAccess.ViewModels;

namespace API.Controllers
{
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeService _iEmployeeService;

        public EmployeesController() { }

        public EmployeesController(IEmployeeService iEmployeeService)
        {
            _iEmployeeService = iEmployeeService;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data Not Found");
            var get = _iEmployeeService.Get();
            if (get != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, get);
                return message;
            }
            return message;
        }

        //[ActionName("GetLast")]
        //public HttpResponseMessage GetLast()
        //{
        //    var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data Not Found");
        //    var get = _iEmployeeService.GetLast();
        //    if (get != null)
        //    {
        //        message = Request.CreateResponse(HttpStatusCode.OK, get);
        //        return message;
        //    }
        //    return message;
        //}

        public HttpResponseMessage Get(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data Not Found");
            var get = _iEmployeeService.Get(id);
            if (get != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, get);
                return message;
            }
            return message;
        }

        public HttpResponseMessage Update(int id, EmployeeVM employeeVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Bad Request");
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Id");
            }
            else
            {
                var get = _iEmployeeService.Update(id, employeeVM);
                if (get)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, get);
                    return message;
                }
            }
            return message;
        }

        public HttpResponseMessage Insert(EmployeeVM employeeVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Wrong Parameters");
            var result = _iEmployeeService.Insert(employeeVM);
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
                var result = _iEmployeeService.Delete(id);
                if (result)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            return message;
        }
    }
}
