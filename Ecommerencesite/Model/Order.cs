using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerencesite.Model
{
          public class Order
          {
                    [Key]
                    public int id { get; set; }
                    [Required]

                    public int UserId { get; set; }
                    [Required]
                    [MaxLength(50)]
                    public string? OrderNumber { get; set; } = null;
                    [Column(TypeName = "decimal(18,2)")]

                    public Decimal? Ordertotal { get; set; } = null;
                    // ❌ DateTime OrderStatus galat hai
                    // ✅ Status + Date alag rakho
                    [Required]
                    public string OrderStatus { get; set; }   // Pending, Paid, Shipped

                    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

                    // 🔗 Relation (optional but recommended)
                    [ForeignKey("UserId")]
                    public UserMedicine User { get; set; }

          }
}
