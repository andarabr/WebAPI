using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Services.Interfaces
{
    public interface IContractService
    {
        List<Contract> Get();
        //List<Contract> GetUncontracted();
        Contract Get(int id);
        //Contract GetLast();
        bool Insert(ContractVM contractVM);
        bool Update(int id, ContractVM contractVM);
        bool Delete(int id);
    }
}