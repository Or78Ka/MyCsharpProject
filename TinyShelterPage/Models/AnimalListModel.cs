using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TinyShelterPage.Models
{
    // the list of animals

    public class AnimalListModel
    {
        public List<EntryModel> Pet { get; set; }
        public int TotalPet { get; set; }
    }
}