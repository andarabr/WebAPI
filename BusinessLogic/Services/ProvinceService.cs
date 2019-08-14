using System.Collections.Generic;
using BusinessLogic.Services.Interfaces;
using Common.Repositories.Interfaces;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Services
{
    public class ProvinceService : IProvinceService
    {
        bool status = false;

        private IProvinceRepository _provinceRepository;

        public ProvinceService(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        public List<Province> Get()
        {
            var result = _provinceRepository.Get();
            return result;
        }

        public Province Get(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return null;
            }
            else
            {
                var result = _provinceRepository.Get(id);
                return result;
            }
        }

        public bool Insert(ProvinceVM provinceVM)
        {
            if (string.IsNullOrWhiteSpace(provinceVM.Name))
            {
                return status;
            }
            else
            {
                var result = _provinceRepository.Insert(provinceVM);
                return result;
            }
        }

        public bool Update(int id, ProvinceVM provinceVM)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()) || string.IsNullOrWhiteSpace(provinceVM.Name))
            {
                return status;
            }
            else
            {
                var result = _provinceRepository.Update(id, provinceVM);
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
                var result = _provinceRepository.Delete(id);
                return result;
            }
        }
    }
}