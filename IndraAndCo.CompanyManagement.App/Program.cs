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

        static void Main(string[] args)
        {

            Company company = new Company()
            {
                 Employees = new List<Employee>()
                {
                    new Specialist {Age = 22, Name = "Bob", Position = Specialty.Developer, Sex = Sex.Male, Busy = false},
                    new Head {Age = 32, Name = "Marta", Position = Specialty.Devops, Sex = Sex.Female, Busy = false},
                    new Specialist {Age = 27, Name = "Paul", Position = Specialty.Tester, Sex = Sex.Male, Busy = false},
                    new Head {Age = 23, Name = "Vanessa", Position = Specialty.Devops, Sex = Sex.Female, Busy = false},
                    new Specialist {Age = 24, Name = "Mark", Position = Specialty.Tester, Sex = Sex.Male, Busy = false},
                    new Head {Age = 21, Name = "Anna", Position = Specialty.Devops, Sex = Sex.Female, Busy = false},
                    new Specialist {Age = 27, Name = "Tina", Position = Specialty.Developer, Sex = Sex.Female, Busy = false},
                    new Head {Age = 34, Name = "Violetta", Position = Specialty.Developer, Sex = Sex.Female, Busy = false},
                    new Specialist {Age = 37, Name = "Benjamin", Position = Specialty.Developer, Sex = Sex.Male, Busy = false},
                    new Head {Age = 20, Name = "Ingrit", Position = Specialty.Devops, Sex = Sex.Female, Busy = false},
                    new Specialist {Age = 29, Name = "Tom", Position = Specialty.Developer, Sex = Sex.Male, Busy = false},
                    new Head {Age = 30, Name = "Eva", Position = Specialty.Devops, Sex = Sex.Female, Busy = false},
                    new Specialist {Age = 33, Name = "Den", Position = Specialty.Tester, Sex = Sex.Male, Busy = false}
                },
                Soft = Enumerable.Range(1, 20)
                    .Select(i => new Software())
                    .ToList(),
                Hardware = Enumerable.Range(1, 10)
                    .Select(i => new Hardware())
                    .ToList()

            };

            string controlString;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Add Customer (project).\n2 - Info about project(s) in process.\n" +
                    "3 - Info about our specialists.\n4 - Next day.\n0 - Exit programm.");
                controlString = Console.ReadLine().Trim();
                if (controlString == "1") AddProject(company);
                if (controlString == "2") InfoAboutProjectsInProcess(company);
                if (controlString == "3") InfoAboutOurSpesialists(company);
                if (controlString == "4") NextDayIteration(company);
            }
            while (controlString != "0");

        }
    }
}
