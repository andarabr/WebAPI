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
    public class RoleRepository : IRoleRepository
    {
        private bool status = false;
        private ApplicationContext applicationContext = new ApplicationContext();

        public bool Delete(int id)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Delete();
                applicationContext.Entry(get).State = EntityState.Modified;
                var result = applicationContext.SaveChanges();
                return result > 0;
            }
            else
            {
                return false;
            }
        }

        public List<Role> Get()
        {
            var get = applicationContext.Role.Where(x => x.IsDeleted == false).ToList();
            return get;
        }

        public List<Role> Get(string value)
        {
            //roles di application context class
            var get = applicationContext.Role.Where(x => (x.Name.Contains(value) || Convert.ToString(x.Id).Contains(value)) && x.IsDeleted == false).ToList();
            return get;
        }

        public Role Get(int id)
        {
            var get = applicationContext.Role.SingleOrDefault(x => x.IsDeleted == false && x.Id == id);
            return get;
        }

        public bool Insert(RoleVM roleVM)
        {
            var push = new Role(roleVM);
            applicationContext.Role.Add(push);
            var result = applicationContext.SaveChanges();
            return result > 0;
        }

        public bool Update(int id, RoleVM roleVM)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Update(roleVM);
                applicationContext.Entry(get).State = EntityState.Modified;
                var result = applicationContext.SaveChanges();
                return result > 0;
            }
            else
            {
                return false;
            }
        }
    }
}