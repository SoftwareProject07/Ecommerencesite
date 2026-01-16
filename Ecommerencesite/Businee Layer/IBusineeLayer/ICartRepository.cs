using Ecommerencesite.Model;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface ICartRepository
          {
                    Task<List<Cart>> GetMyCart(int userId);
                    Task AddToCart(int userId, int medicineId, int quantity);
          }
}
