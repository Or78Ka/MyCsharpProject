using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TinyShelterPage.Models
{
    // represents a new animal profile at intake

    public class EntryModel
    {



        //    // id The ID for the entry
        //    // name is the Pet Name
        //    // type is radio button to choose Dog or Cat
        //    // age is a dropdown to select age range
        //    // description is an optional field with more info on animal
        //    // date is the shelter intake date to help calculate days spent in shelter


        public int? AnimalId { get; set; }

      
        public string Name { get; set; }

       
        public string Type { get; set; }

        public double Age { get; set; }

        
        public string Description { get; set; }

        [DisplayName("Intake date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }
    }
}