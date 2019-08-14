using System;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Base;
using DataAccess.ViewModels;

namespace DataAccess.Models
{
    [Table("TB_M_Districts")]
    public class District : BaseModel
    {
        public District() { }
        public string Name { get; set; }

        public Regency Regency { get; set; }

        public District(DistrictVM districtVM)
        {
            this.Name = districtVM.Name;
            this.CreateDate = DateTime.Now.ToLocalTime();
        }

        public void Update(DistrictVM districtVM)
        {
            this.Name = districtVM.Name;
            this.UpdateDate = DateTime.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDeleted = true;
            this.DeleteDate = DateTime.Now.ToLocalTime();
        }
    }
}