using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class DashboardRepository : IDashboardRepository
          {
                    private readonly Ecommerecewebstedatabase _context;
                    public DashboardRepository(Ecommerecewebstedatabase context)
                    {
                              this._context = context;
                    }

                    public void CreateDashMedicineReport(Medicationgetmodel objmedication)
                    {
                            //_context.Medications.Add(new Medicationgetmodel
                            //{
                            //          UserId = objmedication.UserId,
                            //          Name = objmedication.Name,
                            //          Frequency = objmedication.Frequency,
                            //          Dosage = objmedication.Dosage,
                            //          MealTiming = objmedication.MealTiming,
                            //          NextDose = objmedication.NextDose,
                            //          Taken = objmedication.Taken,
                            //          IsMissed = objmedication.IsMissed,
                            //});
                             _context.Medications.Add(objmedication);
                              _context.SaveChanges();
                    }


                    public void CreateDashboardData(  Medicationgetmodel medication,  HealthReport healthReport)
                    {
                              // 🔹 CREATE MEDICATION
                              //Medicationgetmodel medEntity = new Medicationgetmodel
                              //{
                              //          UserId = medication.UserId,
                              //          Name = medication.Name,
                              //          Frequency = medication.Frequency,
                              //          Dosage = medication.Dosage,
                              //          MealTiming = medication.MealTiming,
                              //          NextDose = medication.NextDose,
                              //          Taken = medication.Taken ?? false,
                              //          IsMissed = medication.IsMissed ?? false
                              //};

                              _context.Medications.Add(medication);

                              // 🔹 CREATE HEALTH REPORT
                              healthReport.ReportDate = DateTime.Now;
                              _context.HealthReports.Add(healthReport);

                              _context.SaveChanges();
                    }
    

                    public DashboardResponseModeldto GetDashboard(int userId)
                    {
                              // Latest health report
                              var latestReport = _context.HealthReports
                                  .Where(x => x.UserId == userId)
                                  .OrderByDescending(x => x.ReportDate)
                                  .FirstOrDefault();

                              // Last 7 days weight
                              var weightChart = _context.HealthReports
                                  .Where(x => x.UserId == userId && x.Weight != null)
                                  .OrderBy(x => x.ReportDate)
                                  .Take(7)
                                  .Select(x => new WeightChartModel
                                  {
                                            Date = x.ReportDate!.Value.ToString("dd MMM"),
                                            Weight = x.Weight
                                  })
                                  .ToList();

                              // Medications
                              var medications = _context.Medications
                                  .Where(x => x.UserId == userId)
                                  .Select(x => new Medicationgetmodel
                                  {
                                            Id = x.Id,
                                            UserId = x.UserId,
                                            Name = x.Name,
                                            Frequency = x.Frequency,
                                            Dosage = x.Dosage,
                                            MealTiming = x.MealTiming,
                                            NextDose = x.NextDose,
                                            Taken = x.Taken,
                                            IsMissed = x.IsMissed
                                  })
                                  .ToList();

                              return new DashboardResponseModeldto
                              {
                                        BloodGlucose = latestReport?.BloodGlucose,
                                        BloodPressure = latestReport == null
                                      ? null
                                      : $"{latestReport.Systolic}/{latestReport.Diastolic}",
                                        WeightChart = weightChart,
                                        Medications = medications
                              };
                    }
          }
}