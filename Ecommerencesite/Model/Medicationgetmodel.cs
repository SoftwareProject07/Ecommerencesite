namespace Ecommerencesite.Model
{
          public class Medicationgetmodel
          {
                   
                              public int Id { get; set; }
                              public int UserId { get; set; }
                    public string? Name { get; set; } = null;
                    public string? Frequency { get; set; } = null;
                    public string? Dosage { get; set; } = null;
                    public string? MealTiming { get; set; } = null;
                    public TimeSpan? NextDose { get; set; } = null;
                    public bool? Taken { get; set; } = null;
                    public bool? IsMissed { get; set; } = null;
                  
          }
          public class HealthReport
          {
                    public int Id { get; set; }
                    public int UserId { get; set; }
                    public DateTime? ReportDate { get; set; } = null;
                    public int BloodGlucose { get; set; } 
                    public int Systolic { get; set; } 
                    public int Diastolic { get; set; }
                    public decimal? Weight { get; set; } = null;
          }


}
