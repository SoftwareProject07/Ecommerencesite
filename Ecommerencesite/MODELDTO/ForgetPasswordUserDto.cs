using System.ComponentModel.DataAnnotations;

namespace CRUDAPPLICATION.ModelDTO
{
          public class ForgetPasswordUserDto
          {
                    public string Email { get; set; } 
                    //[Required(ErrorMessage = "New Password is required.")]
                    //[StringLength(100, MinimumLength = 6)]
                    //[DataType(DataType.Password)]
                    public string NewPassword { get; set; }
                    public string PhoenNumber { get; set; } 
                    public string UserName { get; set; }    
                    
          }
         
}
