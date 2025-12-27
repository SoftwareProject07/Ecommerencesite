using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class OrderItem//tracking 
          {
                    [Key]
                    public int Id { get; set; }
                    public int OrderId { get; set; }
                    public int MedicineId { get; set; }
                    public Decimal? UnitPrice { get; set; } = null;
                    public Decimal? Discount { get; set; } = null;
                    public int Quantity { get; set; } 
                    public Decimal? Totalprice { get; set; } = null;
          }
}
