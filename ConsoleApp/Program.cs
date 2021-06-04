using Dal;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                context.Initialize(false);

                foreach (var item in context.People.AsNoTracking())
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName}");
                }

            }
        }
  
    }

}
