using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model.DASHBOARDS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class TestingDashBoardPanelAPIController : ControllerBase
          {
                    public readonly IDashBoardServicesRepository context;
                    public TestingDashBoardPanelAPIController(IDashBoardServicesRepository _context)
                    {
                              this.context = _context;
                    }
                    [HttpGet("{customerId:int}")]
                    public IActionResult GetCustomerDashboard(int customerId)
                    {
                              var dashboardData = context.GetCustomerDashboard(customerId);

                              if (dashboardData == null || string.IsNullOrEmpty(dashboardData.UserName))
                              {
                                        return NotFound(new { message = $"Customer with ID {customerId} not found." });
                              }

                              return Ok(dashboardData);
                    }



                    //MEDICATION API CONTROLLER CODE
                    
                    [HttpGet("AllMedicationtracker")]
                    public List<MedicationTrackerModel> GetAllMediciation()
                    {
                              var medications = context.GetAllAsync();
                              return medications;

                    }


                    [HttpGet("DetailsMedicationtracker")]
                    public MedicationTrackerModel GetByIdAsync(int id)
                    {
                              var med = context.GetByIdAsync(id);

                              return med;
                    }

                    [HttpPost("CreateMedicationtracker")]
                    public void Create(MedicationTrackerModel medication)
                    {
                              context.AddAsync(medication);
                    }

                    [HttpPut("UpdateMedicationtracker")]
                    public void  Update(MedicationTrackerModel medication)
                    {
                              context.UpdateAsync( medication);
                    }

                    [HttpDelete("DeleteMedicationtracker")]
                    public MedicationTrackerModel DeleteAsync(int id)
                    {
                             var deleteMedicationtracker= context.DeleteAsync(id);
                             return deleteMedicationtracker;
                    }

                    //Testing Dashboard API CONTROLLER CODE 

                    [HttpGet("AllTestReports")]

                    public List<TestReport> AllTestReports()
                    {
                              var testReports = context.AllTestReports();
                              return testReports; 
                    }
                    [HttpGet("DetailsTestReport")]
                    public TestReport GetTestReportById(int id)
                    {
                              var testReport = context.GetTestReportById(id);
                              return testReport;  

                    }
                    [HttpPost("CreateTestReport")]
                    public void CreateTestReport([FromBody] TestReport newReport)
                    {
                              context.CreateTestReport(newReport);
                    }

                    [HttpPut("UpdateTestReport")]
                     
                     public void UpdateTestReport(TestReport updatedReport)
                      {
                               
          
                                 context.UpdateTestReport(updatedReport);
                    }
                    [HttpDelete("DeleteTestReport")]
                    public TestReport DeleteTestReport(int id)
                    {
                              var deletedReport = context.DeleteTestReport(id);
                              return deletedReport;         
                    }




                    // HEALTH HISTORY API CONTROLLER CODE   


                    [HttpGet("AllHealthHistories")]
                      
                    public List<HealthHistoryModel> GetAllHealthHistories()
                    {
                              var listhealthHistories = context.GetAllHealthHistories();
                              return  listhealthHistories;
                    }

                    [HttpGet("DetailsHealthHistory")]
                    public HealthHistoryModel DetailsHealthhistory(int id)
                    {
                              var detailsHealthHistory = context.DetailsHealthhistory(id);
                              return detailsHealthHistory;
                    }

                    [HttpDelete("DeleteHealthHistory")]
                    public HealthHistoryModel DeleteHealthHistory(int id)
                    {
                              var deleteHealthHistory = context.DeleteHealthHistory(id);
                              return deleteHealthHistory;
                    }

                    [HttpPost("CreateHealthHistory")]
                    public void CreateHealthHistory(HealthHistoryModel createhealthHistory)
                    {
                              context.CreateHealthHistory(createhealthHistory);
                    }

                    [HttpPut("UpdateHealthHistory")]
                    public void UpdateHealthHistory(HealthHistoryModel updatehelath)
                    {
                              context.UpdateHealthHistory(updatehelath);
                    }
                    //[HttpGet("GetHealthHistoryByUserId/{userId}")]
                    //Task<IEnumerable<HealthHistoryModel>> GetByUserIdAsync(int userId)
                    //{
                    //          var healthHistories = context.GetByUserIdAsync(userId);
                    //          return healthHistories;
                    //}



          }

}