using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class UpiPaymentVPAResponse
          {
                    [Key]
                    public int upivpiresponse { get; set; }          // e.g., 1 
                    public bool IsValidVpa { get; set; }
                    public string OrderId { get; set; }
                    public string PaymentUrl { get; set; } // Payment Link for user
                    public string Message { get; set; }
          }
}
