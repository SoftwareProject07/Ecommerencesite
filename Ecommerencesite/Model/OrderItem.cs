using Ecommerencesite.Migrations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecommerencesite.Model
{
          public class OrderItem//tracking 
          {




                    //1.
                    //[Key]
                    //public int Id { get; set; }

                    //public int OrderId { get; set; }

                    //[ForeignKey("OrderId")]
                    //[ValidateNever] // 👈 Prevents validation and type mismatch errors
                    //public Order? Order { get; set; } = null;

                    //public int MedicineId { get; set; }

                    //[Column(TypeName = "decimal(18,2)")]
                    //public decimal? UnitPrice { get; set; }

                    //[Column(TypeName = "decimal(18,2)")]
                    //public decimal? Discount { get; set; }

                    //public int Quantity { get; set; }

                    //[Column(TypeName = "decimal(18,2)")]
                    //public decimal? Totalprice { get; set; }


                    //2.

                    //[Key]

                    //public int Id { get; set; }
                    //public int orderid { get; set; }

                    //[JsonIgnore] // JSON deserialization error se bachne ke liye
                    //public Order Order { get; set; }

                    //public int MedicineId { get; set; }
                    //public decimal UnitPrice { get; set; }
                    //public decimal Discount { get; set; }
                    //public int Quantity { get; set; }
                    //public decimal Totalprice { get; set; }

                   //3/
                    [Key]
                    public int Id { get; set; }

                    public int OrderId { get; set; }

                    // [JsonIgnore] lagane se System.Text.Json is navigation property ko request body me validate ya deserialize nahi karega
                    [JsonIgnore]
                    public Order? Order { get; set; }

                    public int MedicineId { get; set; }

                    [Column(TypeName = "decimal(18,2)")]
                    public decimal UnitPrice { get; set; }

                    [Column(TypeName = "decimal(18,2)")]
                    public decimal Discount { get; set; }

                    public int Quantity { get; set; }

                    [Column(TypeName = "decimal(18,2)")]
                    public decimal Totalprice { get; set; }
          }
}