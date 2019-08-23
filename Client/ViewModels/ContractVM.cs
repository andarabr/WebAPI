using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.ViewModels
{
    public class ContractVM
    {
        public int Id { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string StatusContract { get; set; }
        public int EmployeeId { get; set; }

    }
}