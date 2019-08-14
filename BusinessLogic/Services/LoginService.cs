using System.Collections.Generic;
using BusinessLogic.Services.Interfaces;
using Common.Repositories.Interfaces;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Services
{
    public class LoginService : ILoginService
    {
        bool status = false;

        private ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public List<Login> Get()
        {
            var result = _loginRepository.Get();
            return result;
        }

        public Login Get(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return null;
            }
            else
            {
                var result = _loginRepository.Get(id);
                return result;
            }
        }

        public Login GetUserByLogin(LoginVM loginVM)
        {
            if (string.IsNullOrWhiteSpace(loginVM.Email) || string.IsNullOrWhiteSpace(loginVM.Password) || string.IsNullOrWhiteSpace(loginVM.ApplicationId.ToString()))
            {
                return null;
            }
            else
            {
                var result = _loginRepository.GetUserByLogin(loginVM.Email, loginVM.Password, loginVM.ApplicationId);
                return result;
            }
        }

        public bool Insert(LoginVM loginVM)
        {
            if (string.IsNullOrWhiteSpace(loginVM.Email) || string.IsNullOrWhiteSpace(loginVM.Password))
            {
                return status;
            }
            else
            {
                var result = _loginRepository.Insert(loginVM);
                return result;
            }
        }

        public bool Update(int id, LoginVM loginVM)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()) || string.IsNullOrWhiteSpace(loginVM.Email) || string.IsNullOrWhiteSpace(loginVM.Password))
            {
                return status;
            }
            else
            {
                var result = _loginRepository.Update(id, loginVM);
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
                var result = _loginRepository.Delete(id);
                return result;
            }
        }
    }
}