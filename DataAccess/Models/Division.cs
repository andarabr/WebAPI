using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Base;
using DataAccess.ViewModels;

namespace DataAccess.Models
{
    [Table("TB_M_Division")]
    public class Division : BaseModel
    {
        public Division() { }

        public Division(DivisionVM divisionVM)
        {
            this.Name = divisionVM.Name;
            this.CreateDate = DateTime.Now.ToLocalTime();
        }

        public void Update(DivisionVM divisionVM)
        {
            this.Name = divisionVM.Name;
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
