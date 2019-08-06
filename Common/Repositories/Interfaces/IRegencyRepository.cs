using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repositories.Interfaces
{
    public interface IRegencyRepository
    {
        List<Regency> Get();
        Regency Get(int id);
        List<Regency> Get(string value);
        bool Insert(RegencyVM regencyVM);
        bool Update(int id, RegencyVM regencyVM);
        bool Delete(int id);
    }
}