using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.DASHBOARDS
{
          public class CartItem
          {
                    [Key]
                    public int id { get; set; }
                    public int Userid { get; set; }
                    public string Name { get; set; }
                    public decimal Price { get; set; }
                    public int Quantity { get; set; }
          }
}
