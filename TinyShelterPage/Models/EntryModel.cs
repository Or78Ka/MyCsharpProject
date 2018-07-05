using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TinyShelterPage.Models
{
    // represents a new animal profile at intake

    public class EntryModel
    {




        //// default contstructor
        //public Entry()
        //{

        //}

        //// constructor to create entries

        //    // id The ID for the entry
        //    // name is the Pet Name
        //    // type is radio button to choose Dog or Cat
        //    // age is a dropdown to select age range
        //    // description is an optional field with more info on animal
        //    // date is the shelter intake date to help calculate days spent in shelter

        //public Entry (int id, int year, int month, int day, double age, AnimalType type = AnimalType.Dog, string name = null, string description = null)
        //{
        //    Id = id;
        //    Name = name;
        //    Type = type;
        //    Age = age;
        //    Description = description;
        //    Date = new DateTime(year, month, day);

        //}

        public int? AnimalId { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public double Age { get; set; }

        public string Description { get; set; }

        [DisplayName("Intake date")]
        public DateTime Date { get; set; }
    }
}