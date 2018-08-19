using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndraAndCo.CompanyManagement.Library.CompanyResources.Staff
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Specialty Position { get; set; }
        public Sex Sex { get; set; }
        public bool Busy { get; set; }
        public int DaysToWork;
    }
}
