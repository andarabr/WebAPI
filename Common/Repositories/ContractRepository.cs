using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.Repositories.Interfaces;
using DataAccess.Context;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repositories
{
    public class ContractRepository : IContractRepository
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

        public List<Contract> Get()
        {
            var get = applicationContext.Contract.Include("Employee").Where(x => x.IsDeleted == false).ToList();
            return get;
        }

        public List<Contract> GetUncontracted()
        {
            var get = applicationContext.Contract.Include("Employee").Where(x => x.IsDeleted == false).ToList();
            return get;
        }

        public Contract Get(int id)
        {
            var get = applicationContext.Contract.SingleOrDefault(x => x.IsDeleted == false && x.Id == id);
            return get;
        }

        public Contract GetLast()
        {
            var get = applicationContext.Contract.OrderByDescending(t => t.Id).FirstOrDefault();
            return get;
        }

        public bool Insert(ContractVM contractVM)
        {
            var push = new Contract(contractVM);
            //ini nih foreign key
            var getEmployee = applicationContext.Employee.SingleOrDefault(x => x.IsDeleted == false && x.Id == contractVM.EmployeeId);
            push.Employee = getEmployee;
            applicationContext.Contract.Add(push);
            var result = applicationContext.SaveChanges();
            return result > 0;
        }

        public bool Update(int id, ContractVM contractVM)
        {
            var get = Get(id);
            var getEmployee = applicationContext.Employee.SingleOrDefault(x => x.IsDeleted == false && x.Id == contractVM.EmployeeId);
            get.Employee = getEmployee;
            get.Update(contractVM);
            applicationContext.Entry(get).State = EntityState.Modified;
            var result = applicationContext.SaveChanges();
            return result > 0;
        }
    }
}