using Ecommerencesite.Model.DASHBOARDS;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IDashBoardServicesRepository
          {
                    public DashboardDataModel GetCustomerDashboard(int customerId);






                    //MEDICATION iBUSINESS LAYER CODE

                 public   List<Medication> GetAllAsync();
                    public Medication GetByIdAsync(int id);
                    public void AddAsync(Medication medicationsss);
                    public void UpdateAsync(Medication medicationssss);
                              Task DeleteAsync(int id);
          }
}
