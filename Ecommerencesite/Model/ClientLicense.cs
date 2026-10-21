using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class ClientLicense
          {
                    [Key]
                    public int Id { get; set; }
                    public string ClientName { get; set; }
                    public bool IsAllowed { get; set; }  // Yeh wahi true/false status hai
          }
}
