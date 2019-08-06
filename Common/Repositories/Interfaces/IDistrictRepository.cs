using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repositories.Interfaces
{
    public interface IDistrictRepository
    {
        List<District> Get();
        District Get(int id);
        List<District> Get(string value);
        bool Insert(DistrictVM districtVM);
        bool Update(int id, DistrictVM districtVM);
        bool Delete(int id);
    }
}