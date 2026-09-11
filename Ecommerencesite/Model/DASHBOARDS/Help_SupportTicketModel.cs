using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.DASHBOARDS
{
          public class Help_SupportTicketModel
          {
                    [Key]
                    public int Id { get; set; }
                    public int UserId { get; set; }         
                    public string Subject { get; set; }
                    public string Status { get; set; }
                    public string CreatedAt { get; set; }
          }
}
