using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class CustomerCareTicket
          {
                    [Key]
                    public int Id { get; set; }
                    public string? CustomerName { get; set; }
                    public string? Email { get; set; }
                    public string Message { get; set; } = string.Empty;
                    public string? AiResponse { get; set; }
                    public DateTime CreatedAt { get; set; } = DateTime.Now;
                    public bool IsResolved { get; set; } = false;
                    public string Status { get; set; } = "Pending";
          }


          public class ChatRequest
          {
                    public string Message { get; set; } = string.Empty;
                    public string? UserEmail { get; set; }
          }
}
