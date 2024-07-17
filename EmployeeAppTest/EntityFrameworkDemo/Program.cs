
using EntityFrameworkDemo.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EntityFrameworkDemo
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            using (var context = new EFCoreDbContext())
            {
                var derivedEntityA = new DerivedEntityA { PropertyA = "SomeValueA", CommonProperty = "SomeCommonValueA" };
                var derivedEntityB = new DerivedEntityB { PropertyB = "SomeValueB", CommonProperty = "SomeCommonValueB" };
                context.BaseEntites.AddRange(derivedEntityA, derivedEntityB);
                context.SaveChanges();
                Console.WriteLine("Entities are Added");
            }
        }

   
    }
}