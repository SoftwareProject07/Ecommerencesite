namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface ICartRepository
          {
                    Task AddToCart(int userId, int medicineId, int quantity);

          }
}
