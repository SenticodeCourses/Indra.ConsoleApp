using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndraAndCo.CompanyManagement.Library;
using IndraAndCo.CompanyManagement.Library.CompanyResources.Staff;
using IndraAndCo.CompanyManagement.Library.CompanyResources;

namespace IndraAndCo.CompanyManagement.App
{
    public partial class Program
    {
        public static void AddProject(Company company)
        {
            company.projectIdCounter++;
            Console.WriteLine("Input customer name:");
            Customer c1 = new Customer();
            c1.Name = Console.ReadLine();
            company.CreateProject(c1);
            if (company.CanCompleteProject(company, c1))
            {
                Console.WriteLine("We take this project.\n");

            }
            else
            {
                Console.WriteLine("Sorry. We can't take this project.");
                company.CustomersProjects[c1.Name].RemoveAt(company.CustomersProjects[c1.Name].Count - 1);
            }
            Console.ReadLine();
        }
        public static void InfoAboutOurSpesialists(Company company)
        {
            foreach (Employee emp in company.Employees)
            {
                Console.WriteLine(emp.Name + " " + (emp.Busy ? "Busy" : "Free") + "  " + emp.Position + "  " + emp.DaysToWork);
            }
            Console.ReadLine();
        }
        public static void InfoAboutProjectsInProcess(Company company)
        {
            foreach (string cust in company.CustomersProjects.Keys)
            {
                Console.WriteLine("{0} have a project(s):\n", cust);
                foreach (Project proj in company.CustomersProjects[cust])
                {
                    Console.WriteLine("Project ID: {0}", proj.projectId);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        public static void NextDayIteration(Company company)
        {
            foreach (Employee emp in company.Employees)
            {
                if (emp.DaysToWork > 0)
                {
                    emp.DaysToWork--;
                    if (emp.DaysToWork == 0) emp.Busy = false;
                }
            }
            bool projectCompliteFlag;
            foreach (string str in company.CustomersProjects.Keys)
            {
                foreach (Project proj in company.CustomersProjects[str])
                {
                    projectCompliteFlag = true;
                    foreach (Library.Task t in proj.tasks)
                    {
                        if (t.worker.DaysToWork > 0) projectCompliteFlag = false;
                    }
                    if (projectCompliteFlag)
                    {
                        Console.WriteLine(
                            "Congratulations! We complite project:\nCustomer {0}: Project ID:{1}.", str, proj.projectId);
                        company.CustomersProjects[str].Remove(proj);
                        Console.ReadLine();
                        break;
                    }
                }
            }
        }
    }

}
