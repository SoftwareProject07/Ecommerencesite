using Ecommerencesite.Model;

namespace Ecommerencesite.MODELDTO
{
          public class DashboardResponseModeldto
          {
                    public int? BloodGlucose { get; set; }
                    public string? BloodPressure { get; set; }
                    public List<WeightChartModel> WeightChart { get; set; } = new();
                    public List<Medicationgetmodel> Medications { get; set; } = new();
          }

          public class WeightChartModel
          {
                    public string Date { get; set; }
                    public decimal? Weight { get; set; }
          }
}

