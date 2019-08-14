using System;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Base;
using DataAccess.ViewModels;

namespace DataAccess.Models
{
    [Table("TB_M_Provinces")]
    public class Province : BaseModel
    {
        public Province() { }

        public Province(ProvinceVM provinceVM)
        {
            this.Name = provinceVM.Name;
            this.CreateDate = DateTime.Now.ToLocalTime();
        }

        public void Update(ProvinceVM provinceVM)
        {
            this.Name = provinceVM.Name;
            this.UpdateDate = DateTime.Now.ToLocalTime();
        }
        //comment ajah
        public void Delete()
        {
            this.IsDeleted = true;
            this.DeleteDate = DateTime.Now.ToLocalTime();
        }

        public string Name { get; set; }
    }
}