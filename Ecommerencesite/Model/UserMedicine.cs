using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class UserMedicine
          {
                    [Key]
                    public int id { get; set; }
                    public string? FirstName { get; set; } = null;
                    public string? MiddleName { get; set; } = null;   
                    public string? LastName { get; set; } = null;
                    public string? Password { get; set; } = null;
                    public string? Email { get; set; } = null;    
                    public Decimal Fund { get; set; }
                    public string? type { get; set; } = null;//OrderType
                    public DateTime? CreateOn { get; set; } 

                    //public string? OrderType { get; set; }

          }
       
}
