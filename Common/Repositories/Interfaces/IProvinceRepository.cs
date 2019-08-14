using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repositories.Interfaces
{
    public interface IProvinceRepository
    {
        List<Province> Get();
        Province Get(int id);
        bool Insert(ProvinceVM provinceVM);
        bool Update(int id, ProvinceVM provinceVM);
        bool Delete(int id);
    }
}