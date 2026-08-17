using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class DeliveryAssigntoModel
          {

                    [Key]
                    public int DeliveryAssgintoId { get; set; }
                    public string? DeliveryPersonName { get; set; } = null;

                    public string? DeliveryPerdsonType { get; set; } = null;
          }
}
