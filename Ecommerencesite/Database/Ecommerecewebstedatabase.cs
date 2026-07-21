using Ecommerencesite.Model;
using HelpDeskAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerencesite.Database
{
          public class Ecommerecewebstedatabase : DbContext
          {
                    internal readonly object BankRefundableAmounts;

                    public Ecommerecewebstedatabase(
                        DbContextOptions<Ecommerecewebstedatabase> options
                    ) : base(options)
                    {
                    }
                    public DbSet<ResponseModel> responseModelss { get; set; }
                    public DbSet<Cart> cartss { get; set; }
                    public DbSet<Order> orderss { get; set; }
                    public DbSet<OrderItem> orderItemss{ get; set; }
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

          }
}
