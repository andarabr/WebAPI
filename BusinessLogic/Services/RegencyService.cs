using System.Collections.Generic;
using BusinessLogic.Services.Interfaces;
using Common.Repositories.Interfaces;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Services
{
    public class RegencyService : IRegencyService
    {
        bool status = false;

        private IRegencyRepository _regencyRepository;

        public RegencyService(IRegencyRepository regencyRepository)
        {
            _regencyRepository = regencyRepository;
        }

        public List<Regency> Get()
        {
            var result = _regencyRepository.Get();
            return result;
        }

        public Regency Get(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return null;
            }
            else
            {
                var result = _regencyRepository.Get(id);
                return result;
            }
        }

        public bool Insert(RegencyVM regencyVM)
        {
            if (string.IsNullOrWhiteSpace(regencyVM.Name))
            {
                return status;
            }
            else
            {
                var result = _regencyRepository.Insert(regencyVM);
                return result;
            }
        }

        public bool Update(int id, RegencyVM regencyVM)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()) || string.IsNullOrWhiteSpace(regencyVM.Name))
            {
                return status;
            }
            else
            {
                var result = _regencyRepository.Update(id, regencyVM);
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
                var result = _regencyRepository.Delete(id);
                return result;
            }
        }
    }
}