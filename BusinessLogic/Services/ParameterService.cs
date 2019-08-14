using System.Collections.Generic;
using BusinessLogic.Services.Interfaces;
using Common.Repositories.Interfaces;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Services
{
    public class ParameterService : IParameterService
    {
        bool status = false;

        private IParameterRepository _parameterRepository;

        public ParameterService(IParameterRepository parameterRepository)
        {
            _parameterRepository = parameterRepository;
        }

        public List<Parameter> Get()
        {
            var result = _parameterRepository.Get();
            return result;
        }

        public Parameter Get(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return null;
            }
            else
            {
                var result = _parameterRepository.Get(id);
                return result;
            }
        }

        public bool Insert(ParameterVM parameterVM)
        {
            if (string.IsNullOrWhiteSpace(parameterVM.Name))
            {
                return status;
            }
            else
            {
                var result = _parameterRepository.Insert(parameterVM);
                return result;
            }
        }

        public bool Update(int id, ParameterVM parameterVM)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()) || string.IsNullOrWhiteSpace(parameterVM.Name))
            {
                return status;
            }
            else
            {
                var result = _parameterRepository.Update(id, parameterVM);
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
                var result = _parameterRepository.Delete(id);
                return result;
            }
        }
    }
}