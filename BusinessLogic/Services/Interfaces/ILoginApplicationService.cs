using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Services.Interfaces
{
    public interface ILoginApplicationService
    {
        List<LoginApplication> Get();
        LoginApplication Get(int id);
        bool Insert(LoginApplicationVM loginApplicationVM);
        bool Update(int id, LoginApplicationVM loginApplicationVM);
        bool Delete(int id);
    }
}