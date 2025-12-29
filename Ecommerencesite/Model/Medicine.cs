
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ecommerencesite.Model
{
          public class Medicine
          {

                    [Key]
                    public int id { get; set; }
                    public string? Name { get; set; } 
                    public string? Manufacturer { get; set; }
                    public Decimal? UnitPrice { get; set; } 
                    public Decimal? Discount { get; set; }
                    public int Quantity { get; set; }
                    public string? ExpiryDate { get; set; }
                    public string? IMAGEURL { get; set; }
                    public int STATUS { get; set; } = 1;
                    public string? Type { get; set; }   
                    
          }
}
