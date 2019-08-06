using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repositories.Interfaces
{
    public interface IContractRepository
    {
        List<Contract> Get();
        List<Contract> GetUncontracted();
        Contract Get(int id);
        Contract GetLast();
        List<Contract> Get(string value);
        bool Insert(ContractVM contractVM);
        bool Update(int id, ContractVM contractVM);
        bool Delete(int id);
    }
}