using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class CityMasterModel
          {
                    [Key]
                    public int cityid { get; set; }
                    public string? Cityname { get; set; } = null;
                    public string? statename { get; set; } = null;
          }
}
