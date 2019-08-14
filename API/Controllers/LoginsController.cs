using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogic.Services.Interfaces;
using DataAccess.ViewModels;

namespace API.Controllers
{
    public class LoginsController : ApiController
    {
        private readonly ILoginService _iLoginService;

        public LoginsController() { }

        public LoginsController(ILoginService iLoginService)
        {
            _iLoginService = iLoginService;
        }

        //public HttpResponseMessage Get()
        //{
        //    var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data Not Found");
        //    var get = _iLoginService.Get();
        //    if (get != null)
        //    {
        //        message = Request.CreateResponse(HttpStatusCode.OK, get);
        //        return message;
        //    }
        //    return message;
        //}

        //public HttpResponseMessage Get(int id)
        //{
        //    var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data Not Found");
        //    var get = _iLoginService.Get(id);
        //    if (get != null)
        //    {
        //        message = Request.CreateResponse(HttpStatusCode.OK, get);
        //        return message;
        //    }
        //    return message;
        //}

        //public HttpResponseMessage Update(int id, LoginVM loginVM)
        //{
        //    var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Bad Request");
        //    if (string.IsNullOrWhiteSpace(id.ToString()))
        //    {
        //        message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Id");
        //    }
        //    else
        //    {
        //        var get = _iLoginService.Update(id, loginVM);
        //        if (get)
        //        {
        //            message = Request.CreateResponse(HttpStatusCode.OK, get);
        //            return message;
        //        }
        //    }
        //    return message;
        //}

        //public HttpResponseMessage Insert(LoginVM loginVM)
        //{
        //    var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Wrong Parameters");
        //    var result = _iLoginService.Insert(loginVM);
        //    if (result)
        //    {
        //        message = Request.CreateResponse(HttpStatusCode.OK, "Successfully Added");
        //    }

        //    return message;
        //}

        //public HttpResponseMessage Delete(int id)
        //{
        //    var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        //    if (string.IsNullOrWhiteSpace(id.ToString()))
        //    {
        //        message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Id");
        //    }
        //    else
        //    {
        //        var result = _iLoginService.Delete(id);
        //        if (result)
        //        {
        //            message = Request.CreateResponse(HttpStatusCode.OK);
        //        }
        //    }
        //    return message;
        //}

        public HttpResponseMessage GetUserByLogin(LoginVM loginVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Id");
            var get = _iLoginService.GetUserByLogin(loginVM);
            if (get != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, get);
                return message;
            }
            return message;
        }

    }
}