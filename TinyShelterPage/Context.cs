using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TinyShelterPage.Models;

namespace TinyShelterPage
{
    public class TinyShelterPageContext : DbContext
    {
        public TinyShelterPageContext() : base("name=TinyShelterPage") { }

        public virtual DbSet<Animal> Pet { get; set; }
    }
}