using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class CartRepository : ICartRepository
          {
                    private   readonly Ecommerecewebstedatabase _context;
                              public CartRepository(Ecommerecewebstedatabase context)
                    {
                              this._context= context;
                    }

                    public ResponseModel AddToCart(Cart cartRequest)
                    {
                              ResponseModel response = new ResponseModel();

                              try
                              {
                                        if (cartRequest.UserId <= 0)
                                        {
                                                  response.status = false;
                                                  response.responseMessage = "User not logged in";
                                                  return response;
                                        }

                                        if (cartRequest.Quantity <= 0)
                                                  cartRequest.Quantity = 1;

                                        var existingItem = _context.cartss
                                            .FirstOrDefault(c =>
                                                c.UserId == cartRequest.UserId &&
                                                c.MedicineId == cartRequest.MedicineId);

                                        if (existingItem != null)
                                        {
                                                  existingItem.Quantity += cartRequest.Quantity;
                                                  existingItem.TotalPrice =
                                                      existingItem.Quantity * existingItem.UnitPrice;

                                                  _context.cartss.Update(existingItem);
                                        }
                                        else
                                        {
                                                  cartRequest.TotalPrice =
                                                      cartRequest.Quantity * cartRequest.UnitPrice;

                                                  _context.cartss.Add(cartRequest);
                                        }

                                        _context.SaveChanges();

                                        response.status = true;
                                        response.responseMessage = "Added to cart successfully";
                              }
                              catch (Exception ex)
                              {
                                        response.status = false;
                                        response.responseMessage = ex.Message;
                              }

                              return response;
                    }

                    //public async Task<List<Cart>> GetAddressesCartByEmailAsync(string email)
                    //{
                    //          //// 1. Email se User ki details (specifically ID) nikalein
                    //          var user = await _context.userMediciness
                    //                 .FirstOrDefaultAsync(u => u.Email == email);

                    //          if (user == null) return new List<Cart>();

                    //          // 2. UserId ka use karke Cart table se data fetch karein
                    //          // Hum yahan Medicine table ko Join kar rahe hain taaki Name aur Image mil sake
                    //          var result = await (from cart in _context.cartss
                    //                              join med in _context.medicinesss on cart.MedicineId equals med.id
                    //                              where cart.UserId == user.id
                    //                              select new Cart
                    //                              {
                    //                                        Id = cart.Id,
                    //                                        //  MedicineName = med.Name,
                    //                                        UnitPrice = cart.UnitPrice,
                    //                                        Quantity = cart.Quantity,
                    //                                        TotalPrice = cart.TotalPrice,
                    //                                        Discount = cart.Discount,
                    //                                        //  ImageUrl = med.ImageUrl
                    //                              }).ToListAsync();

                    //          return result;

          
                    //}
          
                    public int GetCartBadgeCount(int userId)
                    {
                              // GALAT: var count = _context.Cart.Where(u => u.UserId == userId).Sum(s => s.Qty); 

                              // SAHI: Sirf ye check karna ki list mein kitne alag items hain
                              var itemCount = _context.cartss
                                              .Where(c => c.UserId == userId)
                                              .Count(); // Ye unique products ki list count karega

                              return itemCount;
                    }

                    public ResponseModel GetUserCartItems(int loggedInUserId)
                    {
                              try
                              {
                                        // STEP 1: Pehle bina join ke sirf count check karein
                                        var rawCartCount = _context.cartss.Count(c => c.UserId == loggedInUserId);

                                        if (rawCartCount == 0)
                                        {
                                                  return new ResponseModel
                                                  {
                                                            status = false,
                                                            responseMessage = $"No items found in DB for UserID: {loggedInUserId}"
                                                  };
                                        }

                                        // STEP 2: Query ko simple rakhein aur check karein data aa raha hai
                                        var result = (from cart in _context.cartss
                                                      join med in _context.medicinesss on cart.MedicineId equals med.id into joinedMed
                                                      from m in joinedMed.DefaultIfEmpty()
                                                      where cart.UserId == loggedInUserId
                                                      select new
                                                      {
                                                                cartId = cart.Id,
                                                                medicineId = cart.MedicineId,
                                                                medicineName = m != null ? m.Name : "Unknown",
                                                                quantity = cart.Quantity,
                                                                // calculation check karein
                                                                totalPrice = cart.TotalPrice != null ? cart.TotalPrice : (cart.UnitPrice * cart.Quantity)
                                                      }).ToList();

                                        return new ResponseModel { status = true, Data = result, responseMessage = "Success" };
                              }
                              catch (Exception ex)
                              {
                                        return new ResponseModel { status = false, responseMessage = ex.Message };
                              }
                    }

                    public ResponseModel ListUserCartItem()
                    {
                           ResponseModel response = new ResponseModel();

                              var cartlist = _context.cartss.ToList();

                              if (cartlist != null && cartlist.Any())
                              {
                                        response.status = true;
                                        response.responseMessage = "Success";
                                        response.LSTcarts = cartlist;
                              }
                              else
                              {
                                        response.status = false;
                                        response.responseMessage = "No CartList found.";
                              }

                              return response;
                    }

                    // SOLUTION 1: Get Only Logged-In User's Items
                    //public ResponseModel GetUserCartItems(int loggedInUserId)
                    //{
                    //          ResponseModel response = new ResponseModel();
                    //          try
                    //          {
                    //                    // Join lagana zaroori hai taaki Medicine ki details (Name, Image) mil sakein
                    //                    var userItems = (from cart in _context.cartss
                    //                                     join med in _context.medicinesss on cart.MedicineId equals med.id
                    //                                     where cart.UserId == loggedInUserId // YEH SABSE ZAROORI LINE HAI
                    //                                     select new
                    //                                     {
                    //                                               cartId = cart.Id,
                    //                                               medicineName = med.Name,
                    //                                               unitPrice = cart.UnitPrice,
                    //                                               quantity = cart.Quantity,
                    //                                               totalPrice = cart.TotalPrice,
                    //                                               image = med.Image
                    //                                     }).ToList();

                    //                    response.data = userItems;
                    //                    response.status = true;
                    //                    response.responseMessage = "Success";
                    //          }
                    //          catch (Exception ex)
                    //          {
                    //                    response.status = false;
                    //                    response.responseMessage = ex.Message;
                    //          }
                    //          return response;
                    //}
          }
}
