using Ecommerencesite.Model;
using Ecommerencesite.Model.DASHBOARDS;
using HelpDeskAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerencesite.Database
{
          public class Ecommerecewebstedatabase : DbContext
          {

                    public Ecommerecewebstedatabase(DbContextOptions<Ecommerecewebstedatabase> options) : base(options)
                    {
                    }
                    public DbSet<ResponseModel> responseModelss { get; set; }
                    public DbSet<Cart> cartss { get; set; }
                    public DbSet<Order> orderss { get; set; }
                    public DbSet<OrderItem> orderItemss { get; set; }

                    protected override void OnModelCreating(ModelBuilder modelBuilder)
                    {
                              base.OnModelCreating(modelBuilder);

                              // Explicit relationship configuration (Optional since data annotations are already used)
                              modelBuilder.Entity<Order>()
                                  .HasMany(o => o.OrderItemss)
                                  .WithOne(oi => oi.Order)
                                  .HasForeignKey(oi => oi.OrderId)
                                  .OnDelete(DeleteBehavior.Cascade);



                              modelBuilder.Entity<Order>()
        .HasMany(o => o.OrderItemss)
        .WithOne(i => i.Order)
        .HasForeignKey(i => i.OrderId);
                    }



                    public DbSet<Medicine> medicinesss { get; set; }
                    public DbSet<UserMedicine> userMediciness { get; set; }//User 
                    public DbSet<Medicationgetmodel> Medications { get; set; }
                    public DbSet<HealthReport> HealthReports { get; set; }
                    public DbSet<AdminREGMODEL> adminREGMODELSs { get; set; }
                    public DbSet<Patient_CustomerModel> patient_CustomerModels { get; set; }
                    public DbSet<FeedbackCusotmerModel> feedbackCusotmerModels { get; set; }
                    public DbSet<CustomerHelpIssueModel> customerHelpIssueModels { get; set; }
                    public DbSet<CustomerAddMedicineModel> customerAddMedicineModels { get; set; }
                    public DbSet<bankdetailsModles> bankdetailsModless { get; set; }
                    public DbSet<bankselectmodels> bankselectmodelss { get; set; }
                    public DbSet<QRCashCodeModels> qRCashCodeModelss { get; set; }

                    public DbSet<MedicineChat> MedicineChats { get; set; }
                    // Liveness trials
                    public DbSet<LivenessCheckRequestModel> livenessrequestcheckmodel { get; set; }
                    public DbSet<CustomerTicketRaiseModel> CustomerTicketRaise { get; set; }
                    public DbSet<AssignRaiseTicketModel> AssignRaiseTicket { get; set; }
                    public DbSet<IssueCategorymasterModel> issuecategorymasterModels { get; set; }
                    public DbSet<BankRefundableAmountModel> BankRefundableAmountModels { get; set; }
                    public DbSet<deliverypartnermodel> deliverypartnermodels { get; set; }
                    public DbSet<DoctorAssigntoPatientMOdel> doctorAssigntoPatientMOdels { get; set; }
                    public DbSet<PatientDetailsModel> patientDetailsModels { get; set; }

                    public DbSet<AdminTypeModel> admintypess { get; set; }
                    public DbSet<choice_MultipleLanguageModel> choicemultiplelanguagemodel { get; set; }



                    //master
                    public DbSet<StateNameModel> stateNameModels { get; set; }
                    public DbSet<CityMasterModel> cityMasterModels { get; set; }



                    //hiring/applied module 
                    public DbSet<Team_HiringModules> team_hiringmodules { get; set; }
                    public DbSet<CandidateApplicationModule> candidateapplicationmodules { get; set; }


                    public DbSet<CustomerAccountantAccount> customerAccountantAccounts { get; set; }

                    public DbSet<DeliveryAssigntoModel> deliveryAssigntoModells { get; set; }


                    //Dashboard related models
                    public DbSet<BloodGlucoseData> BloodGlucoseDatas { get; set; }
                    public DbSet<WeightProgressData> WeightProgressDatas { get; set; }
                    public DbSet<BloodPressureData> BloodPressureDatas { get; set; }
                    public DbSet<CartItem> CartItems { get; set; }
                    public DbSet<DashboardDataModel> DashboardDataModels { get; set; }
                    public DbSet<MedicationTrackerModel> MedicationTrackerModels { get; set; }
                    public DbSet<TestReportModel> TestReportModels { get; set; }
                    public DbSet<HealthHistoryModel> HealthHistoryModels { get; set; }
                    public DbSet<MonthlyProgressModel> MonthlyProgressModels { get; set; }
                    public DbSet<PrescriptionModel> PrescriptionModels { get; set; }
                    public DbSet<HistoryModel> HistoryModels { get; set; }
                    public DbSet<Help_SupportTicketModel> SupportTicketModels { get; set; }
                    public DbSet<UserSettingsModel> UserSettingsModels { get; set; }
                    public DbSet<AvailableTestModel> AvailableTestModels { get; set; }


                   
          }




}













//using Ecommerencesite.Model;
//using Ecommerencesite.Model.DASHBOARDS;
//using HelpDeskAPI.Models;
//using Microsoft.EntityFrameworkCore;

//public class Ecommerecewebstedatabase : DbContext
//{
//          public Ecommerecewebstedatabase(DbContextOptions<Ecommerecewebstedatabase> options)
//              : base(options)
//          {
//          }

//          // Core Tables & Entities
//          public DbSet<ResponseModel> responseModelss { get; set; }
//          public DbSet<Cart> cartss { get; set; }
//          public DbSet<Order> orderss { get; set; }
//          public DbSet<OrderItem> orderItemss { get; set; }
//          public DbSet<Medicine> medicinesss { get; set; }
//          public DbSet<UserMedicine> userMediciness { get; set; }
//          public DbSet<Medicationgetmodel> Medications { get; set; }
//          public DbSet<HealthReport> HealthReports { get; set; }
//          public DbSet<AdminREGMODEL> adminREGMODELSs { get; set; }
//          public DbSet<Patient_CustomerModel> patient_CustomerModels { get; set; }
//          public DbSet<FeedbackCusotmerModel> feedbackCusotmerModels { get; set; }
//          public DbSet<CustomerHelpIssueModel> customerHelpIssueModels { get; set; }
//          public DbSet<CustomerAddMedicineModel> customerAddMedicineModels { get; set; }
//          public DbSet<bankdetailsModles> bankdetailsModless { get; set; }
//          public DbSet<bankselectmodels> bankselectmodelss { get; set; }
//          public DbSet<QRCashCodeModels> qRCashCodeModelss { get; set; }
//          public DbSet<MedicineChat> MedicineChats { get; set; }
//          public DbSet<LivenessCheckRequestModel> livenessrequestcheckmodel { get; set; }
//          public DbSet<CustomerTicketRaiseModel> CustomerTicketRaise { get; set; }
//          public DbSet<AssignRaiseTicketModel> AssignRaiseTicket { get; set; }
//          public DbSet<IssueCategorymasterModel> issuecategorymasterModels { get; set; }
//          public DbSet<BankRefundableAmountModel> BankRefundableAmountModels { get; set; }
//          public DbSet<deliverypartnermodel> deliverypartnermodels { get; set; }
//          public DbSet<DoctorAssigntoPatientMOdel> doctorAssigntoPatientMOdels { get; set; }
//          public DbSet<PatientDetailsModel> patientDetailsModels { get; set; }
//          public DbSet<AdminTypeModel> admintypess { get; set; }
//          public DbSet<choice_MultipleLanguageModel> choicemultiplelanguagemodel { get; set; }
//          public DbSet<StateNameModel> stateNameModels { get; set; }
//          public DbSet<CityMasterModel> cityMasterModels { get; set; }
//          public DbSet<Team_HiringModules> team_hiringmodules { get; set; }
//          public DbSet<CandidateApplicationModule> candidateapplicationmodules { get; set; }
//          public DbSet<CustomerAccountantAccount> customerAccountantAccounts { get; set; }
//          public DbSet<DeliveryAssigntoModel> deliveryAssigntoModells { get; set; }

//          // Database Entities for Dashboard (Must be Entity classes with [Key], NOT ViewModels)
//          public DbSet<BloodGlucoseData> BloodGlucoseDatas { get; set; }
//          public DbSet<WeightProgressData> WeightProgressRecords { get; set; }
//          public DbSet<BloodPressureData> BloodPressureRecords { get; set; }

//          protected override void OnModelCreating(ModelBuilder modelBuilder)
//          {
//                    base.OnModelCreating(modelBuilder);

//                    modelBuilder.Entity<Order>()
//                        .HasMany(o => o.OrderItemss)
//                        .WithOne(oi => oi.Order)
//                        .HasForeignKey(oi => oi.OrderId)
//                        .OnDelete(DeleteBehavior.Cascade);
//          }
//}