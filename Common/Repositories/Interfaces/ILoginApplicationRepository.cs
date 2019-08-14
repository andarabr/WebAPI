using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repositories.Interfaces
{
    public interface ILoginApplicationRepository
    {
        List<LoginApplication> Get();
        LoginApplication Get(int id);
        bool Insert(LoginApplicationVM loginApplicationVM);
        bool Update(int id, LoginApplicationVM loginApplicationVM);
        bool Delete(int id);
    }
}