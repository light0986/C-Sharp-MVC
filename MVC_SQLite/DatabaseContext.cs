using System;
using Microsoft.EntityFrameworkCore;
using MVC01.Models;

namespace MVC01.Models
{
        public class DatabaseContext : DbContext
        {
            public DatabaseContext()
            {
            }

            public DatabaseContext(DbContextOptions<DatabaseContext> options)
                : base(options)
            {
            }

            public virtual DbSet<Product> Product { get; set; }

        }
}
