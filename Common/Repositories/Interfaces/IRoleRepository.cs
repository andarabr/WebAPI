using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        List<Role> Get();
        Role Get(int id);
        List<Role> Get(string value);
        bool Insert(RoleVM roleVM);
        bool Update(int id, RoleVM roleVM);
        bool Delete(int id);
    }
}