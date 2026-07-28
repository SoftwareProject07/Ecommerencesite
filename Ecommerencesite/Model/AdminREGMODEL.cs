using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerencesite.Model
{
          public class AdminREGMODEL
          {

                    //[Key]
                    //public int ADMINid { get; set; }

                    //public string? FirstName { get; set; } = null;
                    //public string? MiddleName { get; set; } = null;
                    //public string? LastName { get; set; } = null;
                    //public string? Password { get; set; } = null;
                    //public string? Email { get; set; } = null;
                    //public string? MobileNumber { get; set; } = null;
                    //public Decimal? Fund { get; set; } = 0;
                    //public string? type { get; set; } = null; //OrderType="User" or "Admin"
                    //public DateTime? CreatedOn { get; set; } = DateTime.UtcNow;




                    [Key]
                    public int ADMINid { get; set; }

                    public string? FirstName { get; set; } = null;
                    public string? MiddleName { get; set; } = null;
                    public string? LastName { get; set; } = null;
                    public string? Password { get; set; } = null;
                    public string? Email { get; set; } = null;
                    public string? MobileNumber { get; set; } = null;
                    public Decimal? Fund { get; set; } = 0;
                    public string? type { get; set; } = null; // "User" or "Admin"
                    public DateTime? CreatedOn { get; set; } = DateTime.UtcNow;

                    // 👇 Add your new column here (e.g., Captcha)
                    [NotMapped] // Use [NotMapped] if this should NOT be saved in the database table
                    public string? Captcha { get; set; } = null;
          }
}
