﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TinyShelterPage.Models;

namespace TinyShelterPage
{
    public class AnimalsToAdoptContext : DbContext
    {
        public DbSet<EntryModel> Entries { get; set; }
    }
}