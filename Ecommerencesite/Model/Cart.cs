using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class Cart
          {
                    [Key]
                    public int Id { get; set; }
                    public int UserId { get; set; }
                    public Decimal  UnitPrice { get; set; }
                    public Decimal  Discount { get; set; }
                    public int  Quantity { get; set; }
                    public Decimal  Totalprice { get; set; }
                    public int MedicineId { get; set; }     
          }
}
