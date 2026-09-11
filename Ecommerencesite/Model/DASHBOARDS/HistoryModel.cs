using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.DASHBOARDS
{
          public class HistoryModel
          {
                    [Key]
                    public int Id { get; set; }
                    public int UserId { get; set; }         
                    public string ActivityType { get; set; }
                    public string Description { get; set; }
                    public string Timestamp { get; set; }
          }
}
