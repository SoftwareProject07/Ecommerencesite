using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class AdminTypeModel
          {
                    [Key]
                    public int Admintypeid { get; set; }
                    public string? type { get; set; } = null;
          }
}
