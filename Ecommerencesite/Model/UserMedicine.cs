using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class UserMedicine
          {
                    [Key]
                    public int id { get; set; }
                    public string? FirstName { get; set; }
                    public string? MiddleName { get; set; }  
                    public string? LastName { get; set; } 
                    public string? Password { get; set; } 
                    public string? Email { get; set; }
                    public Decimal? Fund { get; set; } = 0;
                    public string? type { get; set; }//OrderType
                    public DateTime? CreateOn { get; set; } = DateTime.Now;
                  //  public int Active { get; set; }
                    //public string? OrderType { get; set; }

          }
       
}
