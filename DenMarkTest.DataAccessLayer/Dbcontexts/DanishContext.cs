using DenMarkTest.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DenMarkTest.DataAccessLayer.Dbcontexts
{
    /// <summary>
    /// Danish DbContext for creating Dbset Entities and estabishing connection to database server as provided in connection string
    /// </summary>
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
        public DbSet<TestTypes> TestTypes { get; set; }


    }
}
