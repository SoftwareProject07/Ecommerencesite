namespace Ecommerencesite.Model
{
          public class Medicationgetmodel
          {
                   
                              public int Id { get; set; }
                              public int UserId { get; set; }
                              public string? Name { get; set; }
                              public string? Frequency { get; set; }
                              public string? Dosage { get; set; }
                              public string? MealTiming { get; set; }
                              public TimeSpan? NextDose { get; set; }
                              public bool? Taken { get; set; }
                              public bool? IsMissed { get; set; }
                  
          }
          public class HealthReport
          {
                    public int Id { get; set; }
                    public int UserId { get; set; }
                    public DateTime? ReportDate { get; set; }
                    public int BloodGlucose { get; set; }
                    public int Systolic { get; set; }
                    public int Diastolic { get; set; }
                    public decimal? Weight { get; set; }
          }


}
