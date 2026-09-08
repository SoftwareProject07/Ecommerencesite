using Microsoft.Owin.BuilderProperties;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecommerencesite.Model
{
          public class Order
          {


                    //[Key]
                    //public int Id { get; set; }

                    //public int UserId { get; set; }

                    //[NotMapped]
                    //public object User { get; set; } // Ignored during DB mapping to prevent binding errors

                    //public int AddressId { get; set; }

                    //[NotMapped]
                    //public object Address { get; set; } // Ignored during DB mapping

                    //public int StoreId { get; set; }

                    //public string OrderNumber { get; set; }

                    //[Column(TypeName = "decimal(18,2)")]
                    //public decimal Ordertotal { get; set; }

                    //public string OrderStatus { get; set; }

                    //public string PaymentMode { get; set; }

                    //public double DistanceInKm { get; set; }

                    //public string EstimatedTime { get; set; }

                    //public DateTime CreatedAt { get; set; }

                    //public List<OrderItem> OrderItemss { get; set; }

                    [Key]
                    public int Id { get; set; }

                    public int UserId { get; set; }

                    [NotMapped]
                    [JsonIgnore]
                    public object? User { get; set; } // Ignored by both EF Core and JSON deserializer

                    public int AddressId { get; set; }

                    [NotMapped]
                    [JsonIgnore]
                    public object? Address { get; set; } // Ignored by both EF Core and JSON deserializer

                    public int StoreId { get; set; }

                    public string OrderNumber { get; set; }

                    [Column(TypeName = "decimal(18,2)")]
                    public decimal Ordertotal { get; set; }

                    public string OrderStatus { get; set; }

                    public string PaymentMode { get; set; }

                    public double DistanceInKm { get; set; }

                    public string EstimatedTime { get; set; }

                    public DateTime CreatedAt { get; set; }

                    public List<OrderItem> OrderItemss { get; set; }
          }
}
