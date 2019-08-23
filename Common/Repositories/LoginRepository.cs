using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.Repositories.Interfaces;
using DataAccess.Context;
using DataAccess.Models;
using DataAccess.ViewModels;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Common.Repositories
{
    public class LoginRepository : ILoginRepository
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

        public List<Login> Get()
        {
            var get = applicationContext.Login.Include("ListApplications").Where(x => x.IsDeleted == false).ToList();
            return get;
        }

        public Login Get(int id)
        {
            var getEmployee = applicationContext.Employee.SingleOrDefault(x => x.Id == id);
            var get = applicationContext
                .Login.Include("Employee")
                .Include("Employee.Village")
                .Include("Employee.Village.District")
                .Include("Employee.Village.District.Regency")
                .Include("Employee.Village.District.Regency.Province")
                .Include("Employee.Department")
                .Include("Employee.Department.Division")
                .Include("Employee.Manager")
                .Include("Employee.Religion")
                .Include("Employee.Role")
                .Include("ListApplications")
                .SingleOrDefault(x => x.IsDeleted == false && x.Id == id);
            return get;
        }

        public bool Insert(LoginVM loginVM)
        {
            var push = new Login(loginVM);
            applicationContext.Login.Add(push);
            var result = applicationContext.SaveChanges();
            return result > 0;
        }

        public bool Update(int id, LoginVM loginVM)
        {
            using (var conn = new SqlConnection(@"Data Source=DESKTOP-962I8LT;Initial Catalog=WebUserManagement;Integrated Security=False;User ID=sa;Password=sapassword;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                var cmd = new SqlCommand("[dbo].[Procedure]", conn);
                cmd.Parameters.Add("@LoginId", SqlDbType.Int, 12).Value = id; // I for Insert/ U for Update/ D 
                cmd.Parameters.Add("@ApplicationId", SqlDbType.Int, 12).Value = loginVM.ApplicationId;
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            var get = Get(id);
            get.Update(loginVM);
            applicationContext.Entry(get).State = EntityState.Modified;
            var result = applicationContext.SaveChanges();
            return result > 0;
        }

        public Login GetUserByLogin(string email, string password, int application)
        {
            //var get = applicationContext.Login.Include("ListApplications")
            //    .SingleOrDefault(x => x.IsDeleted == false && x.Email == email && x.Password == password &&
            //                x.ListApplications.Any(y => y.Id == application));
            var get = applicationContext
                .Login.Include("Employee")
                .Include("Employee.Village")
                .Include("Employee.Village.District")
                .Include("Employee.Village.District.Regency")
                .Include("Employee.Village.District.Regency.Province")
                .Include("Employee.Department")
                .Include("Employee.Department.Division")
                .Include("Employee.Manager")
                .Include("Employee.Religion")
                .Include("Employee.Role")
                .Include("ListApplications")
                .SingleOrDefault(x => x.IsDeleted == false && x.Email == email && x.Password == password && x.ListApplications.Any(y => y.Id == application));
            return get;
        }
    }
}