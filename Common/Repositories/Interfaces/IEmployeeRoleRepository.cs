using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repositories.Interfaces
{
    public interface IEmployeeRoleRepository
    {
        List<EmployeeRole> Get();
        EmployeeRole Get(int id);
        EmployeeRole GetLast();
        bool Insert(EmployeeRoleVM employeeRoleVM);
        bool Update(int id, EmployeeRoleVM employeeRoleVM);
        bool Delete(int id);
    }
}