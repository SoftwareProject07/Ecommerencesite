using Ecommerencesite.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerencesite.Database
{
          public class Ecommerecewebstedatabase : DbContext
          {
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
                    // medicine getmodel helath check data
                    public DbSet<Medicationgetmodel> Medications { get; set; }
                    public DbSet<HealthReport> HealthReports { get; set; }
                    public DbSet<AdminREGMODEL> adminREGMODELSs { get; set; }  
                    public DbSet<Patient_CustomerModel> patient_CustomerModels { get; set; }


                    //protected override void OnModelCreating(ModelBuilder modelBuilder)
                    //{
                    //          modelBuilder.Entity<Patient_CustomerModel>()
                    //              .Property(e => e.CreatedOn)
                    //              .HasConversion(
                    //                  v => v.touniver(),
                    //                  v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                    //              );
                    //}

          }
}
