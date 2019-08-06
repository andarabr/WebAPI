using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repositories.Interfaces
{
    public interface ILoginApplicationRepository
    {
        List<LoginApplication> Get();
        LoginApplication Get(int id);
        List<LoginApplication> Get(string value);
        bool Insert(LoginApplicationVM loginApplicationVM);
        bool Update(int id, LoginApplicationVM loginApplicationVM);
        bool Delete(int id);
    }
}