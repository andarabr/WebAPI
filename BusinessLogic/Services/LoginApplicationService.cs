using System.Collections.Generic;
using BusinessLogic.Services.Interfaces;
using Common.Repositories.Interfaces;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Services
{
    public class LoginApplicationService : ILoginApplicationService
    {
        bool status = false;

        private ILoginApplicationRepository _loginApplicationRepository;

        public LoginApplicationService(ILoginApplicationRepository loginApplicationRepository)
        {
            _loginApplicationRepository = loginApplicationRepository;
        }

        public List<LoginApplication> Get()
        {
            var result = _loginApplicationRepository.Get();
            return result;
        }

        public LoginApplication Get(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return null;
            }
            else
            {
                var result = _loginApplicationRepository.Get(id);
                return result;
            }
        }

        public bool Insert(LoginApplicationVM loginApplicationVM)
        {
            if (string.IsNullOrWhiteSpace(loginApplicationVM.LoginId.ToString()))
            {
                return status;
            }
            else
            {
                var result = _loginApplicationRepository.Insert(loginApplicationVM);
                return result;
            }
        }

        public bool Update(int id, LoginApplicationVM loginApplicationVM)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()) || string.IsNullOrWhiteSpace(loginApplicationVM.LoginId.ToString()))
            {
                return status;
            }
            else
            {
                var result = _loginApplicationRepository.Update(id, loginApplicationVM);
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
                var result = _loginApplicationRepository.Delete(id);
                return result;
            }
        }
    }
}