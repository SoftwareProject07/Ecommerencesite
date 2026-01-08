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
                    
          }
         
}
