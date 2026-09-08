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

                    //public void CreateOrder(Order order)
                    //{
                    //          _context.orderss.Add(order);
                    //          _context.SaveChanges();
                    //}

                    // 1. ALL ORDERS / SEARCHING FUNCTION
                    public async Task<IEnumerable<Order>> GetAllOrSearchOrdersAsync(string searchQuery)
                    {
                              var query = _context.orderss
                                  .Include(o => o.OrderItemss) // Ensure navigation property matches your model
                                  .AsQueryable();

                              if (!string.IsNullOrEmpty(searchQuery))
                              {
                                        query = query.Where(o =>
                                            o.Id.ToString().Contains(searchQuery) ||
                                            o.OrderStatus.Contains(searchQuery)
                                        );
                              }

                              return await query.ToListAsync();
                    }

                    // 2. DETAILS FUNCTION (Get Order By ID with Items)
                    public async Task<Order> GetOrderDetailsByIdAsync(int orderId)
                    {
                              return await _context.orderss
                                  .Include(o => o.OrderItemss)
                                  .FirstOrDefaultAsync(o => o.Id == orderId);
                    }

                    // 3. UPDATE FUNCTION
                    public async Task<bool> UpdateOrderAsync(int orderId, Order updatedOrderDto)
                    {
                              var existingOrder = await _context.orderss.FindAsync(orderId);
                              if (existingOrder == null) return false;

                              // Update fields as necessary
                              existingOrder.OrderStatus = updatedOrderDto.OrderStatus;
                              existingOrder.Ordertotal = updatedOrderDto.Ordertotal;
                              existingOrder.Address = updatedOrderDto.Address;
                           //   existingOrder. = updatedOrderDto.PaymentMode;

                              _context.orderss.Update(existingOrder);
                              await _context.SaveChangesAsync();
                              return true;
                    }

                    // 4. DELETE FUNCTION
                    public async Task<bool> DeleteOrderAsync(int orderId)
                    {
                              var order = await _context.orderss
                                  .Include(o => o.OrderItemss)
                                  .FirstOrDefaultAsync(o => o.Id == orderId);

                              if (order == null) return false;

                              // Optional: Remove associated order items first if cascade delete isn't configured in DB
                              _context.orderItemss.RemoveRange(order.OrderItemss);
                              _context.orderss.Remove(order);

                              await _context.SaveChangesAsync();
                              return true;
                    }

                    // 1. Get all orders with their respective OrderItems included


                    //public List<Order> ListOrder()
                    //{
                    //          return _context.orderss
                    //              .Include(o => o.orderItemss)
                    //              .Include(o => o.User)
                    //              .Include(o => o.Address)
                    //              .ToList();
                    //}

                    //public List<OrderItem> Listorderitem()
                    //{
                    //          return _context.orderItemss
                    //              .Include(oi => oi.Order)
                    //              .ToList();
                    //}





                    // --- Repository Methods ---

                    //public List<Order> ListOrder()
                    //{
                    //          return _context.orderss
                    //              .Include(o => o.OrderItemss)
                    //              .Include(o => o.User)
                    //              .Include(o => o.Address)
                    //              .ToList();
                    //}

                    public IEnumerable<Order> ListOrder()
                    {
                              // Sirf OrderItemss ko include karein, User ya Address ko nahi
                              return _context.orderss
                                             .Include(o => o.OrderItemss)
                                             .ToList();
                    }
                    public List<OrderItem> Listorderitem()
                    {
                              return _context.orderItemss
                                  .Include(oi => oi.Order)
                                  .ToList();
                    }

                    public void CreateOrder(Order order)
                    {
                              _context.orderss.Add(order);
                              _context.SaveChanges();
                    }
          }
}
