using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class Order
          {
                    [Key]
                    public int id { get; set; }
                    public int UserId { get; set; }
                    public string? OrderNumber { get; set; } = null;
                    public Decimal? Ordertotal { get; set; } = null;
                    public DateTime? OrderStatus { get; set; } = null;
          }
}
