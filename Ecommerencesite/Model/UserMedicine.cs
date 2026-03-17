using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerencesite.Model
{
          public class UserMedicine
          {
                    [Key]
                    public int id { get; set; }
                    [Required(ErrorMessage = "FirstName Will be required")]
                    [StringLength(100)]


                    public string? FirstName { get; set; } = null;

                    public string? MiddleName { get; set; } = " ";
                    [Required(ErrorMessage = "LastName Will be required")]
                    [StringLength(100)]

                    public string? LastName { get; set; } = null;
                    [Required]
                    [StringLength(100, MinimumLength = 6)]
                    [DataType(DataType.Password)]
                    public string? Password { get; set; } = null;
                   
                    public string? MobileNumber { get; set; } = null;
                   // [Required]
                    [EmailAddress]
                    public string? Email { get; set; } = null;
                    public Decimal? Fund { get; set; } = 0;
                    //public Boolean? StatusRemark { get; set; } = null;
                   // public bool IsActive { get; set; } = true; // Default value set karein
                    public string? type { get; set; } = null; //OrderType="User" or "Admin"
                    public DateTime? CreatedOn { get; set; } = DateTime.UtcNow;


                  


          }
}
