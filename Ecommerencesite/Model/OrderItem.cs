using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerencesite.Model
{
          public class OrderItem//tracking 
          {
                    //[Key]
                    //public int Id { get; set; }
                    //public int OrderId { get; set; }
                    //public int MedicineId { get; set; }
                    //public Decimal? UnitPrice { get; set; } = null;
                    //public Decimal? Discount { get; set; } = null;
                    //public int Quantity { get; set; } 
                    //public Decimal? Totalprice { get; set; } = null;



                    [Key]
                    public int Id { get; set; }

                    public int OrderId { get; set; }

                    [ForeignKey("OrderId")]
                    public Order Order { get; set; }

                    public int MedicineId { get; set; }

                    [Column(TypeName = "decimal(18,2)")]
                    public decimal? UnitPrice { get; set; }

                    [Column(TypeName = "decimal(18,2)")]
                    public decimal? Discount { get; set; }

                    public int Quantity { get; set; }

                    [Column(TypeName = "decimal(18,2)")]
                    public decimal? Totalprice { get; set; }
          }
}
