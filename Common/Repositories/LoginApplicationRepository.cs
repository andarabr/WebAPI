using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.Repositories.Interfaces;
using DataAccess.Context;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repositories
{
    public class LoginApplicationRepository : ILoginApplicationRepository
    {
        private bool status = false;
        private ApplicationContext applicationContext = new ApplicationContext();
        public bool Delete(int id)
        {
            var get = Get(id);
            get.Delete();
            applicationContext.Entry(get).State = EntityState.Modified;
            var result = applicationContext.SaveChanges();
            return result > 0;
        }

        public List<LoginApplication> Get()
        {
            var get = applicationContext.LoginApplication.Include("Login").Include("Application").Where(x => x.IsDeleted == false).ToList();
            return get;
        }

        public LoginApplication Get(int id)
        {
            var get = applicationContext.LoginApplication.SingleOrDefault(x => x.IsDeleted == false && x.Id == id);
            return get;
        }

        public bool Insert(LoginApplicationVM loginApplicationVM)
        {
            var push = new LoginApplication(loginApplicationVM);
            //ini nih foreign key
            var getLogin = applicationContext.Login.SingleOrDefault(x => x.IsDeleted == false && x.Id == loginApplicationVM.LoginId);
            push.Login = getLogin;
            var getApplication = applicationContext.Application.SingleOrDefault(x => x.IsDeleted == false && x.Id == loginApplicationVM.ApplicationId);
            push.Application = getApplication;
            applicationContext.LoginApplication.Add(push);
            var result = applicationContext.SaveChanges();
            return result > 0;
        }

        public bool Update(int id, LoginApplicationVM loginApplicationVM)
        {
            var get = Get(id);
            var getLogin = applicationContext.Login.SingleOrDefault(x => x.IsDeleted == false && x.Id == loginApplicationVM.LoginId);
            get.Login = getLogin;
            var getApplication = applicationContext.Application.SingleOrDefault(x => x.IsDeleted == false && x.Id == loginApplicationVM.ApplicationId);
            get.Application = getApplication;
            get.Update(loginApplicationVM);
            applicationContext.Entry(get).State = EntityState.Modified;
            var result = applicationContext.SaveChanges();
            return result > 0;
        }
    }
}