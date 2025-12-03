using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class Medicine
          {

                    [Key]
                    public int id { get; set; }
                    public string? Name { get; set; } = null;
                    public string? Manufacturer { get; set; } = null;
                    public Decimal UnitPrice { get; set; } 
                    public Decimal Discount { get; set; }   
                    public int Quantity{ get; set; }
                    public DateTime ExpiryDate { get; set; }
                    public string IMAGEURL { get; set; } = null!;
                    public int STATUS { get; set; }
                    public string Type { get; set; } 
          }
}
