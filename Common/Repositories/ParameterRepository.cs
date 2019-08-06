using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.Repositories.Interfaces;
using DataAccess.Context;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repositories
{
    public class ParameterRepository : IParameterRepository
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

        public List<Parameter> Get()
        {
            var get = applicationContext.Parameter.Where(x => x.IsDeleted == false).ToList();
            return get;
        }

        public List<Parameter> Get(string value)
        {
            //roles di application context class
            var get = applicationContext.Parameter.Where(x => (x.Name.Contains(value) || x.Id.ToString().Contains(value)) && x.IsDeleted == false).ToList();
            return get;
        }

        public Parameter Get(int id)
        {
            var get = applicationContext.Parameter.SingleOrDefault(x => x.IsDeleted == false && x.Id == id);
            return get;
        }

        public bool Insert(ParameterVM parameterVM)
        {
            var push = new Parameter(parameterVM);
            applicationContext.Parameter.Add(push);
            var result = applicationContext.SaveChanges();
            return result > 0;
        }

        public bool Update(int id, ParameterVM parameterVM)
        {
            var get = Get(id);
            get.Update(parameterVM);
            applicationContext.Entry(get).State = EntityState.Modified;
            var result = applicationContext.SaveChanges();
            return result > 0;
        }
    }
}