using System.Collections.Generic;
using System.ComponentModel;
using BusinessLogic.Services.Interfaces;
using Common.Repositories;
using Common.Repositories.Interfaces;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Services
{
    public class RoleService : IRoleService
    {
        bool status = false;

        private IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public RoleService() { }

        public List<Role> Get()
        {
            var result = _roleRepository.Get();
            return result;
        }

        public Role Get(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return null;
            }
            else
            {
                var result = _roleRepository.Get(id);
                return result;
            }
        }
        
        public bool Insert(RoleVM roleVM)
        {
            if (string.IsNullOrWhiteSpace(roleVM.Name))
            {
                return status;
            }
            else
            {
                var result = _roleRepository.Insert(roleVM);
                return result;
            }
        }

        public bool Update(int id, RoleVM roleVM)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()) || string.IsNullOrWhiteSpace(roleVM.Name))
            {
                return status;
            }
            else
            {
                var result = _roleRepository.Update(id, roleVM);
                return result;
            }
        }

        public bool Delete(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return status;
            }
            else
            {
                var result = _roleRepository.Delete(id);
                return result;
            }
        }
    }
}