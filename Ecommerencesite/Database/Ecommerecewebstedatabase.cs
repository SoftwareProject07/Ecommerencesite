using Ecommerencesite.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerencesite.Database
{
          public class Ecommerecewebstedatabase :DbContext
          {
                    public Ecommerecewebstedatabase(DbContextOptions<Ecommerecewebstedatabase> option) : base(option) 
                    {
                    }
                    public DbSet<ResponseModel> responseModels { get; set; }
                    public DbSet<Cart> carts { get; set; }
                    public DbSet<Order> orders { get; set; }
                    public DbSet<OrderItem> orderItems { get; set; }
                    public DbSet<Medicine> medicines { get; set; }
                    public DbSet<UserMedicine> userMedicines { get; set; }

          }
}
