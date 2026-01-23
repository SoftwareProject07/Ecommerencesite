


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
                    private readonly IConfiguration _configuration;

                    public UserMedicineRepository(Ecommerecewebstedatabase context, IConfiguration configuration)//, IConfiguration configuration
                    {
                              _context = context;
                              _configuration = configuration;
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


                    //public ResponseModel LOGINUserMedicine(UserLogindto _userlogindto)
                    //{
                    //          // Find user by email+password OR mobile+password
                    //          var user = _context.userMediciness
                    //              .FirstOrDefault(u =>
                    //                  (u.Email == _userlogindto.Email && u.Password == _userlogindto.Password)
                    //                  ||
                    //                  (u.MobileNumber == _userlogindto.MobileNumber && u.Password == _userlogindto.Password)
                    //              );

                    //          if (user != null)
                    //          {
                    //                    // ✅ user found
                    //                    return new ResponseModel
                    //                    {
                    //                              status = true,
                    //                              responseMessage = "Customer Login Successful",
                    //                              userMedicine = user
                    //                    };
                    //          }
                    //          else
                    //          {
                    //                    // ❌ user not found
                    //                    string message = "Invalid Email/MobileNumber or Password";

                    //                    if (!string.IsNullOrEmpty(_userlogindto.MobileNumber))
                    //                              message = "Invalid Email/MobileNumber or Password";

                    //                    return new ResponseModel
                    //                    {
                    //                              status = false,
                    //                              responseMessage = message,
                    //                              userMedicine = null
                    //                    };
                    //          }
                    //}

                    //public ResponseModel LOGINUserMedicine(UserLogindto _userlogindto)
                    //{
                    //          var response = new ResponseModel();

                    //          var user = _context.userMediciness
                    //              .FirstOrDefault(u =>
                    //                  (u.Email == _userlogindto.Email && u.Password == _userlogindto.Password)
                    //                  ||
                    //                  (u.MobileNumber == _userlogindto.MobileNumber && u.Password == _userlogindto.Password)
                    //              );

                    //          if (user != null)
                    //          {
                    //                    // ✅ user found
                    //                    return new ResponseModel
                    //                    {
                    //                              status = true,
                    //                              responseMessage = "Customer Login Successful",
                    //                              userMedicine = user
                    //                    };
                    //          }
                    //          else
                    //          {
                    //                    // ❌ user not found
                    //                    string message = "Invalid Email/MobileNumber or Password";

                    //                    if (!string.IsNullOrEmpty(_userlogindto.MobileNumber))
                    //                              message = "Invalid Email/MobileNumber or Password";

                    //                    return new ResponseModel
                    //                    {
                    //                              status = false,
                    //                              responseMessage = message,
                    //                              userMedicine = null
                    //                    };
                    //          }
                    //}

                    // 2. Login Logic
                    public ResponseModel LOGINUserMedicine(UserLogindto _userlogindto)
                    {
                              // 1. Authenticate user from login table
                              var userAccount = _context.userMediciness
                                  .FirstOrDefault(u =>
                                      (u.Email == _userlogindto.Email && u.Password == _userlogindto.Password)
                                      ||
                                      (u.MobileNumber == _userlogindto.MobileNumber && u.Password == _userlogindto.Password)
                                  );

                              if (userAccount != null)
                              {
                                        // 2. ✅ User mil gaya. Patient table se details fetch karein.
                                        // Yahan 'userAccount.Patient_CustomerId' use karein (jo bhi aapki table mein column name hai)
                                        var customerDetails = _context.patient_CustomerModels
                                            .FirstOrDefault(s => s.Patient_CustomerId == userAccount.id);

                                        return new ResponseModel
                                        {
                                                  status = true,
                                                  responseMessage = "Login Successful",
                                                  Patient_CustomerProfiless = customerDetails
                                        };
                              }
                              else
                              {
                                        // 3. ❌ Login Failed
                                        return new ResponseModel
                                        {
                                                  status = false,
                                                  responseMessage = "Invalid Credentials",
                                                  Patient_CustomerProfiless = null
                                        };
                              }
                    }
                    // 🔐 JWT TOKEN
                    //                      var claims = new[]
                    //                                {
                    //    new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                    //    new Claim(ClaimTypes.Role, user.type ?? "User")
                    //};

                    //                      var key = new SymmetricSecurityKey(
                    //                          Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
                    //                      );

                    //                      var creds = new SigningCredentials(
                    //                          key, SecurityAlgorithms.HmacSha256
                    //                      );

                    //                      var token = new JwtSecurityToken(
                    //                          issuer: _configuration["Jwt:Issuer"],
                    //                          audience: _configuration["Jwt:Audience"],
                    //                          claims: claims,
                    //                          expires: DateTime.UtcNow.AddDays(1),
                    //                          signingCredentials: creds
                    //                      );

                    //                      response.status = true;
                    //                      response.responseMessage = "Login Successful";
                    //                      response.Data = new
                    //                      {
                    //                                token = new JwtSecurityTokenHandler().WriteToken(token),
                    //                                userId = user.id,
                    //                                role = user.type,
                    //                                email = user.Email,
                    //                                mobile=user.MobileNumber

                    //                      };

                    //                      return response;
                    //            }





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


                    public List<UserMedicine> CUSTOMERUserList()
                    {
                              var users = _context.userMediciness.ToList();
                              
                              return users;
                    }

                    public ResponseModel ViewUser(int id)//UserMedicine userViewMedicine
                    {
                              var user = _context.userMediciness.Where(s => s.id == id).FirstOrDefault();
                              if (user != null)
                              {
                                        return new ResponseModel
                                        {
                                                  status = true,
                                                  responseMessage = "User Retrieved Successfully",
                                                  userMedicine = user
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

                  
                    public async Task<bool> ResetPasswordAsync(ForgetPasswordUserDto dto)
                    {
                              var user = await _context.userMediciness
                                  .FirstOrDefaultAsync(x => (x.Email.ToLower() == dto.Email.ToLower() ||x.MobileNumber==dto.PhoneNumber ||x.FirstName==dto.UserName));

                              if (user == null)
                                        return false;

                              user.Password = dto.NewPassword;

                              await _context.SaveChangesAsync();

                              return true;
                    }

          }
}
