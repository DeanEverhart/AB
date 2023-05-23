using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AB.Models;

namespace AB.Data
{
    public class ABContext : DbContext
    {
        public ABContext (DbContextOptions<ABContext> options)
            : base(options)
        {
        }

        public DbSet<AB.Models.A> A { get; set; } = default!;

        public DbSet<AB.Models.B>? B { get; set; }
    }
}
