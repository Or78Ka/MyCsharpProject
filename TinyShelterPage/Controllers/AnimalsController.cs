using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TinyShelterPage.Models;

namespace TinyShelterPage.Controllers
{
    public class AnimalsController : Controller
    {

            public static List<Animal> Pet = new List<Animal>
                {
                    new Animal {AnimalId= 1, Name = "Puss", Type = "Cat", Age = 5, Description = "sweet kitty", Date = new DateTime(2018, 6, 10)},
                    new Animal {AnimalId= 2, Name = "Oscar", Type = "Cat", Age = 7, Description = "adorable", Date = new DateTime(2018, 5, 18)},
                    new Animal {AnimalId= 3, Name = "Tiger", Type = "Cat", Age = 3, Description = "hairball", Date = new DateTime(2018, 6, 14)},
                    new Animal {AnimalId= 4, Name = "Lucy", Type = "Dog", Age = 5, Description = "lovely", Date = new DateTime(2018, 4, 25)},
                    new Animal {AnimalId= 5, Name = "Max", Type = "Dog", Age = 8, Description = "cutie", Date = new DateTime(2018, 6, 25)},
                    new Animal {AnimalId= 6, Name = "Buddy", Type = "Dog", Age = 1, Description = "babyface", Date = new DateTime(2018, 5, 12)}

                };


        // GET: Animals
        public ActionResult Index()
        {
            var animalList = new AnimalListModel
            {
                Pet = Pet.Select(p => new EntryModel
                {
                    AnimalId = p.AnimalId,
                    Name = p.Name,
                    Type = p.Type,
                    Age = p.Age,
                    Description = p.Description,
                    Date = p.Date
                }).ToList()

            };

            animalList.TotalPet = animalList.Pet.Count;

            return View(animalList);
        }

        public ActionResult AnimalDetail(int id)
        {
            var animal = Pet.SingleOrDefault(p => p.AnimalId == id);
            if (animal != null)
            {
                var entryModel = new EntryModel
                {
                    AnimalId = animal.AnimalId,
                    Name = animal.Name,
                    Type = animal.Type,
                    Age = animal.Age,
                    Description = animal.Description,
                    Date = animal.Date

                };

                return View(entryModel);
            }

            return new HttpNotFoundResult();
        }



        public ActionResult AnimalAdd()
        {
            var entryModel = new EntryModel();

            return View("AddEditAnimal", entryModel);
        }


        [HttpPost]
        public ActionResult AddAnimal(EntryModel entryModel)
        {
            var nextAnimalId = Pet.Max(p => p.AnimalId) + 1;

            var animal = new Animal
            {
                AnimalId = nextAnimalId,
                Name = entryModel.Name,
                Type = entryModel.Type,
                Age = entryModel.Age,
                Description = entryModel.Description,
                Date = entryModel.Date
            };

            Pet.Add(animal);

            return RedirectToAction("Index");
        }


        public ActionResult AnimalEdit(int id)
        {
            var animal = Pet.SingleOrDefault(p => p.AnimalId == id);
            if (animal != null)
            {
                var entryModel = new EntryModel
                {
                    AnimalId = animal.AnimalId,
                    Name = animal.Name,
                    Type = animal.Type,
                    Age = animal.Age,
                    Description = animal.Description,
                    Date = animal.Date
                };

                return View("AddEditAnimal", entryModel);
            }

            return new HttpNotFoundResult();
        }


        [HttpPost]
        public ActionResult EditAnimal(EntryModel entryModel)
        {
            var animal = Pet.SingleOrDefault(p => p.AnimalId == entryModel.AnimalId);

            if (animal != null)
            {
                animal.Name = entryModel.Name;
                animal.Type = entryModel.Type;
                animal.Age = entryModel.Age;
                animal.Description = entryModel.Description;
                animal.Date = entryModel.Date;

                return RedirectToAction("Index");
            }

            return new HttpNotFoundResult();
        }


        [HttpPost]
        public ActionResult DeleteAnimal(EntryModel entryModel)
        {
            var animal = Pet.SingleOrDefault(p => p.AnimalId == entryModel.AnimalId);

            if (animal != null)
            {
                Pet.Remove(animal);

                return RedirectToAction("Index");
            }

            return new HttpNotFoundResult();
        }






        
    }
}