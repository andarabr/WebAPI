using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Services.Interfaces
{
    public interface IVillageService
    {
        List<Village> Get();
        Village Get(int id);
        Village GetByDistrict(int id);
        bool Insert(VillageVM villageVM);
        bool Update(int id, VillageVM villageVM);
        bool Delete(int id);
    }
}