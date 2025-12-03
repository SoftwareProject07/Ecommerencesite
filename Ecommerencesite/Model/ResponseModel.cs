using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class ResponseModel
          {
                    [Key]
                    public int statusCode { get; set; }
                    public string responseMessage { get; set; } = null!;        
                    public List<UserMedicine> LSTuserMedicines { get; set; } 
                    public UserMedicine userMedicine { get; set; }
                    public List<Medicine> LSTmedicines { get; set; }
                    public Medicine medicine { get; set; }
                    public List<Cart> LSTcarts { get; set; }          
                    public Cart cart { get; set; }
                    public List<Order> LSTorders { get; set; }
                    public Order order { get; set; }
                    public List<OrderItem> LSTorderItems { get; set; }          
                    public OrderItem orderItem { get; set; }
          }
}
