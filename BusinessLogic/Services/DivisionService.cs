using System.Collections.Generic;
using BusinessLogic.Services.Interfaces;
using Common.Repositories.Interfaces;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Services
{
    public class DivisionService : IDivisionService
    {
        bool status = false;

        private IDivisionRepository _divisionRepository;

        public DivisionService(IDivisionRepository divisionRepository)
        {
            _divisionRepository = divisionRepository;
        }

        public List<Division> Get()
        {
            var result = _divisionRepository.Get();
            return result;
        }

        public Division Get(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return null;
            }
            else
            {
                var result = _divisionRepository.Get(id);
                return result;
            }
        }

        public bool Insert(DivisionVM divisionVM)
        {
            if (string.IsNullOrWhiteSpace(divisionVM.Name))
            {
                return status;
            }
            else
            {
                var result = _divisionRepository.Insert(divisionVM);
                return result;
            }
        }

        public bool Update(int id, DivisionVM divisionVM)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()) || string.IsNullOrWhiteSpace(divisionVM.Name))
            {
                return status;
            }
            else
            {
                var result = _divisionRepository.Update(id, divisionVM);
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
                var result = _divisionRepository.Delete(id);
                return result;
            }
        }
    }
}