using System.Collections.Generic;
using BusinessLogic.Services.Interfaces;
using Common.Repositories.Interfaces;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Services
{
    public class VillageService : IVillageService
    {
        bool status = false;

        private IVillageRepository _villageRepository;

        public VillageService(IVillageRepository villageRepository)
        {
            _villageRepository = villageRepository;
        }

        public List<Village> Get()
        {
            var result = _villageRepository.Get();
            return result;
        }

        public Village Get(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return null;
            }
            else
            {
                var result = _villageRepository.Get(id);
                return result;
            }
        }

        public Village GetByDistrict(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return null;
            }
            else
            {
                var result = _villageRepository.GetByDistrict(id);
                return result;
            }
        }

        public bool Insert(VillageVM villageVM)
        {
            if (string.IsNullOrWhiteSpace(villageVM.Name))
            {
                return status;
            }
            else
            {
                var result = _villageRepository.Insert(villageVM);
                return result;
            }
        }

        public bool Update(int id, VillageVM villageVM)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()) || string.IsNullOrWhiteSpace(villageVM.Name))
            {
                return status;
            }
            else
            {
                var result = _villageRepository.Update(id, villageVM);
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
                var result = _villageRepository.Delete(id);
                return result;
            }
        }
    }
}