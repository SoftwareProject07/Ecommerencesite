using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Ecommerencesite.Model.DASHBOARDS;
using Ecommerencesite.Model.LABTESTMODEL;
using LabTestApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class DashBoardServicesRepository : IDashBoardServicesRepository
{
          public readonly Ecommerecewebstedatabase _context;

          public DashBoardServicesRepository(Ecommerecewebstedatabase context)
          {
                    this._context = context;
          }

          public List<MedicationTrackerModel> GetAllAsync()
          {

                    var medications = _context.MedicationTrackerModels.ToList();
                    return medications;
          }

          public MedicationTrackerModel GetByIdAsync(int id)
          {
                    var medication = _context.MedicationTrackerModels.FirstOrDefault(m => m.Id == id);
                    return medication;
          }

          public void AddAsync(MedicationTrackerModel medicationsss)
          {
                    _context.MedicationTrackerModels.Add(medicationsss);
                    _context.SaveChanges();
          }

          public void UpdateAsync(MedicationTrackerModel medicationssss)
          {
                    _context.MedicationTrackerModels.Update(medicationssss);
                    _context.SaveChanges();
          }

          public MedicationTrackerModel DeleteAsync(int id)
          {
                    var medication = _context.MedicationTrackerModels.Where(S => S.Id == id).FirstOrDefault();
                    if (medication != null)
                    {
                              _context.MedicationTrackerModels.Remove(medication);
                              _context.SaveChanges();
                    }
                    return medication;
          }
          public DashboardDataModel GetCustomerDashboard(int customerId)
          {
                    // 1. Fetch customer name dynamically
                    var customer = _context.userMediciness
                        .Where(c => c.id == customerId)
                        .Select(c => c.FirstName + " " + c.LastName)
                        .FirstOrDefault();

                    // 2. Fetch cart items using UserId
                    var cartMedicines = _context.cartss
                        .Where(ci => ci.UserId == customerId)
                        .Select(ci => new CartItem
                        {
                                  Name = ci.MedicineId.ToString(),
                                  Price = ci.UnitPrice ?? 0,
                                  Quantity = ci.Quantity
                        })
                        .ToList();

                    // 3. Fetch blood glucose records using lowercase id matching your entity definition
                    var bloodGlucose = _context.BloodGlucoseDatas
       .Where(bg => bg.userid == customerId)
       .OrderByDescending(bg => bg.RecordDate)
       .Take(4)
       .Select(bg => new Ecommerencesite.Model.DASHBOARDS.BloodGlucoseData
       {
                 DayLabel = bg.DayLabel,
                 Value = bg.Value
       })
       .ToList();

                    // 4. Fetch weight progress using lowercase id
                    var weightProgress = _context.WeightProgressDatas
                        .Where(wp => wp.Weight == customerId)
                        .OrderBy(wp => wp.Date)
                        .Select(wp => new WeightProgressData
                        {
                                  Date = wp.Date,
                                  Weight = wp.Weight
                        })
                        .ToList();

                    var bloodPressure = _context.BloodPressureDatas
        .Where(bp => bp.Userid == customerId)
        .GroupBy(bp => bp.Category)
        .Select(g => new Ecommerencesite.Model.DASHBOARDS.BloodPressureData
        {
                  Category = g.Key,
                  Value = g.Count()
        })
        .ToList();

                    return new DashboardDataModel
                    {
                              UserName = customer,
                              BloodGlucose = bloodGlucose,
                              WeightProgress = weightProgress,
                              BloodPressure = bloodPressure,
                              CartMedicines = cartMedicines
                    };
          }

          public List<TestReport> AllTestReports()
          {
                    var testReports = _context.TestReports.ToList();
                    return testReports;
          }

          public TestReport GetTestReportById(int id)
          {
                    var testReport = _context.TestReports.FirstOrDefault(tr => tr.Id == id);
                    return testReport;
          }

          public void CreateTestReport(TestReport newReport)
          {
                    _context.TestReports.Add(newReport);
                    _context.SaveChanges();
          }

          public void UpdateTestReport(TestReport updatedReport)
          {
                    _context.TestReports.Update(updatedReport);
                    _context.SaveChanges();

          }

          public TestReport DeleteTestReport(int id)
          {
                    var reportToDelete = _context.TestReports.FirstOrDefault(tr => tr.Id == id);
                    if (reportToDelete != null)
                    {
                              _context.TestReports.Remove(reportToDelete);
                              _context.SaveChanges();
                    }
                    return reportToDelete;
          }

          public List<HealthHistoryModel> GetAllHealthHistories()
          {
                    var listhealthHistories = _context.HealthHistoryModels.ToList();
                    return listhealthHistories;
          }

          public HealthHistoryModel DetailsHealthhistory(int id)
          {
                    var detailsHealthHistory = _context.HealthHistoryModels.FirstOrDefault(hh => hh.Id == id);
                    return detailsHealthHistory;
          }

          public HealthHistoryModel DeleteHealthHistory(int id)
          {
                    var deleteHealthHistory = _context.HealthHistoryModels.FirstOrDefault(hh => hh.Id == id);
                    if (deleteHealthHistory != null)
                    {
                              _context.HealthHistoryModels.Remove(deleteHealthHistory);
                              _context.SaveChanges();
                    }
                    return deleteHealthHistory;
          }

          public void CreateHealthHistory(HealthHistoryModel createhealthHistory)
          {
                    _context.HealthHistoryModels.Add(createhealthHistory);
                    _context.SaveChanges();
          }

          public void UpdateHealthHistory(HealthHistoryModel updatehelath)
          {
                    _context.HealthHistoryModels.Update(updatehelath);
                    _context.SaveChanges();
          }


          //MonthlyProgressModel 
          public List<MonthlyProgressModel> AllMonthlyProgress()
          {
                    var listMonthlyProgress = _context.MonthlyProgressModels.ToList();
                    return listMonthlyProgress;
          }

          public MonthlyProgressModel DetialsMonthlyProgress(int id)
          {
                    var detailsMonthlyProgress = _context.MonthlyProgressModels.FirstOrDefault(mp => mp.Id == id);
                    return detailsMonthlyProgress;
          }

          public void CreateMonthlyProgress(MonthlyProgressModel newMonthlyProgress)
          {
                    _context.MonthlyProgressModels.Add(newMonthlyProgress);
                    _context.SaveChanges();
          }

          public void UpdateMonthlyProgress(MonthlyProgressModel updatedMonthlyProgress)
          {
                    _context.MonthlyProgressModels.Update(updatedMonthlyProgress);
                    _context.SaveChanges();
          }

          public MonthlyProgressModel DeleteMonthlyProgress(int id)
          {
                    var deleteMonthlyProgress = _context.MonthlyProgressModels.FirstOrDefault(mp => mp.Id == id);
                    if (deleteMonthlyProgress != null)
                    {
                              _context.MonthlyProgressModels.Remove(deleteMonthlyProgress);
                              _context.SaveChanges();
                    }
                    return deleteMonthlyProgress;
          }
          // prescription Business Logic          
          //public List<PrescriptionModel> AllPrescriptions()
          //{
          //       var listPrescriptions = _context.PrescriptionModels.ToList();
          //          return listPrescriptions;     
          //}

          public List<PrescriptionModel> AllPrescriptions()
          {
                    // .Include(p => p.Medicines) लगाने से दवाइयों का डेटा साथ में आ जाएगा
                    var prescriptionList = _context.PrescriptionModels
                                                   .Include(p => p.Medicines)
                                                   .ToList();
                    return prescriptionList;
          }


          public void UpdatePrescription(PrescriptionModel updatedPrescription)
          {
                    _context.PrescriptionModels.Update(updatedPrescription);
                    _context.SaveChanges();
          }

          public void CreatePrescription(PrescriptionModel newPrescription)
          {
                    _context.PrescriptionModels.Add(newPrescription);
                    _context.SaveChanges();
          }

          public PrescriptionModel DeletePrescription(int id)
          {
                    var deletePrescription = _context.PrescriptionModels.FirstOrDefault(p => p.Id == id);
                    if (deletePrescription != null)
                    {
                              _context.PrescriptionModels.Remove(deletePrescription);
                              _context.SaveChanges();
                    }
                    return deletePrescription;
          }

          //public PrescriptionModel DetailsPrescription(int id)
          //{
          //         var detailsPrescription = _context.PrescriptionModels.FirstOrDefault(p => p.Id == id);
          //          return detailsPrescription;   
          //}


          public PrescriptionModel DetailsPrescription(int id)
          {
                    // यहाँ भी .Include(p => p.Medicines) जोड़ें ताकि सिंगल डिटेल्स में भी दवाइयां दिखें
                    var prescription = _context.PrescriptionModels
                                               .Include(p => p.Medicines)
                                               .FirstOrDefault(p => p.Id == id);

                    if (prescription == null)
                    {
                              throw new Exception("Prescription not found with ID: " + id);
                    }

                    return prescription;
          }


          //labtestmodeladdmin
          public List<OfferTestModel> AllOffersAsync()
          {
                    var listoffer = _context.OfferTestModels.ToList();
                    return listoffer;
          }

          public OfferTestModel DetailsOffer(int id)
          {
                    var detailsOffer = _context.OfferTestModels.FirstOrDefault(o => o.Id == id);
                    return detailsOffer;
          }

          public OfferTestModel SearchOffersAsync(string keyword)
          {
                    var searchOffer = _context.OfferTestModels.FirstOrDefault(o => o.TestName.Contains(keyword));
                    return searchOffer;
          }

          public void CreateOfferAsync(OfferTestModel model)
          {
                    _context.OfferTestModels.Add(model);
                    _context.SaveChanges();
          }

          public void UpdateOfferAsync(OfferTestModel model)
          {
                    _context.OfferTestModels.Update(model);
                    _context.SaveChanges();
          }

          public OfferTestModel DeleteOfferAsync(int id)
          {
                    var deleteOffer = _context.OfferTestModels.FirstOrDefault(o => o.Id == id);
                    if (deleteOffer != null)
                    {
                              _context.OfferTestModels.Remove(deleteOffer);
                              _context.SaveChanges();
                    }
                    return deleteOffer;
          }
          //business layer -- history model 
          public List<HistoryModel> AllHistory()
          {
                    var listhistory = _context.HistoryModels.ToList();
                    return listhistory;
          }

          public HistoryModel DetailsHistory(int id)
          {
                    var detailsHistory = _context.HistoryModels.FirstOrDefault(h => h.Id == id);
                    return detailsHistory;
          }

          public void CreateHistory(HistoryModel newHistory)
          {
                    _context.HistoryModels.Add(newHistory);
                    _context.SaveChanges();
          }

          public void UpdateHistory(HistoryModel updatedHistory)
          {
                    _context.HistoryModels.Update(updatedHistory);
                    _context.SaveChanges();
          }

          public HistoryModel DeleteHistory(int id)
          {
                    var deleteHistory = _context.HistoryModels.FirstOrDefault(h => h.Id == id);
                    if (deleteHistory != null)
                    {
                              _context.HistoryModels.Remove(deleteHistory);
                              _context.SaveChanges();
                    }
                    return deleteHistory;
          }

          public async Task<SettingModule> GetSettingsAsync()
          {
                    var setting = await _context.SettingModules.FirstOrDefaultAsync();
                    if (setting == null)
                    {
                              setting = new SettingModule();
                              _context.SettingModules.Add(setting);
                              await _context.SaveChangesAsync();
                    }
                    return setting;
          }

          public async Task<bool> UpdateSettingsAsync(SettingModule settingModel)
          {
                    var existing = await _context.SettingModules.FirstOrDefaultAsync();
                    if (existing == null)
                    {
                              _context.SettingModules.Add(settingModel);
                              return await _context.SaveChangesAsync() > 0;
                    }

                    // Existing fields ko update karein
                    existing.EmailNotifications = settingModel.EmailNotifications;
                    existing.SmsNotifications = settingModel.SmsNotifications;
                    existing.TwoFactorAuth = settingModel.TwoFactorAuth;
                    existing.ThemeMode = settingModel.ThemeMode;
                    existing.Language = settingModel.Language;
                    existing.UpdatedAt = DateTime.UtcNow;

                    _context.SettingModules.Update(existing);
                    return await _context.SaveChangesAsync() > 0;
          }


          public List<HSupportticketdata> AllTicketsAsync()
          {
                    // Database se saare tickets fetch karna
                    // return await _context.SupportTickets.ToListAsync();

                    // Dummy implementation for reference
                    var listhelpsupport = _context.HSupportTicketdatas.ToList();
                    return listhelpsupport;
          }
          // Naya Ticket Create karne ka logic
          public void CreateTicketAsync(HSupportticketdata helpticket)
          {
                  
                    // await _context.SaveChangesAsync();
                    _context.HSupportTicketdatas.Add(helpticket);
                    _context.SaveChangesAsync();
                    // return true;

          }

          public void UpdateTicketAsync(HSupportticketdata helpticket)
          {
                   _context.HSupportTicketdatas.Update(helpticket);
                    _context.SaveChanges();
          }

          public HSupportticketdata DeleteTicketAsync(int id)
          {
                    var deleteTicket = _context.HSupportTicketdatas.FirstOrDefault(t => t.Id == id);
                    if (deleteTicket != null)
                    {
                              _context.HSupportTicketdatas.Remove(deleteTicket);
                              _context.SaveChanges();
                    }
                    return deleteTicket;
          }

          public HSupportticketdata DetailsTicket(int id)
          {
                    var detailsTicket = _context.HSupportTicketdatas.FirstOrDefault(t => t.Id == id);
                    return detailsTicket;         
          }
}












          //public async Task<IEnumerable<HealthHistoryModel>> GetByUserIdAsync(int userId)
          //{
          //          return await _context.HealthHistoryModels
          //              .Where(h => h.UserId == userId)
          //              .OrderByDescending(h => h.DiagnosisDate)
          //              .ToListAsync();
          //}

          //public Task UpdateAsync(Medication medication)
          //{
          //          throw new NotImplementedException();
          //}
