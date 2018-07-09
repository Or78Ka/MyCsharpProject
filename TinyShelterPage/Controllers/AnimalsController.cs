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

        // get animal profile detail

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

        // add animal post action method, saves new entry to database

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

                if (ModelState.IsValidField("Age") && entryModel.Age <= 0 || entryModel.Age > 20)
                {
                    ModelState.AddModelError("Age", "The Age has to be between 0 - 20 years.");
                }

                if (ModelState.IsValidField("Date") && entryModel.Date > DateTime.Today)
                {
                    ModelState.AddModelError("Date", "The Date has to today or earlier");
                }

                if (ModelState.IsValidField("Date") && entryModel.Date > DateTime.Today)
                {
                    ModelState.AddModelError("Date", "The Date has to today or earlier");
                }

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

        // edit animal post action method, saves updated entry to database

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

                    if(ModelState.IsValidField("Age") && entryModel.Age <= 0 || entryModel.Age > 20 )
                        {
                            ModelState.AddModelError ("Age","The Age has to be between 0 - 20 years.");
                        }

                    if (ModelState.IsValidField("Date") && entryModel.Date > DateTime.Today)
                    {
                        ModelState.AddModelError("Date", "The Date has to today or earlier");
                    }


                    tinyShelterPageContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

         return new HttpNotFoundResult();
            
        }

        // delete animal post action method, deletes entry from database

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