using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerencesite.Model
{
          public class Cart
          {
                    [Key]
                    public int Id { get; set; }

                 //   [Required]
                    public int UserId { get; set; }

                    // Price snapshot (order/cart time)
                    [Column(TypeName = "decimal(18,2)")]
                    public decimal? UnitPrice { get; set; }

                    [Column(TypeName = "decimal(18,2)")]
                    public decimal? Discount { get; set; }

                    [Required]
                    public int Quantity { get; set; }

                    [Column(TypeName = "decimal(18,2)")]
                    public decimal? TotalPrice { get; set; }

                    public int MedicineId { get; set; }

                    // 🔗 Navigation Property
                    //[ForeignKey("MedicineId")]
                    //public Medicine Medicine { get; set; }
          }
}
