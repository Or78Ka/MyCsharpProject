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


        // GET: Animals
        public ActionResult Index()
        {
            using (var tinyShelterPageContext = new TinyShelterPageContext())
            {
               var animalList = new AnimalListModel
                {
                    Pet = tinyShelterPageContext.Pet.Select(p => new EntryModel
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
        }

        public ActionResult AnimalDetail(int id)
        {
            using (var tinyShelterPageContext = new TinyShelterPageContext())
            { 
                var animal = tinyShelterPageContext.Pet.SingleOrDefault(p => p.AnimalId == id);
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
            using (var tinyShelterPageContext = new TinyShelterPageContext())
            { 

                var animal = new Animal
                {
                    Name = entryModel.Name,
                    Type = entryModel.Type,
                    Age = entryModel.Age,
                    Description = entryModel.Description,
                    Date = entryModel.Date
                };

                tinyShelterPageContext.Pet.Add(animal);
                tinyShelterPageContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public ActionResult AnimalEdit(int id)
        {
            using (var tinyShelterPageContext = new TinyShelterPageContext())
            {
                var animal = tinyShelterPageContext.Pet.SingleOrDefault(p => p.AnimalId == id);
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
            }

            return new HttpNotFoundResult();
        }


        [HttpPost]
        public ActionResult EditAnimal(EntryModel entryModel)
        {
            using (var tinyShelterPageContext = new TinyShelterPageContext())
            {
                var animal = tinyShelterPageContext.Pet.SingleOrDefault(p => p.AnimalId == entryModel.AnimalId);

                if (animal != null)
                {
                    animal.Name = entryModel.Name;
                    animal.Type = entryModel.Type;
                    animal.Age = entryModel.Age;
                    animal.Description = entryModel.Description;
                    animal.Date = entryModel.Date;
                    tinyShelterPageContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

         return new HttpNotFoundResult();
            
        }


        [HttpPost]
        public ActionResult DeleteAnimal(EntryModel entryModel)
        {
            using (var tinyShelterPageContext = new TinyShelterPageContext())
            {
                var animal = tinyShelterPageContext.Pet.SingleOrDefault(p => p.AnimalId == entryModel.AnimalId);

                if (animal != null)
                {
                    tinyShelterPageContext.Pet.Remove(animal);
                    tinyShelterPageContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }






        
    }
}