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
            var animalList = new AnimalListModel
            {
                Animal = new List<EntryModel>
                {
                    new EntryModel {Id= 1, Name = "Puss", Type = "Cat", Age = 5, Description = "sweet kitty", Date = new DateTime(2018, 6, 10)},
                    new EntryModel {Id= 2, Name = "Oscar", Type = "Cat", Age = 7, Description = "adorable", Date = new DateTime(2018, 5, 18)},
                    new EntryModel {Id= 3, Name = "Tiger", Type = "Cat", Age = 3, Description = "hairball", Date = new DateTime(2018, 6, 14)},
                    new EntryModel {Id= 4, Name = "Lucy", Type = "Dog", Age = 5, Description = "lovely", Date = new DateTime(2018, 4, 25)},
                    new EntryModel {Id= 5, Name = "Max", Type = "Dog", Age = 8, Description = "cutie", Date = new DateTime(2018, 6, 25)},
                    new EntryModel {Id= 6, Name = "Buddy", Type = "Dog", Age = 1, Description = "babyface", Date = new DateTime(2018, 5, 12)}

                }

            };
                return View(animalList);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            return View();
        }
    }
}