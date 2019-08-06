using System;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Base;
using DataAccess.ViewModels;

namespace DataAccess.Models
{
    [Table("TB_M_Village")]
    public class Village : BaseModel
    {
        public Village() { }
        public string Name { get; set; }

        public District District { get; set; }

        public Village(VillageVM villageVM)
        {
            this.Name = villageVM.Name;
            this.CreateDate = DateTime.Now.ToLocalTime();
        }

        public void Update(VillageVM villageVM)
        {
            this.Name = villageVM.Name;
            this.UpdateDate = DateTime.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDeleted = true;
            this.DeleteDate = DateTime.Now.ToLocalTime();
        }
    }
}