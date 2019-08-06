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
            var get = applicationContext.Village.Include("District").Where(x => x.IsDeleted == false).ToList();
            return get;
        }

        public List<Village> Get(string value)
        {
            //roles di application context class
            var get = applicationContext.Village.Include("District").Where(x => (x.Name.Contains(value) || x.Id.ToString().Contains(value) || x.District.Name.Contains(value)) && x.IsDeleted == false).ToList();
            return get;
        }

        public Village Get(int id)
        {
            var get = applicationContext.Village.SingleOrDefault(x => x.IsDeleted == false && x.Id == id);
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
            get.Update(villageVM);
            applicationContext.Entry(get).State = EntityState.Modified;
            var result = applicationContext.SaveChanges();
            return result > 0;
        }
    }
}