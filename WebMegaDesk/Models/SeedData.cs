using Microsoft.EntityFrameworkCore;
using WebMegaDesk.Data;

namespace WebMegaDesk.Models;

public static class SeedData {
    public static void Initialize(IServiceProvider serviceProvider) {
        using (var context = new WebMegaDeskContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<WebMegaDeskContext>>())) {
            if (context == null || context.DeskQuote == null) {
                throw new ArgumentNullException("Null WebMegaDeskContext");
            }

            // Look for any desk quotes
            if (context.DeskQuote.Any()) {
                return;   // DB has been seeded
            }

            context.DeskQuote.AddRange(
                new DeskQuote {
                    Date = DateTime.Parse("2023-6-9"),
                    CustomerName = "Elijah Bar-Jonah",
                    Price = 2300M,
                    Material = "Oak",
                    DrawerCount = 5,
                    Width = 32,
                    Depth = 33,
                    RushDays = 14
                },

                new DeskQuote {
                    Date = DateTime.Parse("2023-6-8"),
                    CustomerName = "John Carter",
                    Price = 1900M,
                    Material = "Veneer",
                    DrawerCount = 5,
                    Width = 32,
                    Depth = 30,
                    RushDays = 7
                },

                new DeskQuote {
                    Date = DateTime.Parse("2023-6-8"),
                    CustomerName = "Harry Bergeron",
                    Price = 2500M,
                    Material = "Pine",
                    DrawerCount = 5,
                    Width = 32,
                    Depth = 30,
                    RushDays = 3
                },

                new DeskQuote {
                    Date = DateTime.Parse("2023-6-7"),
                    CustomerName = "Claude Shannon",
                    Price = 2200M,
                    Material = "Pine",
                    DrawerCount = 6,
                    Width = 30,
                    Depth = 32,
                    RushDays = 7
                }
            );
            context.SaveChanges();
        }
    }
}