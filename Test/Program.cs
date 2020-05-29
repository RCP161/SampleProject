using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Catel.IoC;
using Company.Basic.Core.Models;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Register();
            Test();
        }

        private static void Test()
        {
            Person person = new Person();
            person.Name = "Hans";
            person.Surename = "Mustermann";

            ServiceLocator.Default.ResolveType<Company.Basic.Core.Services.IPersonService>().SavePerson(person);

            long id = person.Id;


            Person p = ServiceLocator.Default.ResolveType<Company.Basic.Core.Services.IPersonService>().GetPersonById(id);

            Console.WriteLine(p.Name + " " + p.Surename);
            Console.ReadLine();
        }

        private static void Register()
        {
        }
    }
}
