using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public SelectList? Names { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CustomerName { get; set; }
        public SelectList? SortColumns { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SortColumn { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.DeskQuote != null)
            {
                DeskQuote = await _context.DeskQuote.ToListAsync();
            }

            // Use LINQ to get list of genres.
            IQueryable<string> nameQuery = from d in _context.DeskQuote
                                            orderby d.CustomerName
                                            select d.CustomerName;

            var deskQuotes = from d in _context.DeskQuote
                             orderby d.CustomerName
                         select d;

            if (!string.IsNullOrEmpty(SortColumn)) {
                deskQuotes = from d in _context.DeskQuote
                             orderby d.Date
                             select d;
            }
                /*
                if (!string.IsNullOrEmpty(SearchString)) {
                    deskQuotes = deskQuotes.Where(s => s.Title.Contains(SearchString));
                }
                */

                if (!string.IsNullOrEmpty(CustomerName)) {
                deskQuotes = (IOrderedQueryable<DeskQuote>) deskQuotes.Where(x => x.CustomerName == CustomerName);
            }
            Names = new SelectList(await nameQuery.Distinct().ToListAsync());

            DeskQuote = await deskQuotes.ToListAsync();

        }
    }

    
}
