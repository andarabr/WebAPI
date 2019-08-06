using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        List<Department> Get();
        Department Get(int id);
        List<Department> Get(string value);
        bool Insert(DepartmentVM departmentVM);
        bool Update(int id, DepartmentVM departmentVM);
        bool Delete(int id);
    }
}