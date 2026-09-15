using Ecommerencesite.Model.DASHBOARDS;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IDashBoardServicesRepository
          {
                    public DashboardDataModel GetCustomerDashboard(int customerId);






                    //MEDICATION TRACKER iBUSINESS LAYER CODE

                 public   List<MedicationTrackerModel> GetAllAsync();
                    public MedicationTrackerModel GetByIdAsync(int id);
                    public void AddAsync(MedicationTrackerModel medicationsss);
                    public void UpdateAsync(MedicationTrackerModel medicationssss);
                    MedicationTrackerModel DeleteAsync(int id);

                    //TEST REPORT iBUSINESS LAYER CODE
                    public List<TestReport> AllTestReports();


                    public TestReport GetTestReportById(int id);
                    public void CreateTestReport(TestReport newReport);
                    public void  UpdateTestReport(TestReport updatedReport);
                    public TestReport DeleteTestReport(int id);




                    //HEALTH HISTORY iBUSINESS LAYER CODE

                    //Task<IEnumerable<HealthHistoryModel>> GetByUserIdAsync(int userId);
                    //Task<HealthHistoryModel> GetByIdAsync(int id);
                    //Task<HealthHistoryModel> CreateAsync(HealthHistoryModel history);
                    //Task<bool> UpdateAsync(HealthHistoryModel history);
                    //Task<bool> DeleteAsync(int id);

                    //HEALTH HISTORY iBUSINESS LAYER CODE

                    public List<HealthHistoryModel> GetAllHealthHistories();

               //     Task<IEnumerable<HealthHistoryModel>> GetByUserIdAsync(int userId);
                    public HealthHistoryModel DetailsHealthhistory(int id);
                    public HealthHistoryModel DeleteHealthHistory(int id);
                    public void CreateHealthHistory(HealthHistoryModel createhealthHistory);
                    public void UpdateHealthHistory(HealthHistoryModel updatehelath);


          }
}
