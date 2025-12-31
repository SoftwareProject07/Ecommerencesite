using Ecommerencesite.Model;

namespace Ecommerencesite.MODELDTO
{
          public class DashboardResponseModeldto
          {
                    public int? BloodGlucose { get; set; }
                    public string? BloodPressure { get; set; } = null;
                    public List<WeightChartModel> WeightChart { get; set; } = new();
                    public List<Medicationgetmodel> Medications { get; set; } = new();
          }

          public class WeightChartModel
          {
                    public string Date { get; set; } = null;
                    public decimal? Weight { get; set; } = null;
          }
}

