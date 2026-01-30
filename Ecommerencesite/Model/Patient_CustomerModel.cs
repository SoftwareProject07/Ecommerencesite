using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerencesite.Model
{
          public class Patient_CustomerModel
          {
                    [Key]
                    public int Patient_CustomerId { get; set; }

                    // ✅ IMPORTANT: Ye field link karegi Login User ki ID se
                    //public int UsersId { get; set; }
                    public string? FullName { get; set; } = null;
                    public string? Gender { get; set; } = null;
                    [EmailAddress]      
                    public string? Email { get; set; } = null;
                    public string? PhoneNumber { get; set; } = null;
                    public string? Address { get; set; } = null;
                    public int ? Age { get; set; }
                   // public string? CustomerAddress { get; set; } = null;
                    public string? CustomerCity { get; set; } = null;
                    public string? CustomerState { get; set; } = null;
                    public string? CustomerZipCode { get; set; } = null;
                    //   public string? CustomerCountry { get; set; } = null;

                    public DateTime? CreatedOn { get; set; } = DateTime.UtcNow;
                   
          }
}
