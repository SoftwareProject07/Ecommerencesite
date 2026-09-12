using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Ecommerencesite.Model.DASHBOARDS;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class DashBoardServicesRepository : IDashBoardServicesRepository         
{
          public  readonly Ecommerecewebstedatabase _context;

          public DashBoardServicesRepository(Ecommerecewebstedatabase context)
          {
                   this._context   = context;
          }

          public   List<Medication> GetAllAsync()
          {

                    var medications = _context.Medicationss.ToList();
                    return medications;
          }

          public Medication GetByIdAsync(int id)
          {
                 var medication = _context.Medicationss.FirstOrDefault(m => m.Id == id);
                       return medication;
          }

          public void AddAsync(Medication medicationsss)
          {
                    _context.Medicationss.Add(medicationsss);
                     _context.SaveChanges();
          }

          public void  UpdateAsync(Medication medicationssss)
          {
                    _context.Medicationss.Update(medicationssss);
                     _context.SaveChanges();
          }

          public Medication DeleteAsync(int id)
          {
                    var medication =  _context.Medicationss.Where(S=>S.Id==id).FirstOrDefault();
                    if (medication != null)
                    {
                              _context.Medicationss.Remove(medication);
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

          public void CreateTestReport( TestReport newReport)
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

          //public Task UpdateAsync(Medication medication)
          //{
          //          throw new NotImplementedException();
          //}
}