using System;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Base;
using DataAccess.ViewModels;

namespace DataAccess.Models
{
    [Table("TB_M_Religions")]
    public class Religion : BaseModel
    {
        public Religion() { }

        public Religion(ReligionVM religionVM)
        {
            this.Name = religionVM.Name;
            this.CreateDate = DateTime.Now.ToLocalTime();
        }

        public void Update(ReligionVM religionVM)
        {
            this.Name = religionVM.Name;
            this.UpdateDate = DateTime.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDeleted = true;
            this.DeleteDate = DateTime.Now.ToLocalTime();
        }

        public string Name { get; set; }
    }
}