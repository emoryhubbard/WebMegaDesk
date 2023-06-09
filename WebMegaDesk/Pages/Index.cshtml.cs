using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebMegaDesk.Data;
using WebMegaDesk.Models;

namespace WebMegaDesk.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WebMegaDesk.Data.WebMegaDeskContext _context;

        public IndexModel(WebMegaDesk.Data.WebMegaDeskContext context)
        {
            _context = context;
        }

        public IList<DeskQuote> DeskQuote { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DeskQuote != null)
            {
                DeskQuote = await _context.DeskQuote.ToListAsync();
            }
        }
    }
}
