using Ecommerencesite.Model;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface ICartRepository
          {
                    //  Task<List<Cart>> GetMyCart(int userId);
                    //Task AddToCart(int userId, int medicineId, int quantity);

                    //public ResponseModel GetUserCartItems(int loggedInUserId);
                    ////trial mode
                    ///

                    //Task<List<object>> GetCartDetails(int userId);


                    ResponseModel AddToCart(Cart cartRequest);

                  //  public ResponseModel AddToCart(int userId, int medicineId, int qty);

                    ResponseModel GetUserCartItems(int loggedInUserId);
                    public int GetCartBadgeCount(int userId);//checking data
                    ResponseModel ListUserCartItem();
                    //Task<List<Cart>> GetcartByEmailAsync(string email);

                 //   Task<List<Cart>> GetAddressesCartByEmailAsync(string email);
                    //List<Cart> GetUserCart(int userId);


          }
}
