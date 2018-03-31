using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Zotik.Models
{
    public class PadsContext : DbContext
    {
        public PadsContext (DbContextOptions<PadsContext> options)
            : base(options)
        {
        }

        public DbSet<Zotik.Models.Pad> Pad { get; set; }
    }
}
