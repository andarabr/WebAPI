using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.Repositories.Interfaces;
using DataAccess.Context;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repositories
{
    public class VillageRepository : IVillageRepository
    {
        private bool status = false;
        private ApplicationContext applicationContext = new ApplicationContext();

        public bool Delete(int id)
        {
            var get = Get(id);
            get.Delete();
            applicationContext.Entry(get).State = EntityState.Modified;
            var result = applicationContext.SaveChanges();
            return result > 0;
        }

        public List<Village> Get()
        {
            var get = applicationContext.Village.Include("District").Include("District.Regency").Include("District.Regency.Province").Where(x => x.IsDeleted == false).ToList();
            return get;
        }

        public Village Get(int id)
        {
            var get = applicationContext.Village.Include("District").Include("District.Regency").Include("District.Regency.Province").SingleOrDefault(x => x.IsDeleted == false && x.Id == id);
            return get;
        }

        public bool Insert(VillageVM villageVM)
        {
            var push = new Village(villageVM);
            //ini nih foreign key
            var getDistrict = applicationContext.District.SingleOrDefault(x => x.IsDeleted == false && x.Id == villageVM.DistrictId);
            push.District = getDistrict;
            applicationContext.Village.Add(push);
            var result = applicationContext.SaveChanges();
            return result > 0;
        }

        public bool Update(int id, VillageVM villageVM)
        {
            var get = Get(id);
            var getDistrict = applicationContext.District.SingleOrDefault(x => x.IsDeleted == false && x.Id == villageVM.DistrictId);
            get.District = getDistrict;
            get.Update(villageVM);
            applicationContext.Entry(get).State = EntityState.Modified;
            var result = applicationContext.SaveChanges();
            return result > 0;
        }
    }
}