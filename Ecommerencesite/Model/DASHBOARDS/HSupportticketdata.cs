using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerencesite.Model.DASHBOARDS
{
      //    [Table("HSupportticketdata")]
          public class HSupportticketdata
          {
                    [Key]
                    public int Id { get; set; }

                    public string Subject { get; set; }

                    public string Status { get; set; } = "OPEN";

                    // Naya naam taaki database ke purane column type ka conflict khatam ho jaye
                    public DateTime? TicketDate { get; set; } = DateTime.UtcNow;

          }
}
