using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Services.Interfaces
{
    public interface ILoginService
    {
        List<Login> Get();
        Login Get(int id);
        Login GetUserByLogin(LoginVM loginVM);
        bool Insert(LoginVM parameterVM);
        bool Update(int id, LoginVM parameterVM);
        bool Delete(int id);
    }
}