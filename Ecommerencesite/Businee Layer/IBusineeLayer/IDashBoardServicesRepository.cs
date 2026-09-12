using Ecommerencesite.Model.DASHBOARDS;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IDashBoardServicesRepository
          {
                    public DashboardDataModel GetCustomerDashboard(int customerId);






                    //MEDICATION TRACKER iBUSINESS LAYER CODE

                 public   List<Medication> GetAllAsync();
                    public Medication GetByIdAsync(int id);
                    public void AddAsync(Medication medicationsss);
                    public void UpdateAsync(Medication medicationssss);
                    Medication DeleteAsync(int id);
                    //TEST REPORT iBUSINESS LAYER CODE
                    public List<TestReport> AllTestReports();


                    public TestReport GetTestReportById(int id);
                    public void CreateTestReport( TestReport newReport);
                    public void  UpdateTestReport(TestReport updatedReport);
                    public TestReport DeleteTestReport(int id);
          }
}
