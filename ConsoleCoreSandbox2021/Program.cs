using ConsoleCoreSandbox2021.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.IO;
using System.Linq;

namespace ConsoleCoreSandbox2021
{
    public class Program
    {


        public static void Main(string[] args)
        {
            using (var db = new AppDbContext())
            {
                Company microsoft = new Company { Name = "Microsoft" };
                Company google = new Company { Name = "Google" };
                db.Companies.AddRange(microsoft, google);

                User tom = new User { Name = "Tom", Age = 36, Company = microsoft };
                User bob = new User { Name = "Bob", Age = 39, Company = google };
                User alice = new User { Name = "Alice", Age = 28, Company = microsoft };
                User kate = new User { Name = "Kate", Age = 25, Company = google };

                db.Users.AddRange(tom, bob, alice, kate);
                db.SaveChanges();

                var users = db.Users
                    .Where(u => u.Age > 30)
                    .Union(db.Users.Where(u => u.Name.Contains("Kate")))
                    .ToList();

                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Name}, age {user.Age}");
                }
            }

            Console.Read();
        }
    }
}
