using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        List<Login> Get();
        Login Get(int id);
        Login GetUserByLogin(string email, string password, int application);
        bool Insert(LoginVM parameterVM);
        bool Update(int id, LoginVM parameterVM);
        bool Delete(int id);
    }
}