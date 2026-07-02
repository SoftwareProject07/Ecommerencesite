using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.MODELDTO
{
          public class UpdateTicketDTO
          {
                    [Required]
                    public int TicketId { get; set; }

                    public string Subject { get; set; }

                    public string Description { get; set; }

                    public string Category { get; set; }

                    public string Priority { get; set; }

                    public string Status { get; set; }
          }
}
