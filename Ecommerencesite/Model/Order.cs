using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class Order
          {
                    [Key]
                    public int id { get; set; }
                    public int UserId { get; set; }
                    public string OrderNumber { get; set; }
                    public Decimal Ordertotal { get; set; }
                    public DateTime OrderStatus { get; set; }
          }
}
