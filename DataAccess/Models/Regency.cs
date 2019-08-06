using System;
using Core.Base;
using DataAccess.ViewModels;

namespace DataAccess.Models
{
    public class Regency : BaseModel
    {
        public Regency() { }
        public string Name { get; set; }

        public Province Province { get; set; }

        public Regency(RegencyVM regencyVM)
        {
            this.Name = regencyVM.Name;
            this.CreateDate = DateTime.Now.ToLocalTime();
        }

        public void Update(RegencyVM regencyVM)
        {
            this.Name = regencyVM.Name;
            this.UpdateDate = DateTime.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDeleted = true;
            this.DeleteDate = DateTime.Now.ToLocalTime();
        }
    }
}