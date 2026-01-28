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
                    public List<UserMedicine>? LSTuserMedicines { get; set; } = null;
                    public UserMedicine? userMedicine { get; set; } = null;
                    public List<Medicine>? LSTmedicines { get; set; } = null;
                    public Medicine? medicine { get; set; } = null;
                    public List<Cart>? LSTcarts { get; set; }   = null;
                    public Cart? cart { get; set; }= null;
                    public List<Order>? LSTorders { get; set; } = null;
                    public Order? order { get; set; } = null;
                    public List<OrderItem>? LSTorderItems { get; set; } = null;
                    public OrderItem? orderItem { get; set; } = null;
                    public List<AdminREGMODEL>? LSTadminREGMODELS { get; set; } = null;
                    public AdminREGMODEL? adminREGMODEL { get; set; } = null;
                    public Patient_CustomerModel? Patient_CustomerProfiless { get; set; } = null;
                    public List<Patient_CustomerModel> lstcustomeraddress { get; set; } 
                    //[NotMapped]

                    public object? Data { get; set; } = null;

          }
}
