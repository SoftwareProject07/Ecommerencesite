using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.DASHBOARDS
{
          public class UserSettingsModel
          {
                    [Key]
                    public int Id { get; set; }
                    public int UserId { get; set; }         
                    public string Email { get; set; }
                    public string Phone { get; set; }
                    public bool EmailNotifications { get; set; }
                    public bool SmsNotifications { get; set; }
          }
}
