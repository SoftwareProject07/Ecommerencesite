using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class Cart
          {
                    [Key]
                    public int Id { get; set; }
                    public int UserId { get; set; }
                    public Decimal?  UnitPrice { get; set; } = null;
                    public Decimal?  Discount { get; set; } = null;
                    public int Quantity { get; set; }
                    public Decimal? Totalprice { get; set; } = null;
                    public int MedicineId { get; set; }     
          }
}
