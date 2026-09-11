
using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.DASHBOARDS
{
          public class  DashboardDataModel
          {
                    //public string UserName { get; set; }
                    //public List<BloodGlucoseData> BloodGlucose { get; set; }
                    //public List<WeightProgressData> WeightProgress { get; set; }
                    //public List<BloodPressureData> BloodPressure { get; set; }
                    //public List<CartItem> CartMedicines { get; set; }
                    public DashboardDataModel()
                    {
                              BloodGlucose = new List<BloodGlucoseData>();
                              WeightProgress = new List<WeightProgressData>();
                              BloodPressure = new List<BloodPressureData>();
                              CartMedicines = new List<CartItem>();
                              MedicationTrackers = new List<MedicationTrackerModel>();
                              TestReports = new List<TestReportModel>();
                              HealthHistories = new List<HealthHistoryModel>();
                              MonthlyProgresses = new List<MonthlyProgressModel>();
                              Prescriptions = new List<PrescriptionModel>();
                              HistoryRecords = new List<HistoryModel>();
                              SupportTickets = new List<Help_SupportTicketModel>();
                              AvailableTests = new List<AvailableTestModel>();
                    }

                    [Key]
                    public int id { get; set; }
                //  public int UserId { get; set; }         
                    public string UserName { get; set; }
                    public List<BloodGlucoseData> BloodGlucose { get; set; }
                    public List<WeightProgressData> WeightProgress { get; set; }
                    public List<BloodPressureData> BloodPressure { get; set; }
                    public List<CartItem> CartMedicines { get; set; }

                    // Sidebar items and dynamic features
                    public List<MedicationTrackerModel> MedicationTrackers { get; set; }
                    public List<TestReportModel> TestReports { get; set; }
                    public List<HealthHistoryModel> HealthHistories { get; set; }
                    public List<MonthlyProgressModel> MonthlyProgresses { get; set; }
                    public List<PrescriptionModel> Prescriptions { get; set; }
                    public List<HistoryModel> HistoryRecords { get; set; }
                    public List<Help_SupportTicketModel> SupportTickets { get; set; }
                    public UserSettingsModel Settings { get; set; }

                    // New: Available diagnostic tests for booking (Blood Test, Ultrasound, etc.)
                    public List<AvailableTestModel> AvailableTests { get; set; }
          }
}
