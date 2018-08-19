using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndraAndCo.CompanyManagement.Library.CompanyResources.Staff;
using IndraAndCo.CompanyManagement.Library.CompanyResources;

namespace IndraAndCo.CompanyManagement.Library
{
    public class Company
    {
        public int projectIdCounter = 0;
        public List<Employee> Employees = new List<Employee>();
        public List<Software> Soft = new List<Software>();
        public List<Hardware> Hardware = new List<Hardware>();

        public Dictionary<string, List<Project>> CustomersProjects = new Dictionary<string, List<Project>>();

        
        public void CreateProject(Customer customer)
        {
            if (CustomersProjects.ContainsKey(customer.Name))
            {
                CustomersProjects[customer.Name].Add(new Project() {projectId = projectIdCounter});
            }
            else
            {
                CustomersProjects.Add(customer.Name, new List<Project>());
                CustomersProjects[customer.Name].Add(new Project() {projectId = projectIdCounter });
            }
        }
        public bool CanCompleteProject (Company compny, Customer c1)
        {
            Project lastProject = compny.CustomersProjects[c1.Name].LastOrDefault();
            bool possCompProj = false;
            Random rnd = new Random();
            foreach (Task t in lastProject.tasks)
            {
                possCompProj = false;
                foreach (Employee emp in compny.Employees)
                {
                    if (!(emp.Busy) & (t.typeOfSpecialist == emp.Position))
                    {
                        t.worker = emp;
                        t.worker.DaysToWork = rnd.Next(1, 5);
                        possCompProj = true;
                        emp.Busy = true;
                        break;
                    }
                }

                if (!possCompProj)
                {
                    foreach (Task tt in lastProject.tasks)
                    {
                        if (tt.worker != null)
                        {
                            tt.worker.Busy = false;
                            tt.worker.DaysToWork = 0;
                        }
                    }
                    break;
                }
            }
            return possCompProj;
        }
    }
}
