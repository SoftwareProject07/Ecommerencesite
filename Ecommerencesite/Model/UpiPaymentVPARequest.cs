using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class UpiPaymentVPARequest
          {
                    [Key]
                    public int upivpaid { get; set; }          // e.g., 1       
                    public string Vpa { get; set; }        // e.g., devgautam4@ybl
                    public decimal Amount { get; set; }    // e.g., 500 (in INR)
                    public string CustomerName { get; set; }
                    public string CustomerContact { get; set; }
          }
}
