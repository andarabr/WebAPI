using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repositories.Interfaces
{
    public interface IVillageRepository
    {
        List<Village> Get();
        Village Get(int id);
        Village GetByDistrict(int id);
        bool Insert(VillageVM villageVM);
        bool Update(int id, VillageVM villageVM);
        bool Delete(int id);
    }
}