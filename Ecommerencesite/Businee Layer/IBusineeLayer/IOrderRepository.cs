using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.BusineeLayer
{
          public interface IOrderRepository
          {
                    // public ResponseModel AddToCART(Cart cartsorder);
                    public List<OrderItem> Listorderitem();
                    public List<Order> ListOrder();
                    public void  CreateOrder(Order order);



                    Task<IEnumerable<Order>> GetAllOrSearchOrdersAsync(string searchQuery);

                    // 2. Details Function
                    Task<Order> GetOrderDetailsByIdAsync(int orderId);

                    // 3. Update Function
                    Task<bool> UpdateOrderAsync(int orderId, Order updatedOrderDto);

                    // 4. Delete Function
                    Task<bool> DeleteOrderAsync(int orderId);

          }
}
