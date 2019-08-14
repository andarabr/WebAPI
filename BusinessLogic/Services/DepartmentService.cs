using System.Collections.Generic;
using Common.Repositories.Interfaces;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Services.Interfaces
{
    public class DepartmentService : IDepartmentService
    {
        bool status = false;

        private IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public List<Department> Get()
        {
            var result = _departmentRepository.Get();
            return result;
        }

        public Department Get(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return null;
            }
            else
            {
                var result = _departmentRepository.Get(id);
                return result;
            }
        }

        public bool Insert(DepartmentVM departmentVM)
        {
            if (string.IsNullOrWhiteSpace(departmentVM.Name))
            {
                return status;
            }
            else
            {
                var result = _departmentRepository.Insert(departmentVM);
                return result;
            }
        }

        public bool Update(int id, DepartmentVM departmentVM)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()) || string.IsNullOrWhiteSpace(departmentVM.Name))
            {
                return status;
            }
            else
            {
                var result = _departmentRepository.Update(id, departmentVM);
                return result;
            }
        }

        public bool Delete(int id)
        {
            if (string.IsNullOrWhiteSpace((id.ToString())))
            {
                return status;
            }
            else
            {
                var result = _departmentRepository.Delete(id);
                return result;
            }
        }
    }
}