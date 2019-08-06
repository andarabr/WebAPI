using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModels
{
    public class DepartmentVM
    {
        public string Name { get; set; }
        public int DivisionId { get; set; }

        public DepartmentVM() { }

        public DepartmentVM(string name, int divisionid)
        {
            this.Name = name;
            this.DivisionId = divisionid;
        }

        public void Update(string name, int divisionid)
        {
            this.Name = name;
            this.DivisionId = divisionid;
        }
    }
}
