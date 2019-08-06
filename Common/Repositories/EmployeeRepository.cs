﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.Repositories.Interfaces;
using DataAccess.Context;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
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

        public List<Employee> Get()
        {
            var get = applicationContext.Employee.Include("Religion").Include("Role").Include("Village").Include("Department").Where(x => x.IsDeleted == false).ToList();
            return get;
        }

        public Employee GetLast()
        {
            var get = applicationContext.Employee.OrderByDescending(t => t.Id).FirstOrDefault();
            return get;
        }

        public List<Employee> Get(string value)
        {
            //roles di application context class
            var get = applicationContext.Employee.Include("Religion").Include("Role").Include("Village").Include("Department").Where(x => (x.LastName.Contains(value) || x.UserEmail.Contains(value) || x.Id.ToString().Contains(value) || x.Religion.Name.Contains(value)) && x.IsDeleted == false).ToList();
            return get;
        }

        public Employee Get(int id)
        {
            var get = applicationContext.Employee.SingleOrDefault(x => x.IsDeleted == false && x.Id == id);
            return get;
        }

        public bool Insert(EmployeeVM employeeVM)
        {
            var push = new Employee(employeeVM);
            var getManager = applicationContext.Employee.SingleOrDefault(x => x.IsDeleted == false && x.Id == employeeVM.ManagerId);
            var getReligion = applicationContext.Religion.SingleOrDefault(x => x.IsDeleted == false && x.Id == employeeVM.ReligionId);
            var getRole = applicationContext.Role.SingleOrDefault(x => x.IsDeleted == false && x.Id == employeeVM.RoleId);
            var getVillage = applicationContext.Village.SingleOrDefault(x => x.IsDeleted == false && x.Id == employeeVM.VillageId);
            var getDepartment = applicationContext.Department.SingleOrDefault(x => x.IsDeleted == false && x.Id == employeeVM.DepartmentId);
            push.Manager = getManager;
            push.Religion = getReligion;
            push.Role = getRole;
            push.Village = getVillage;
            push.Department = getDepartment;
            applicationContext.Employee.Add(push);
            var result = applicationContext.SaveChanges();
            return result > 0;
        }

        public bool Update(int id, EmployeeVM employeeVM)
        {
            var get = Get(id);
            var getManager = applicationContext.Employee.SingleOrDefault(x => x.IsDeleted == false && x.Id == employeeVM.ManagerId);
            var getReligion = applicationContext.Religion.SingleOrDefault(x => x.IsDeleted == false && x.Id == employeeVM.ReligionId);
            var getRole = applicationContext.Role.SingleOrDefault(x => x.IsDeleted == false && x.Id == employeeVM.RoleId);
            var getVillage = applicationContext.Village.SingleOrDefault(x => x.IsDeleted == false && x.Id == employeeVM.VillageId);
            var getDepartment = applicationContext.Department.SingleOrDefault(x => x.IsDeleted == false && x.Id == employeeVM.DepartmentId);
            get.Manager = getManager;
            get.Religion = getReligion;
            get.Role = getRole;
            get.Village = getVillage;
            get.Department = getDepartment;
            get.Update(employeeVM);
            applicationContext.Entry(get).State = EntityState.Modified;
            var result = applicationContext.SaveChanges();
            return result > 0;
        }
    }
}