using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCourseApp.Models
{
    public class SeedDatabase
    {
        //dependence injection (bagimlilik oluşturduk)
        public static void Seed(DbContext context)
        {
            if (!context.Database.GetPendingMigrations().Any())
            {
                if (context is DbContext)
                {
                    DataContext _context = context as DataContext;
                    if (!_context.Instructors.Any())//tablonun ici bosmu degil mi ?
                    {
                        _context.Instructors.AddRange(Instructors);
                    }
                    if (!_context.Courses.Any())
                    {
                        _context.Courses.AddRange(Courses);
                    }
                }
            }
            context.SaveChanges();
        }

        private static Course[] Courses
        {
            get
            {
                Course[] courses = new Course[]
                {

                   new Course() {Name="Html",Price=100,isActive=true,Instructor=Instructors[0] },
                   new Course() {Name="Css",Price=500,isActive=true,Instructor=Instructors[1] },
                   new Course() {Name="JavaScript",Price=200,isActive=true,Instructor=Instructors[2] },
                   new Course() {Name="NodeJs",Price=300,isActive=true,Instructor=Instructors[3] },
                };
                return courses;
            }
        }

        private static Instructor[] Instructors =
        {
            new Instructor(){Name="Safak",Contact=new Contact()
            { Email="safak@gmail.com", Phone="123", Address=new Address(){City="Samsun", Country="Turkey",Text="Bafra" }} },
              new Instructor(){Name="Safak",Contact=new Contact()
            { Email="adil@gmail.com", Phone="123", Address=new Address(){City="Gaziantep", Country="Turkey",Text="Sahinbey" }} },
                new Instructor(){Name="Safak",Contact=new Contact()
            { Email="habis@gmail.com", Phone="123", Address=new Address(){City="Giresun", Country="Turkey",Text="Bulancak" }} },
                  new Instructor(){Name="Safak",Contact=new Contact()
            { Email="elif@gmail.com", Phone="123", Address=new Address(){City="Ordu", Country="Turkey",Text="Kabataş" }} }


        };

    }
}
