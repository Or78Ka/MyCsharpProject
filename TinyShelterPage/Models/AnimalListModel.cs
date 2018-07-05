using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TinyShelterPage.Models
{
    public class AnimalListModel
    {
        public List<EntryModel> Animal { get; set; }
        public int TotalAnimal { get; set; }
    }
}