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
        public DbSet<string> companyProfile { get; set; }

    }
}
