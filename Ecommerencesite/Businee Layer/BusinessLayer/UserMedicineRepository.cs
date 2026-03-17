


using CRUDAPPLICATION.ModelDTO;
using Ecommerencesite.Businee_Layer.BusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using System.Text;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class UserMedicineRepository : IUserMedicineRepository
          {
                    private readonly Ecommerecewebstedatabase _context;

                    public UserMedicineRepository(Ecommerecewebstedatabase context)//, IConfiguration configuration
                    {
                              _context = context;
                              //    _configuration = configuration;
                    }

                    public ResponseModel CREATERegisterUser(UserMedicine userregistMedicine)
                    {
                              var res = new ResponseModel();

                              try
                              {
                                        if (userregistMedicine.CreatedOn == null)
                                                  userregistMedicine.CreatedOn = DateTime.Now;
                                        // 🔒 Hash the password before saving
                                        //userregistMedicine.PasswordHash = HashPassword(userregistMedicine.Password ?? string.Empty);
                                        //userregistMedicine.Password = null; // clear plain password

                                        _context.userMediciness.Add(userregistMedicine);
                                        _context.SaveChanges();

                                        res.status = true;
                                        res.responseMessage = "User registered successfully";
                                        res.Data = userregistMedicine;
                              }
                              catch (Exception ex)
                              {
                                        res.status = false;
                                        res.responseMessage = ex.Message;
                              }

                              return res;
                    }


                    public ResponseModel LOGINUserMedicine(UserLogindto _userlogindto)
                    {
                              // 1. User check karein Email/Mobile aur Password se
                              var user = _context.userMediciness
                                  .FirstOrDefault(u =>
                                      (u.Email == _userlogindto.Email && u.Password == _userlogindto.Password)
                                      ||
                                      (u.MobileNumber == _userlogindto.MobileNumber && u.Password == _userlogindto.Password)
                                  );

                              if (user != null)
                              {
                                     

                                        return new ResponseModel
                                        {
                                                  status = true,
                                                  responseMessage = "Login Successful",
                                                  userMedicine = user,
                                                 // lstcustomeraddress = userAddresses // Agar address nahi hai toh ye empty list [] jayegi
                                        };
                              }
                              else
                              {
                                        return new ResponseModel
                                        {
                                                  status = false,
                                                  responseMessage = "Invalid Email/MobileNumber or Password",
                                                  userMedicine = null,
                                                //  lstcustomeraddress = null
                                        };
                              }


                            
                    }
           




                    public ResponseModel DELETEUserMedicine(UserMedicine userdeleteMedicine)
                    {
                              var user = _context.userMediciness.Find(userdeleteMedicine.id);
                              if (user != null)
                              {
                                        _context.userMediciness.Remove(user);
                                        _context.SaveChanges();
                                        return new ResponseModel
                                        {
                                                  status = true,
                                                  responseMessage = "User Deleted Successfully",
                                                  userMedicine = userdeleteMedicine
                                        };
                              }
                              else
                              {
                                        return new ResponseModel
                                        {
                                                  status = false,
                                                  responseMessage = "User Not Found",
                                                  userMedicine = null
                                        };
                              }
                    }





                    public ResponseModel OrderList()
                    {
                              var orders = _context.userMediciness.ToList();
                              return new ResponseModel
                              {
                                        status = true,
                                        responseMessage = "Order List Retrieved Successfully",
                                        LSTuserMedicines = orders
                              };
                           //   return null;

                    }

                    public ResponseModel PlaceOrder(UserMedicine userOrder)
                    {
                              var order = _context.userMediciness.Add(userOrder);
                              _context.SaveChanges();
                              return new ResponseModel
                              {
                                        status = true,
                                        responseMessage = "Order Placed Successfully",
                                        userMedicine = userOrder
                              };
                             // return null;
                    }



                    public ResponseModel UpdateUserMedicine(UserMedicine userUpdateMedicine)
                    {
                              var response = _context.userMediciness.Update(userUpdateMedicine);
                              _context.SaveChanges();
                              return new ResponseModel
                              {
                                        status = true,
                                        responseMessage = "User Updated Successfully",
                                        userMedicine = userUpdateMedicine
                              };
                              //return null;
                    }

                    // Admin side customer list show --correct 
                    public List<UserMedicine> CUSTOMERUserList()
                    {
                              var users = _context.userMediciness.ToList();

                              return users;
                    }



                    //public async Task<bool> ResetPasswordAsync(ForgetPasswordUserDto dto)
                    //{
                    //          var user = await _context.userMediciness
                    //              .FirstOrDefaultAsync(x => (x.Email.ToLower() == dto.Email.ToLower() ||x.MobileNumber==dto.PhoneNumber ||x.FirstName==dto.UserName));

                    //          if (user == null)
                    //                    return false;

                    //          user.Password = dto.NewPassword;

                    //          await _context.SaveChangesAsync();

                    //          return true;
                    //}

                    public async Task<bool> ResetPasswordAsync(ForgetPasswordUserDto dto)
                    {
                              // Check karein ki user exist karta hai ya nahi (Null checks ke saath)
                              var user = await _context.userMediciness
                                  .FirstOrDefaultAsync(x =>
                                      (!string.IsNullOrEmpty(dto.Email) && x.Email.ToLower() == dto.Email.ToLower()) ||
                                      (!string.IsNullOrEmpty(dto.PhoneNumber) && x.MobileNumber == dto.PhoneNumber) ||
                                      (!string.IsNullOrEmpty(dto.UserName) && x.FirstName == dto.UserName));

                              if (user == null)
                                        return false;

                              // Password update karein
                              user.Password = dto.NewPassword;

                              // Database mein save karein
                              _context.userMediciness.Update(user);
                              await _context.SaveChangesAsync();

                              return true;
                    }
                    public UserMedicine Customerprofile(int userId)
                    {
                              var customerprofiles = _context.userMediciness.Where(s => s.id == userId).FirstOrDefault();
                              return customerprofiles;
                    }

                   

                    //public ResponseModel CUSTOMERUserList()
                    //{
                    //         var respon = new ResponseModel();
                    //          try
                    //          {
                    //                    var users = _context.userMediciness.ToList();
                    //                    respon.status = true;
                    //                    respon.responseMessage = "Customer List Retrieved Successfully";
                    //                    respon.LSTuserMedicines = users;
                    //          }
                    //          catch (Exception ex)
                    //          {
                    //                    respon.status = false;
                    //                    respon.responseMessage = ex.Message;
                    //                    respon.LSTuserMedicines = null;
                    //          }
                    //          return respon;
                    //}
          }
}
