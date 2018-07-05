using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TinyShelterPage.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public double Age { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}