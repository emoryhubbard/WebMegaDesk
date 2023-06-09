using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
    }
}
