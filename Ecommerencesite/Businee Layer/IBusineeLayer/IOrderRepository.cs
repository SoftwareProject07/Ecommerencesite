using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.BusineeLayer
{
          public interface IOrderRepository
          {
                    // public ResponseModel AddToCART(Cart cartsorder);
                    public List<OrderItem> Listorderitem();
                    public List<Order> ListOrder();
                    public void  CreateOrder(Order order);

          }
}
