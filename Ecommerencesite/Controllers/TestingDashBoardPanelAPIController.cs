using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model.DASHBOARDS;
using Ecommerencesite.Model.LABTESTMODEL;
using LabTestApp.Models;
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







                    //MonthlyProgressModel API CONTROLLER CODE        


                    [HttpGet("AllMonthlyProgress")]         
              public List<MonthlyProgressModel> AllMonthlyProgress()
                    {
                              var monthlyProgressList = context.AllMonthlyProgress();
                              return monthlyProgressList;
                    }

                    [HttpGet("DetailsMonthlyProgress")]
                    public MonthlyProgressModel DetialsMonthlyProgress(int id)
                    {
                              var detailsMonthlyProgress = context.DetialsMonthlyProgress(id);
                              return detailsMonthlyProgress;
                    }
                   
                    [HttpPost("CreateMonthlyProgress")]
                    public void CreateMonthlyProgress(MonthlyProgressModel newMonthlyProgress)
                    {
                              context.CreateMonthlyProgress(newMonthlyProgress);
                    }

                    [HttpPut("UpdateMonthlyProgress")]
                    public void UpdateMonthlyProgress(MonthlyProgressModel updatedMonthlyProgress)
                    {
                              context.UpdateMonthlyProgress(updatedMonthlyProgress);
                    }

                    [HttpDelete("DeleteMonthlyProgress")]
                    public MonthlyProgressModel DeleteMonthlyProgress(int id)
                    {
                              var deletedMonthlyProgress = context.DeleteMonthlyProgress(id);
                              return deletedMonthlyProgress;
                    }



                    //PrescriptionModel API CONTROLLER CODE 
                    [HttpGet("AllPrescriptions")]
                    public List<PrescriptionModel> AllPrescriptions()
                    {
                              var prescriptionList = context.AllPrescriptions();
                              return prescriptionList;
                    }

                    [HttpGet("DetailsPrescription")]
                    public PrescriptionModel DetailsPrescription(int id)
                    {
                              var detailsPrescription = context.DetailsPrescription(id);
                              return detailsPrescription;
                    }

                    //[HttpPost("CreatePrescription")]
                    //public void CreatePrescription(PrescriptionModel newPrescription)
                    //{
                    //          context.CreatePrescription(newPrescription);
                    //}





                    //[HttpPost("CreatePrescription")]
                    //public IActionResult CreatePrescription( PrescriptionModel model)
                    //{
                    //          if (model == null)
                    //          {
                    //                    return BadRequest(new { success = false, message = "Invalid data" });
                    //          }

                    //          try
                    //          {
                    //                    // यहाँ अपना डेटाबेस सेव करने का लॉजिक लिखें (DbContext.Add etc.)
                    //                    // _context.Prescriptions.Add(model);
                    //                    // _context.SaveChanges();

                    //                    return Ok(new { success = true, message = "Prescription created successfully", data = model });
                    //          }
                    //          catch (Exception ex)
                    //          {
                    //                    return StatusCode(500, new { success = false, message = ex.Message });
                    //          }
                    //}



                    [HttpPost("CreatePrescription")]
                    public void CreatePrescription([FromBody] PrescriptionModel model)
                    {
                              if (model == null)
                              {
                                        throw new ArgumentException("Prescription model cannot be null.");
                              }

                              try
                              {
                                        // _context आपके डेटाबेस DbContext का नाम होना चाहिए
                                        context.CreatePrescription(model);
                                    //    _context.SaveChanges();
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Error saving to database: " + ex.Message);
                              }
                    }

                    [HttpPut("UpdatePrescription")]
                    public void UpdatePrescription(PrescriptionModel updatedPrescription)
                    {
                              context.UpdatePrescription(updatedPrescription);
                    }

                    [HttpDelete("DeletePrescription")]
                    public PrescriptionModel DeletePrescription(int id)
                    {
                              var deletedPrescription = context.DeletePrescription(id);
                              return deletedPrescription;
                    }

                    // Lab Test Model API CONTROLLER CODE   

                    [HttpGet("AllOffersAsync")]
                    public List<OfferTestModel> AllOffersAsync()
                    {
                              var offersList = context.AllOffersAsync();
                              return offersList;
                    }

                    [HttpGet("DetailsOffer")]
                    public OfferTestModel DetailsOffer(int id)
                    {
                              var detailsOffer = context.DetailsOffer(id);
                              return detailsOffer;
                    }


                    [HttpGet("SearchOffersAsync")]
                    public OfferTestModel SearchOffersAsync(string keyword)
                    {
                              var searchResult = context.SearchOffersAsync(keyword);
                              return searchResult;
                    }


                    [HttpPost("CreateOfferAsync")]
                    public void CreateOfferAsync(OfferTestModel model)
                    {
                              context.CreateOfferAsync(model);
                    }

                    [HttpPut("UpdateOfferAsync")]
                    public void UpdateOfferAsync(OfferTestModel model)
                    {
                              context.UpdateOfferAsync(model);
                    }

                    [HttpDelete("DeleteOfferAsync")]
                    public OfferTestModel DeleteOfferAsync(int id)
                    {
                              var deletedOffer = context.DeleteOfferAsync(id);
                              return deletedOffer;
                    }


                    //HISTORY MODEL API 
                    [HttpGet("AllHistory")]
                    public List<HistoryModel> AllHistory()
                    {
                                                           var historyList = context.AllHistory();
                              return historyList;
                    }

                    [HttpGet("DetailsHistory")]
                    public HistoryModel DetailsHistory(int id)
                    {
                              var detailsHistory = context.DetailsHistory(id);
                              return detailsHistory;
                    }

                    [HttpPost("CreateHistory")]
                    
                    public void CreateHistory(HistoryModel newHistory)
                    {
                              context.CreateHistory(newHistory);
                    }

                    [HttpPut("UpdateHistory")]
                    public void UpdateHistory(HistoryModel updatedHistory)
                    {
                              context.UpdateHistory(updatedHistory);
                    }

                    [HttpDelete("DeleteHistory")]
                    public HistoryModel DeleteHistory(int id)
                    {
                              var deletedHistory = context.DeleteHistory(id);
                              return deletedHistory;
                    }


                    // GET: api/usersettings/GetUserSettings
                    [HttpGet("AllSettings")]
                    public async Task<IActionResult> GetUserSettings()
                    {
                              var settings = await context.GetSettingsAsync();
                              return Ok(settings);
                    }

                    // POST: api/usersettings/UpdateUserSettings
                    [HttpPost("UpdateSettings")]
                    public async Task<IActionResult> UpdateUserSettings([FromBody] SettingModule settingModel)
                    {
                              var success = await context.UpdateSettingsAsync(settingModel);
                              if (!success) return BadRequest(new { message = "Failed to update settings" });

                              return Ok(new { success = true, message = "Settings updated successfully" });
                    }


                    // GET: api/helpsupport/tickets
                    [HttpGet("AllticketHelpSupport")]
                    public List<HSupportticketdata> AllTicketsAsync()
                    {
                              var tickets = context.AllTicketsAsync();
                              return tickets;
                    }

                    // POST: api/helpsupport/ticket
                    [HttpPost("CreateticketHelpSupport")]
                    public void CreateTicket(HSupportticketdata helpticket)
                    {
                              context.CreateTicketAsync(helpticket);
                    }


                    [HttpPut("UpdateticketHelpSupport")]
                    public void UpdateTicketAsync(HSupportticketdata helpticket)
                    {
                              context.UpdateTicketAsync(helpticket);
                    }
                    [HttpDelete("DeleteticketHelpSupport")] 
                    public HSupportticketdata DeleteTicketAsync(int id)
                    {
                              var deletedTicket = context.DeleteTicketAsync(id);
                              return deletedTicket;
                    }
                    [HttpGet("DetailsTicket")]
                    public HSupportticketdata DetailsTicket(int id)
                    {
                              var detailsTicket = context.DetailsTicket(id);
                              return detailsTicket;
                    }





          }

}