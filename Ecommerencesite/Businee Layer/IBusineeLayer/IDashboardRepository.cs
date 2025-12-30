using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public interface IDashboardRepository
          {
                    DashboardResponseModeldto GetDashboard(int userId);
                public     void CreateDashMedicineReport(Medicationgetmodel objmedication);
                    public void CreateDashboardData( Medicationgetmodel medication, HealthReport healthReport );
          }
}
