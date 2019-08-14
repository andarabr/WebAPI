using System.Collections.Generic;
using BusinessLogic.Services.Interfaces;
using Common.Repositories.Interfaces;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Services
{
    public class ContractService : IContractService
    {
        bool status = false;

        private IContractRepository _contractRepository;

        public ContractService(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public List<Contract> Get()
        {
            var result = _contractRepository.Get();
            return result;
        }

        public Contract Get(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return null;
            }
            else
            {
                var result = _contractRepository.Get(id);
                return result;
            }
        }

        public bool Insert(ContractVM contractVM)
        {
            if (string.IsNullOrWhiteSpace(contractVM.EmployeeId.ToString()))
            {
                return status;
            }
            else
            {
                var result = _contractRepository.Insert(contractVM);
                return result;
            }
        }

        public bool Update(int id, ContractVM contractVM)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()) || string.IsNullOrWhiteSpace(contractVM.EmployeeId.ToString()))
            {
                return status;
            }
            else
            {
                var result = _contractRepository.Update(id, contractVM);
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
                var result = _contractRepository.Delete(id);
                return result;
            }
        }
    }
}