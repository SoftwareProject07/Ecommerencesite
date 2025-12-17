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
                    public DbSet<Medicine> mediciness { get; set; }
                    public DbSet<UserMedicine> userMediciness { get; set; }

          }
}
