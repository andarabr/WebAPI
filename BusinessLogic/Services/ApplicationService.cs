using System.Collections.Generic;
using BusinessLogic.Services.Interfaces;
using Common.Repositories.Interfaces;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Services
{
    public class ApplicationService : IApplicationService
    {
        bool status = false;

        private IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public List<Application> Get()
        {
            var result = _applicationRepository.Get();
            return result;
        }

        public Application Get(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return null;
            }
            else
            {
                var result = _applicationRepository.Get(id);
                return result;
            }
        }

        public bool Insert(ApplicationVM applicationVM)
        {
            if (string.IsNullOrWhiteSpace(applicationVM.Name))
            {
                return status;
            }
            else
            {
                var result = _applicationRepository.Insert(applicationVM);
                return result;
            }
        }

        public bool Update(int id, ApplicationVM applicationVM)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()) || string.IsNullOrWhiteSpace(applicationVM.Name))
            {
                return status;
            }
            else
            {
                var result = _applicationRepository.Update(id, applicationVM);
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
                var result = _applicationRepository.Delete(id);
                return result;
            }
        }
    }
}