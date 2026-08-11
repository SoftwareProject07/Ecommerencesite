using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class StateNameModel
          {
                    [Key]
                    public int Id { get; set; }
                    public string? StateName { get; set; } = null;
                    ///   public string? CityName { get; set; } = null;
          }
}
