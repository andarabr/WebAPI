using System;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Base;
using DataAccess.ViewModels;

namespace DataAccess.Models
{
    [Table("TB_T_Contract")]
    public class Contract : BaseModel
    {
        public Contract() { }
        public DateTime? JoinDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string StatusContract { get; set; }
        public Employee Employee { get; set; }

        public Contract(ContractVM ContractVM)
        {
            this.JoinDate = ContractVM.JoinDate;
            this.EndDate = ContractVM.EndDate;
            this.StatusContract = ContractVM.StatusContract;
            this.CreateDate = DateTime.Now.ToLocalTime();
        }

        public void Update(ContractVM ContractVM)
        {
            this.JoinDate = ContractVM.JoinDate;
            this.EndDate = ContractVM.EndDate;
            this.StatusContract = ContractVM.StatusContract;
            this.UpdateDate = DateTime.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDeleted = true;
            this.DeleteDate = DateTime.Now.ToLocalTime();
        }
    }
}