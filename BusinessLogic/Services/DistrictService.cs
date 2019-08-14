using System.Collections.Generic;
using BusinessLogic.Services.Interfaces;
using Common.Repositories.Interfaces;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Services
{
    public class DistrictService : IDistrictService
    {
        bool status = false;

        private IDistrictRepository _districtRepository;

        public DistrictService(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        public List<District> Get()
        {
            var result = _districtRepository.Get();
            return result;
        }

        public District Get(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return null;
            }
            else
            {
                var result = _districtRepository.Get(id);
                return result;
            }
        }

        public bool Insert(DistrictVM districtVM)
        {
            if (string.IsNullOrWhiteSpace(districtVM.Name))
            {
                return status;
            }
            else
            {
                var result = _districtRepository.Insert(districtVM);
                return result;
            }
        }

        public bool Update(int id, DistrictVM districtVM)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()) || string.IsNullOrWhiteSpace(districtVM.Name))
            {
                return status;
            }
            else
            {
                var result = _districtRepository.Update(id, districtVM);
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
                var result = _districtRepository.Delete(id);
                return result;
            }
        }
    }
}