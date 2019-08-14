using System.Collections.Generic;
using BusinessLogic.Services.Interfaces;
using Common.Repositories.Interfaces;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {
        bool status = false;

        private IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<Employee> Get()
        {
            var result = _employeeRepository.Get();
            return result;
        }

        public Employee Get(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return null;
            }
            else
            {
                var result = _employeeRepository.Get(id);
                return result;
            }
        }

        public Employee GetLast()
        {
            var result = _employeeRepository.GetLast();
            return result;
        }

        public bool Insert(EmployeeVM employeeVM)
        {
            if (string.IsNullOrWhiteSpace(employeeVM.FirstName))
            {
                return status;
            }
            else
            {
                var result = _employeeRepository.Insert(employeeVM);
                return result;
            }
        }

        public bool Update(int id, EmployeeVM employeeVM)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()) || string.IsNullOrWhiteSpace(employeeVM.FirstName))
            {
                return status;
            }
            else
            {
                var result = _employeeRepository.Update(id, employeeVM);
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
                var result = _employeeRepository.Delete(id);
                return result;
            }
        }
    }
}