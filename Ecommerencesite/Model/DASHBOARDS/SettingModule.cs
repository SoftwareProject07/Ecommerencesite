using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.DASHBOARDS
{
          public class SettingModule
          {
                    [Key]
                    public int Id { get; set; }

                    public bool EmailNotifications { get; set; } = true;
                    public bool SmsNotifications { get; set; } = true;
                    public bool TwoFactorAuth { get; set; } = false;
                    public string ThemeMode { get; set; } = "Light"; // "Light" or "Dark"
                    public string Language { get; set; } = "English";

                    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
          }
}
