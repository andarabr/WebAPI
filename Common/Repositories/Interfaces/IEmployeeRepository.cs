using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> Get();
        Employee Get(int id);
        Employee GetLast();
        List<Employee> Get(string value);
        bool Insert(EmployeeVM employeeVM);
        bool Update(int id, EmployeeVM employeeVM);
        bool Delete(int id);
    }
}