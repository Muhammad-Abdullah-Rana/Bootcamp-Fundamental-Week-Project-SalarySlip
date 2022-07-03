using System;

namespace Bootcamp_Fundamental_Week_Project_Salary_Slip
{
    abstract class SalarySlip
    {
        //salary does not change
        private const int baseSalary = 1500;
        public int getGrossSalary()
        {
            return baseSalary + getAllownce();
        }
        //getAllownce function gets all allownes. This will allow addition of further alloances
        //in child class(es) without change in other classess if needed, facilitating scalability
        protected abstract int getAllownce();
        protected abstract int getMedicalAllownce();
        protected abstract int getFuelAllownce();
    }
    class EngineerSalary : SalarySlip
    {
        protected override int getAllownce() { return getMedicalAllownce() + getFuelAllownce(); }
        protected override int getMedicalAllownce(){return 500; }
        protected override int getFuelAllownce() { return 100; }

    }
    class ManagerSalary : SalarySlip
    {
        protected override int getAllownce() { return getMedicalAllownce() + getFuelAllownce(); }
        protected override int getMedicalAllownce() { return 1000; }
        protected override int getFuelAllownce() { return 250; }
    }
    class AnalyistSalary : SalarySlip
    { 
        protected override int getAllownce() { return getMedicalAllownce() + getFuelAllownce(); }
        protected override int getMedicalAllownce() { return 800; }
        protected override int getFuelAllownce() { return 150; }
    }

    class Program
    {
        static void Main()
        {
            char input;
            bool exitProgram = false;
            Console.WriteLine("Employee salary calculator.");

            //Made a simple UI on the CLI to make the program more presentable and loop according to will
            while (!exitProgram)
            {
                Console.WriteLine(Environment.NewLine + "Press e, m or a to get gross salary of engineer, manager or analyst respectively.");
                Console.Write("Input : ");
                input = Console.ReadKey().KeyChar;

                switch (input)
                {
                    case 'e':case 'E':
                        SalarySlip engineer = new EngineerSalary();
                        Console.WriteLine(Environment.NewLine + "Enigineer gross salary : " + engineer.getGrossSalary());
                        break;

                    case 'm':case 'M':
                        SalarySlip manager = new ManagerSalary();
                        Console.WriteLine(Environment.NewLine + "Manager gross salary : " + manager.getGrossSalary());
                        break;

                    case 'a':case 'A':
                        SalarySlip analist = new AnalyistSalary();
                        Console.WriteLine(Environment.NewLine + "Analyst gross salary : " + analist.getGrossSalary());
                        break;

                    default:
                        Console.WriteLine(Environment.NewLine + Environment.NewLine + "Wrong Input!");
                        break;
                }

                Console.Write(Environment.NewLine + "Do you want to get gross salary of another employee designation? [y/n] : ");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();

                //If wrong input given for above question
                while(input != 'y' && input != 'n' && input != 'Y' && input != 'N')
                {
                    Console.WriteLine(Environment.NewLine + Environment.NewLine + "Wrong input!");
                    Console.Write(Environment.NewLine + "Do you want to get gross salary of another employee designation? [y/n] : ");
                    input = Console.ReadKey().KeyChar;
                }

                if(input == 'n' || input == 'N')
                {
                    exitProgram = true;
                }
            }
        }
    }
}