using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TinyShelterPage.Models;

namespace TinyShelterPage
{
    public class Context : DbContext
    {
        public DbSet<Entry> Entries { get; set; }
    }
}