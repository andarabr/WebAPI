using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.Repositories.Interfaces;
using DataAccess.Context;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repositories
{
    public class DistrictRepository : IDistrictRepository
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

        public List<District> Get()
        {
            var get = applicationContext.District.Include("Regency").Where(x => x.IsDeleted == false).ToList();
            return get;
        }

        public List<District> Get(string value)
        {
            //roles di application context class
            var get = applicationContext.District.Include("Regency").Where(x => (x.Name.Contains(value) || x.Id.ToString().Contains(value) || x.Regency.Name.Contains(value)) && x.IsDeleted == false).ToList();
            return get;
        }

        public District Get(int id)
        {
            var get = applicationContext.District.SingleOrDefault(x => x.IsDeleted == false && x.Id == id);
            return get;
        }

        public bool Insert(DistrictVM districtVM)
        {
            var push = new District(districtVM);
            //ini nih foreign key
            var getRegency = applicationContext.Regency.SingleOrDefault(x => x.IsDeleted == false && x.Id == districtVM.RegencyId);
            push.Regency = getRegency;
            applicationContext.District.Add(push);
            var result = applicationContext.SaveChanges();
            return result > 0;
        }

        public bool Update(int id, DistrictVM districtVM)
        {
            var get = Get(id);
            var getRegency = applicationContext.Regency.SingleOrDefault(x => x.IsDeleted == false && x.Id == districtVM.RegencyId);
            get.Regency = getRegency;
            get.Update(districtVM);
            applicationContext.Entry(get).State = EntityState.Modified;
            var result = applicationContext.SaveChanges();
            return result > 0;
        }
    }
}