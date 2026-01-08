using System.ComponentModel.DataAnnotations;

namespace CRUDAPPLICATION.ModelDTO
{
          public class ForgetPasswordUserDto
          {
                    public string Email { get; set; } = string.Empty;
                    [Required(ErrorMessage = "New Password is required.")]
                    [StringLength(100, MinimumLength = 6)]
                    [DataType(DataType.Password)]
                    public string NewPassword { get; set; } = string.Empty;
                    [Required(ErrorMessage = "Please ConfirmNew your password.")]
                    [Compare("NewPassword", ErrorMessage = "The new password and ConfirmNewPassword  do not match.")]
                    public string ConfirmPassword { get; set; } = string.Empty;
          }
         
}
