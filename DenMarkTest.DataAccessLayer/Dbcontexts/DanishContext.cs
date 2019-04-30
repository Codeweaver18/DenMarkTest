﻿using DenMarkTest.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DenMarkTest.DataAccessLayer.Dbcontexts
{
    public class DanishContext:DbContext
    {

        public DanishContext(DbContextOptions<DanishContext> options)
                  : base(options)
        {
            Database.Migrate();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestParticipants> TestParticipants { get; set; }

    }
}