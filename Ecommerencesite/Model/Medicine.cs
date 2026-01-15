
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecommerencesite.Model
{
          public class Medicine
          {

                    [Key]
                    public int id { get; set; }
                    public int UserId { get; set; }    // 🔑 OWNER OF MEDICINE


                    public string? Name { get; set; } = null;
                    public string? Manufacturer { get; set; } = null;
                    [Column(TypeName = "decimal(18,2)")]

                    public Decimal? UnitPrice { get; set; }          = null;
                    public Decimal? Discount { get; set; } = null;
                    public int Quantity { get; set; }
                    [Required]
                    [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$", ErrorMessage = "ExpiryDate must be DD/MM/YYYY")]
                    public string ExpiryDate { get; set; }= null!;
                    //public string? IMAGEURL { get; set; }
                    public string? Image { get; set; } = null;

                    public int STATUS { get; set; } = 1;
                    public string? Type { get; set; }   = null;

          }
}
