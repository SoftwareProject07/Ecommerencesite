using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.DASHBOARDS
{
          public class BloodGlucoseData
          {
                    [Key]
                    public int Id { get; set; } // Table ki Primary Key

                    public int userid { get; set; } // ya UserId (Customer ID foreign key)

                    public string DayLabel { get; set; }

                    public double Value { get; set; }

                    public DateTime RecordDate { get; set; }
          }
}
