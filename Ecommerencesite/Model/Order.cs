using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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

                    //[Required]
                    //public string OrderStatus { get; set; }   // Pending, Paid, Shipped, Dispatched, OutForDelivery, Delivered

                    //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

                    //// 🔗 Relation with User
                    //[ForeignKey("UserId")]
                    //public UserMedicine User { get; set; }

                    //// ==========================================
                    //// 🗺️ Map aur Tracking ke liye Naye Fields Add Karein
                    //// ==========================================

                    //[Required]
                    //public int AddressId { get; set; }

                    //[ForeignKey("AddressId")]
                    //public deliverypartnermodel Address { get; set; } // Customer ka delivery address (Lat/Lng isme hoga)

                    //public int StoreId { get; set; } = 1; // Pharmacy/Store ID (Origin point ke liye)

                    //[Column(TypeName = "decimal(18,2)")]
                    //public decimal? DistanceInKm { get; set; } // Store se customer tak ka distance

                    //[MaxLength(50)]
                    //public string? EstimatedTime { get; set; } // ETA (jaise "15 mins")

                    //// 🔗 Relation with OrderItems (Aapka pehle wala model)
                    //public ICollection<OrderItem> orderItemss { get; set; }



                    //[Key]
                    //public int id { get; set; }

                    //[Required]
                    //public int UserId { get; set; }

                    //[MaxLength(50)]
                    //public string? OrderNumber { get; set; } = null;

                    //[Column(TypeName = "decimal(18,2)")]
                    //public decimal? Ordertotal { get; set; } = null;

                    //[Required]
                    //public string OrderStatus { get; set; } = "Pending";

                    //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

                    //[ForeignKey("UserId")]
                    //[ValidateNever] // 👈 Prevents validation error for User object
                    //public UserMedicine? User { get; set; } = null;

                    //[Required]
                    //public int AddressId { get; set; }

                    //[ForeignKey("AddressId")]
                    //[ValidateNever] // 👈 Prevents validation error for Address object
                    //public deliverypartnermodel? Address { get; set; } = null;

                    //public int StoreId { get; set; } = 1;

                    //[Column(TypeName = "decimal(18,2)")]
                    //public decimal? DistanceInKm { get; set; }

                    //[MaxLength(50)]
                    //public string? EstimatedTime { get; set; }

                    //public ICollection<OrderItem>? orderItemss { get; set; }
                    [Key]
                    public int id { get; set; }

                    [Required]
                    public int UserId { get; set; }

                    [MaxLength(50)]
                    public string? OrderNumber { get; set; } = null;

                    [Column(TypeName = "decimal(18,2)")]
                    public decimal? Ordertotal { get; set; } = null;

                    [Required]
                    public string OrderStatus { get; set; } = "Pending";

                    // 👉 Yahan PaymentMode add kiya gaya hai
                    [MaxLength(50)]
                    public string? PaymentMode { get; set; } = " ";

                    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

                    [ForeignKey("UserId")]
                    [ValidateNever]
                    public UserMedicine? User { get; set; } = null;

                    [Required]
                    public int AddressId { get; set; }

                    [ForeignKey("AddressId")]
                    [ValidateNever]
                    public deliverypartnermodel? Address { get; set; } = null;

                    public int StoreId { get; set; } = 1;

                    [Column(TypeName = "decimal(18,2)")]
                    public decimal? DistanceInKm { get; set; }

                    [MaxLength(50)]
                    public string? EstimatedTime { get; set; }

                    public ICollection<OrderItem>? orderItemss { get; set; }
          }
}
