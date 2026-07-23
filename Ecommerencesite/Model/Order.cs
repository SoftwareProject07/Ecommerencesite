using Microsoft.Owin.BuilderProperties;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerencesite.Model
{
          public class Order
          {
                    //[Key]
                    //public int id { get; set; }
                    //[Required]

                    //public int UserId { get; set; }
                    //[Required]
                    //[MaxLength(50)]
                    //public string? OrderNumber { get; set; } = null;
                    //[Column(TypeName = "decimal(18,2)")]

                    //public Decimal? Ordertotal { get; set; } = null;
                    //// ❌ DateTime OrderStatus galat hai
                    //// ✅ Status + Date alag rakho
                    //[Required]
                    //public string OrderStatus { get; set; }   // Pending, Paid, Shipped

                    //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

                    //// 🔗 Relation (optional but recommended)
                    //[ForeignKey("UserId")]
                    //public UserMedicine User { get; set; }



                    [Key]
                    public int id { get; set; }

                    [Required]
                    public int UserId { get; set; }

                    [Required]
                    [MaxLength(50)]
                    public string? OrderNumber { get; set; } = null;

                    [Column(TypeName = "decimal(18,2)")]
                    public Decimal? Ordertotal { get; set; } = null;

                    [Required]
                    public string OrderStatus { get; set; }   // Pending, Paid, Shipped, Dispatched, OutForDelivery, Delivered

                    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

                    // 🔗 Relation with User
                    [ForeignKey("UserId")]
                    public UserMedicine User { get; set; }

                    // ==========================================
                    // 🗺️ Map aur Tracking ke liye Naye Fields Add Karein
                    // ==========================================

                    [Required]
                    public int AddressId { get; set; }

                    [ForeignKey("AddressId")]
                    public deliverypartnermodel Address { get; set; } // Customer ka delivery address (Lat/Lng isme hoga)

                    public int StoreId { get; set; } = 1; // Pharmacy/Store ID (Origin point ke liye)

                    [Column(TypeName = "decimal(18,2)")]
                    public decimal? DistanceInKm { get; set; } // Store se customer tak ka distance

                    [MaxLength(50)]
                    public string? EstimatedTime { get; set; } // ETA (jaise "15 mins")

                    // 🔗 Relation with OrderItems (Aapka pehle wala model)
                    public ICollection<OrderItem> OrderItems { get; set; }

          }
}
