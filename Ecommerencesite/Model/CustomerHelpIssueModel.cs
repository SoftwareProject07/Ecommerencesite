using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class CustomerHelpIssueModel
          {
                    [Key]
                    public int customerhelpissueid { get; set; }
                    public string? CustomerHelpName { get; set; } = null;
                    public string? CustomerHelpEmail { get; set; } = null;
                    public string? CustomerHelpMessage { get; set; } = null;
                    public string? CustomerHelpStatus { get; set; } = null;// Default status is "Pending"
                    public string? MobileNumber { get; set; } = null; 
          }
}
