using System.Collections.Generic;
using System.Net.Mime;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Services.Interfaces
{
    public interface IApplicationService
    {
        List<Application> Get();
        Application Get(int id);
        bool Insert(ApplicationVM applicationVM);
        bool Update(int id, ApplicationVM applicationVM);
        bool Delete(int id);
    }
}