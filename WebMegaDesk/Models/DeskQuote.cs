using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace WebMegaDesk.Models {
    public class DeskQuote {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
        
        public int DrawerCount { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string Material { get; set; } = string.Empty;
        public int RushDays { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string CustomerName { get; set; } = string.Empty;
        // [Display(Name = "Quote Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        

        public decimal CalcuatePrice()
        {

            int Area = Width * Depth;
            if (Area > 1000)
            {
                Price = Area;
            }

            if (RushDays == 3)
            {
                if (Area < 1000) {
                    Price += 60;
                } 
                else if (Area > 1000 && Area < 2000)
                {
                    Price += 70;
                }

                else if (Area > 2000)
                {
                    Price += 80;
                }
               
            }

            else if (RushDays == 5)
            {

                if (Area < 1000)
                {
                    Price += 40;
                }
                else if (Area > 1000 && Area < 2000)
                {
                    Price += 50;
                }

                else if (Area > 2000)
                {
                    Price += 60;
                }
                
            }

            else if (RushDays == 7)
            {
                if (Area < 1000)
                {
                    Price += 30;
                }
                else if (Area > 1000 && Area < 2000)
                {
                    Price += 35;
                }

                else if (Area > 2000)
                {
                    Price += 40;
                }
            }

            if (Material == "Oak") { Price += 200; }
            else if (Material == "Laminate") { Price += 100; }
            else if (Material == "Pine") { Price += 50; }
            else if (Material == "Rosewood") { Price += 300; }
            else if (Material == "Vaneer") { Price += 125; }

            decimal price = Price;
            return price;
        }

       
    }
}
