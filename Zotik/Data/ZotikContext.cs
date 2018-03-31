using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Zotik.Models
{
    public class ZotikContext : DbContext
    {
        public ZotikContext (DbContextOptions<ZotikContext> options)
            : base(options)
        {
        }

        public DbSet<Zotik.Models.Pad> Pad { get; set; }
    }
}
