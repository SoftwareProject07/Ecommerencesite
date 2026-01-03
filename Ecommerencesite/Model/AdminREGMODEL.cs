using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class AdminREGMODEL
          {

                    [Key]
                    public int ADMINid { get; set; }
                    public string? FirstName { get; set; } = null;
                    public string? MiddleName { get; set; } = null;
                    public string? LastName { get; set; } = null;
                    public string? Password { get; set; } = null;
                    public string? Email { get; set; } = null;
                    public Decimal? Fund { get; set; } = 0;
                    public string? type { get; set; } = null; //OrderType="User" or "Admin"
                    public DateTime? CreateOn { get; set; } = DateTime.Now;
          }
}
