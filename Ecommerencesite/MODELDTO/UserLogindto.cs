using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.MODELDTO
{
          public class UserLogindto
          {
                    //public string? FirstName { get; set; } = null;
                    //public string? LastName { get; set; } = null;
                    public string? Email { get; set; } = null;
                    public string? Password { get; set; } = null;
                    [Required(ErrorMessage = "Contact No is required.")]
                    [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Contact Number.")]
                    public string? MobileNumber { get; set; } = null;

                    //public string NewPassword { get; set; } = string.Empty;
                    //public string ConfirmPassword { get; set; } = string.Empty;


          }
}
