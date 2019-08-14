using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.Repositories.Interfaces;
using DataAccess.Context;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repositories
{
    public class ReligionRepository : IReligionRepository
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

        public List<Religion> Get()
        {
            var get = applicationContext.Religion.Where(x => x.IsDeleted == false).ToList();
            return get;
        }

        public Religion Get(int id)
        {
            var get = applicationContext.Religion.SingleOrDefault(x => x.IsDeleted == false && x.Id == id);
            return get;
        }

        public bool Insert(ReligionVM religionVM)
        {
            var push = new Religion(religionVM);
            applicationContext.Religion.Add(push);
            var result = applicationContext.SaveChanges();
            return result > 0;
        }

        public bool Update(int id, ReligionVM religionVM)
        {
            var get = Get(id);
            get.Update(religionVM);
            applicationContext.Entry(get).State = EntityState.Modified;
            var result = applicationContext.SaveChanges();
            return result > 0;
        }
    }
}