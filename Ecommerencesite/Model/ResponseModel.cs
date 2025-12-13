using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerencesite.Model
{
          [NotMapped]   // 👈 ISSE FULL CLASS DATABASE ME MAP NAHI HOGI

          public class ResponseModel
          {
                    // [Key]
                   // [NotMapped]

                    public bool status { get; set; }
                   // [NotMapped]

                    public string? responseMessage { get; set; } = string.Empty;
                    public List<UserMedicine>? LSTuserMedicines { get; set; } 
                    public UserMedicine? userMedicine { get; set; }
                    public List<Medicine>? LSTmedicines { get; set; }
                    public Medicine? medicine { get; set; }
                    public List<Cart>? LSTcarts { get; set; }          
                    public Cart? cart { get; set; }
                    public List<Order>? LSTorders { get; set; }
                    public Order? order { get; set; }
                    public List<OrderItem>? LSTorderItems { get; set; }          
                    public OrderItem? orderItem { get; set; }
                    //[NotMapped]

                    public object? Data { get; set; }

          }
}
