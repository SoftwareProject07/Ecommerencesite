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
                    public async Task AddToCart(int userId, int medicineId, int quantity)
                    {
                              var medicine = await _context.medicinesss
                                          .FirstOrDefaultAsync(m => m.id == medicineId);

                              if (medicine == null)
                                        throw new Exception("Medicine not found");

                              // 2️⃣ Check if already in cart
                              var existingCart = await _context.cartss
                                  .FirstOrDefaultAsync(c =>
                                      c.UserId == userId &&
                                      c.MedicineId == medicineId);

                              if (existingCart != null)
                              {
                                        // 🔁 Update quantity
                                        existingCart.Quantity += quantity;
                                        existingCart.TotalPrice =
                                            (existingCart.UnitPrice - (existingCart.Discount ?? 0))
                                            * existingCart.Quantity;
                              }
                              else
                              {
                                        // ➕ New cart item
                                        var cart = new Cart
                                        {
                                                  UserId = userId,
                                                  MedicineId = medicineId,
                                                  Quantity = quantity,
                                                  UnitPrice = medicine.UnitPrice,
                                                  Discount = 0,
                                                  TotalPrice = medicine.UnitPrice * quantity
                                        };

                                        await _context.cartss.AddAsync(cart);
                              }

                              await _context.SaveChangesAsync();
                    }

                    //public async Task AddToCart(int userId, int medicineId, int quantity)
                    //{
                    //          var medicine = await _context.medicinesss.FindAsync(medicineId);
                    //          if (medicine == null) throw new Exception("Medicine not found");

                    //          var cartItem = new Cart
                    //          {
                    //                    UserId = userId,
                    //                    MedicineId = medicineId,
                    //                    Quantity = quantity,
                    //                    UnitPrice = medicine.UnitPrice,
                    //                    Discount = medicine.Discount,
                    //                    TotalPrice = (medicine.UnitPrice - medicine.Discount) * quantity
                    //          };

                    //          _context.cartss.Add(cartItem);
                    //          await _context.SaveChangesAsync();
                    //}

                    public async Task<List<Cart>> GetMyCart(int userId)
                    {
                              return await _context.cartss
                                  .Where(c => c.UserId == userId)
                                  .ToListAsync();
                    }


          }
}
