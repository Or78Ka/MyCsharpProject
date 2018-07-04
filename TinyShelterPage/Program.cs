using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TinyShelterPage.Models;

namespace TinyShelterPage
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                context.Entries.Add(new Entry()
                {
                    Name = "Fluffy",
                    //Type = (private enum)"Cat",
                    Age = 5,
                    Date = DateTime.Today


                });

                context.SaveChanges();

                var entries = context.Entries.ToList();
                foreach (var entry in entries)
                {
                    Console.WriteLine(entry.Name);
                }

                Console.ReadLine();
            }

            
        }
    }
}