using Ecommerencesite.Model.DASHBOARDS;
using Ecommerencesite.Model.LABTESTMODEL;
using LabTestApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Identity.Client;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IDashBoardServicesRepository
          {
                    public DashboardDataModel GetCustomerDashboard(int customerId);






                    //MEDICATION TRACKER iBUSINESS LAYER CODE

                    public List<MedicationTrackerModel> GetAllAsync();
                    public MedicationTrackerModel GetByIdAsync(int id);
                    public void AddAsync(MedicationTrackerModel medicationsss);
                    public void UpdateAsync(MedicationTrackerModel medicationssss);
                    MedicationTrackerModel DeleteAsync(int id);

                    //TEST REPORT iBUSINESS LAYER CODE
                    public List<TestReport> AllTestReports();


                    public TestReport GetTestReportById(int id);
                    public void CreateTestReport(TestReport newReport);
                    public void UpdateTestReport(TestReport updatedReport);
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



                    //  MOnthly Progress iBUSINESS LAYER CODE         
                    public List<MonthlyProgressModel> AllMonthlyProgress();
                    public MonthlyProgressModel DetialsMonthlyProgress(int id);
                    public void CreateMonthlyProgress(MonthlyProgressModel newMonthlyProgress);
                    public void UpdateMonthlyProgress(MonthlyProgressModel updatedMonthlyProgress);
                    public MonthlyProgressModel DeleteMonthlyProgress(int id);


                    //PrescriptionModel 

                    public List<PrescriptionModel> AllPrescriptions();
                    public void UpdatePrescription(PrescriptionModel updatedPrescription);

                    public void CreatePrescription(PrescriptionModel newPrescription);
                    public PrescriptionModel DeletePrescription(int id);

                    public PrescriptionModel DetailsPrescription(int id);




                    //Lab Test Model    
                    public List<OfferTestModel> AllOffersAsync();
                    OfferTestModel DetailsOffer(int id);
                    OfferTestModel SearchOffersAsync(string keyword);
                    public void CreateOfferAsync(OfferTestModel model);
                    public void UpdateOfferAsync(OfferTestModel model);
                    public OfferTestModel DeleteOfferAsync(int id);


                    // History Model    
                    public List<HistoryModel> AllHistory();
                    public HistoryModel DetailsHistory(int id);
                    public void CreateHistory(HistoryModel newHistory);
                    public void UpdateHistory(HistoryModel updatedHistory);
                    public HistoryModel DeleteHistory(int id);



                    //Setting Module
                    Task<SettingModule> GetSettingsAsync();
                    Task<bool> UpdateSettingsAsync(SettingModule settingModel);


                    //Help Support Ticket Model
                    public List<HSupportticketdata> AllTicketsAsync();

                    public void CreateTicketAsync(HSupportticketdata helpticket);
                    public void UpdateTicketAsync(HSupportticketdata helpticket);
                    public HSupportticketdata DeleteTicketAsync(int id);
                    public HSupportticketdata DetailsTicket(int id);


          }

}