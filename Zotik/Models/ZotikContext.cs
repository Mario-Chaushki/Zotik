using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zotik.Models
{
    public class ZotikContext : DbContext
    {
        public  ZotikContext(DbContextOptions<ZotikContext> options)
            :base(options)
        {

        }

        public DbSet<Pad> Pads { get; set; }
    }
}
