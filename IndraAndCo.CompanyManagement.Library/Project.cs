using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndraAndCo.CompanyManagement.Library.CompanyResources.Staff;

namespace IndraAndCo.CompanyManagement.Library

{
    public class Project
    {
        public int projectId;
        public List<Task> tasks = new List<Task>();
        public Project()
        {
             tasks = Enumerable.Range(1, 3)
                .Select(i => new Task())
                .ToList();
            Random rnd = new Random();
            //int specialtyTypeCount = 3;
            //foreach (Task t in tasks)
            //{
            //    t.typeOfSpecialist = (Specialty)rnd.Next(specialtyTypeCount);
            //}
        }
        public Customer customer;


    }
}
