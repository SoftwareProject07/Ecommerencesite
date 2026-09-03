using Ecommerencesite.Businee_Layer.BusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class OrderRepository : IOrderRepository
          {
                    private readonly Ecommerecewebstedatabase _context;
                    public OrderRepository(Ecommerecewebstedatabase context)
                    {
                              this._context = context;

                    }

                    public void CreateOrder(Order order)
                    {
                              _context.orderss.Add(order);
                              _context.SaveChanges();
                    }

                    // 1. Get all orders with their respective OrderItems included
                    public List<Order> ListOrder()
                    {
                              return _context.orderss
                                  .Include(o => o.orderItemss) // Ye order ke andar ke sabhi items le aayega
                                  .Include(o => o.User)       // Optional: User details lane ke liye
                                  .Include(o => o.Address)    // Optional: Delivery address lane ke liye
                                  .ToList();
                    }

                    // 2. Get all individual order items
                    public List<OrderItem> Listorderitem()
                    {
                              return _context.orderItemss
                                  .Include(oi => oi.Order)    // Optional: Item ke sath parent order ki details ke liye
                                  .ToList();
                    }

          }
}
