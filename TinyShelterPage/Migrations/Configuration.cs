using TinyShelterPage.Models;
using System.Data.Entity.Migrations;
using System;

namespace TinyShelterPage.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<TinyShelterPageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TinyShelterPageContext context)
        {
            context.Pet.AddOrUpdate(
                p => p.AnimalId,

                new Animal { AnimalId = 1, Name = "Puss", Type = "Cat", Age = 5, Description = "sweet kitty", Date = new DateTime(2018, 6, 10) },
                new Animal { AnimalId = 2, Name = "Oscar", Type = "Cat", Age = 7, Description = "adorable", Date = new DateTime(2018, 5, 18) },
                new Animal { AnimalId = 3, Name = "Tiger", Type = "Cat", Age = 3, Description = "hair-ball", Date = new DateTime(2018, 6, 14) },
                new Animal { AnimalId = 4, Name = "Lucy", Type = "Dog", Age = 5, Description = "lovely", Date = new DateTime(2018, 4, 25) },
                new Animal { AnimalId = 5, Name = "Max", Type = "Dog", Age = 8, Description = "cutie", Date = new DateTime(2018, 6, 25) },
                new Animal { AnimalId = 6, Name = "Buddy", Type = "Dog", Age = 1, Description = "baby-face", Date = new DateTime(2018, 5, 12) }

                );

        }
    }
}
