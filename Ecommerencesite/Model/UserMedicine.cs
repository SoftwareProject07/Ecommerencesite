using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class UserMedicine
          {
                    [Key]
                    public int id { get; set; }
                    [Required(ErrorMessage = "FirstName Will be required")]
                    [StringLength(100)]

                    public string? FirstName { get; set; } = null;

                    public string? MiddleName { get; set; }  = null;
                    [Required(ErrorMessage = "LastName Will be required")]
                    [StringLength(100)]

                    public string? LastName { get; set; } = null;
                    [Required]
                    [StringLength(100, MinimumLength = 6)]
                    [DataType(DataType.Password)]
                    public string? Password { get; set; } = null;
                    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]

                    [Display(Name = "The password and confirmation password do not match")]
                    public string ConfirmPassword { get; set; } = string.Empty; // ✅ Only for validation
                    [Required(ErrorMessage = "Contact No is required.")]
                    [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Contact Number.")]
                    public string? MobileNumber { get; set; } 
                    [Required]
                    [EmailAddress]
                    public string? Email { get; set; } = null;
                    public Decimal? Fund { get; set; } = 0;
                    public string? type { get; set; } = null; //OrderType="User" or "Admin"
                    public DateTime? CreateOn { get; set; } = DateTime.Now;


                    //  public int Active { get; set; }
                    //public string? OrderType { get; set; }

          }

}
