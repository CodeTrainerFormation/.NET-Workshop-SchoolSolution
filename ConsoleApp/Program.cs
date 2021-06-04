using Dal;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SchoolContext();

            context.Initialize(true);

            foreach (var item in context.People)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
        }
    }

}
