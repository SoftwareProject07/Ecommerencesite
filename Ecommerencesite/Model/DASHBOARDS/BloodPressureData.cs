using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.DASHBOARDS
{
          public class BloodPressureData
          {
                    //public string Category { get; set; }
                    //public double Value { get; set; }


                    [Key]
                    public int Id { get; set; } // Primary key required by EF Core

                    public int Userid { get; set; } // Foreign key matching customer ID

                    public string Category { get; set; }

                    public double Value { get; set; }
          }
}
