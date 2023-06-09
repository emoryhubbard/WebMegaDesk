using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebMegaDesk.Models;

namespace WebMegaDesk.Data
{
    public class WebMegaDeskContext : DbContext
    {
        public WebMegaDeskContext (DbContextOptions<WebMegaDeskContext> options)
            : base(options)
        {
        }

        public DbSet<WebMegaDesk.Models.DeskQuote> DeskQuote { get; set; } = default!;
    }
}
