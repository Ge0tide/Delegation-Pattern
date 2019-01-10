using System;
using System.Threading;

namespace Delegation_Pattern
{
    public class Employee
    {
        private string name;
        private string[] nameArray = { "Jonathan", "Katie", "Max", "Sophie", "Arthur", "Marissa" };
        public Random rnd;

        public Employee ()
        {
            rnd = new Random();
            this.name = nameArray[rnd.Next(0, this.nameArray.Length - 1)];
        }

        public string Name()
        {
            return this.name;
        }
    }
    public class Role
    {
        protected Employee employee;
        protected string role;
        protected string story;

        public Role(Employee employee)
        {
            this.employee = employee;
        }

        public string ReturnRole()
        {
            return this.role;
        }

        public string ReturnStory()
        {
            return this.story;
        }
    }
    public class Chef : Role
    {
        private string[] actions = { "succeeded to cook a perfectly juicy steak!", "was able to chop onions without shedding a tear!", "is busy cooking shellfish" };

        public Chef(Employee employee) : base(employee)
        {
            this.role = "Chef";
            story = $"{this.employee.Name()} became a {this.role} and {this.actions[employee.rnd.Next(0, this.actions.Length - 1)]}";
        }
    }
    public class Programmer : Role
    {
        private string[] actions = { "successfully completed a bit-wise shift", "managed to create a 'string' in C!", "needs more coffee" };

        public Programmer(Employee employee) : base(employee)
        {
            this.role = "Programmer";
            story = $"{this.employee.Name()} became a {this.role} and {this.actions[employee.rnd.Next(0, this.actions.Length - 1)]}";
        }
    }
    class MainClass
    {
        public static Role AssignRole(Employee employee)
        {
            int max = 100;
            int rand = employee.rnd.Next(0, max);

            if (rand <= max / 2)
            {
                return new Programmer(employee);
            }
            else if (rand > max / 2)
            {
                return new Chef(employee);   
            }

            return null;
        }
        public static void Main(string[] args)
        {
            int input = 0;

            Console.WriteLine("How many role switches would you like?");

            try
            {
                input = int.Parse(Console.ReadLine());

                if (input < 0)
                {
                    throw new Exception("Only positive integers are allowed!");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            for (int i = 0; i < input; i++)
            {
                Thread.Sleep(2500);
                Employee identity = new Employee();
                Console.WriteLine(AssignRole(identity).ReturnStory());
            }
        }
    }
}
