using System.Collections.Generic;
using Common.Repositories.Interfaces;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Services.Interfaces
{
    public class ReligionService : IReligionService
    {
        bool status = false;

        private IReligionRepository _religionRepository;

        public ReligionService(IReligionRepository religionRepository)
        {
            _religionRepository = religionRepository;
        }

        public List<Religion> Get()
        {
            var result = _religionRepository.Get();
            return result;
        }

        public Religion Get(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return null;
            }
            else
            {
                var result = _religionRepository.Get(id);
                return result;
            }
        }

        public bool Insert(ReligionVM religionVM)
        {
            if (string.IsNullOrWhiteSpace(religionVM.Name))
            {
                return status;
            }
            else
            {
                var result = _religionRepository.Insert(religionVM);
                return result;
            }
        }

        public bool Update(int id, ReligionVM religionVM)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()) || string.IsNullOrWhiteSpace(religionVM.Name))
            {
                return status;
            }
            else
            {
                var result = _religionRepository.Update(id, religionVM);
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
                var result = _religionRepository.Delete(id);
                return result;
            }
        }
    }
}