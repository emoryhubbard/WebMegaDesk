using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMegaDesk.Data;
using WebMegaDesk.Models;

namespace WebMegaDesk.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WebMegaDesk.Data.WebMegaDeskContext _context;

        public CreateModel(WebMegaDesk.Data.WebMegaDeskContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            DeskQuote.Date = DateTime.Now;
            DeskQuote.Price = GetTotal();
            if (_context.DeskQuote == null || DeskQuote == null)
            {
                return Page();
            }
            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        public int GetTotal() {
            int total = 0;
            int basePrice = 200;
            int drawerPrice = 50;
            int desktopArea = DeskQuote.Width * DeskQuote.Depth;

            total += basePrice;
            if (desktopArea > 1000)
                total += desktopArea;
            total += GetMaterialPrice();
            total += DeskQuote.DrawerCount * drawerPrice;
            total += GetRushPrice();

            return total;
        }
        public int GetMaterialPrice() {
            int total = 0;
            int drawerPrice = 50;
            int oakPrice = 200;
            int laminatePrice = 100;
            int pinePrice = 50;
            int rosewoodPrice = 300;
            int veneerPrice = 125;

            total += DeskQuote.DrawerCount * drawerPrice;
            if (DeskQuote.Material == "Oak")
                total += oakPrice;
            if (DeskQuote.Material == "Laminate")
                total += laminatePrice;
            if (DeskQuote.Material == "Pine")
                total += pinePrice;
            if (DeskQuote.Material == "Rosewood")
                total += rosewoodPrice;
            if (DeskQuote.Material == "Veneer")
                total += veneerPrice;
            return total;
        }
        public int GetRushPrice() {
            int total = 0;
            int desktopArea = DeskQuote.Width * DeskQuote.Depth;
            if (DeskQuote.RushDays == 3) {
                if (desktopArea < 1000)
                    total += 60;
                if (desktopArea >= 1000 && desktopArea <= 200)
                    total += 70;
                if (desktopArea > 2000)
                    total += 80;
            }
            if (DeskQuote.RushDays == 5) {
                if (desktopArea < 1000)
                    total += 40;
                if (desktopArea >= 1000 && desktopArea <= 200)
                    total += 50;
                if (desktopArea > 2000)
                    total += 60;
            }
            if (DeskQuote.RushDays == 5) {
                if (desktopArea < 1000)
                    total += 30;
                if (desktopArea >= 1000 && desktopArea <= 200)
                    total += 35;
                if (desktopArea > 2000)
                    total += 40;
            }
            return total;
        }
    }
}
