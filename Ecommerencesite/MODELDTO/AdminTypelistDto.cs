using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.MODELDTO
{
          public class AdminTypelistDto
          {
                    [Key]
                    public int typelistid { get; set; }

                    public string type { get; set; }

          }
}
