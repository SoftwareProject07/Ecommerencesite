


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


                    // 1. correct login logic

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

                    // 2. Login Logic trail based on fetching additional details from Patient_CustomerModel
                    //public ResponseModel LOGINUserMedicine(UserLogindto _userlogindto)
                    //{
                    //          var response = new ResponseModel();

                    //          // 1. Pehle UserMedicine table mein check karein login credentials
                    //          var user = _context.userMediciness
                    //              .FirstOrDefault(u =>
                    //                  (u.Email == _userlogindto.Email && u.Password == _userlogindto.Password)
                    //                  ||
                    //                  (u.MobileNumber == _userlogindto.MobileNumber && u.Password == _userlogindto.Password)
                    //              );

                    //          if (user != null)
                    //          {
                    //                    // 2. Agar login successful hai, toh Patient_CustomerModel se details layein
                    //                    // Hum Email ya Phone match kar sakte hain kyunki ID dono tables mein alag ho sakti hai
                    //                    //var customerDetails = _context.patient_CustomerModels
                    //                    //    .FirstOrDefault(p => p.Email == user.Email || p.PhoneNumber == user.MobileNumber);
                    //                    var customerDetails =  _context.patient_CustomerModels.Where(s=>s.Patient_CustomerId==user.id).FirstOrDefault();
                    //                    return new ResponseModel
                    //                    {
                    //                              status = true,
                    //                              responseMessage = "Customer Login Successful",
                    //                              userMedicine = user, // Aapka login user data
                    //                              Patient_CustomerProfiless = customerDetails // Ye naya field ResponseModel mein add karna hoga
                    //                    };
                    //          }
                    //          else
                    //          {
                    //                    return new ResponseModel
                    //                    {
                    //                              status = false,
                    //                              responseMessage = "Invalid Email/MobileNumber or Password",
                    //                              userMedicine = null
                    //                    };
                    //          }
                    //}
                    //3.
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
                                        // 2. Sirf usi User ki ID se match hone wale addresses fetch karein
                                        // Isse Shivam (ID: 5) ko Gautam (ID: 10) ka data kabhi nahi dikhega
                                        var userAddresses = _context.patient_CustomerModels
                                                                    .Where(p => p.UsersId == user.id)
                                                                    .ToList();

                                        return new ResponseModel
                                        {
                                                  status = true,
                                                  responseMessage = "Login Successful",
                                                  userMedicine = user,
                                                  lstcustomeraddress = userAddresses // Agar address nahi hai toh ye empty list [] jayegi
                                        };
                              }
                              else
                              {
                                        return new ResponseModel
                                        {
                                                  status = false,
                                                  responseMessage = "Invalid Email/MobileNumber or Password",
                                                  userMedicine = null,
                                                  lstcustomeraddress = null
                                        };
                              }


                              //                          var user = _usermedicinerepository.USER
                              //                           .FirstOrDefault(x =>
                              //                               (x.Email == model.Email || x.PhoneNumber == model.Email)
                              //                               && x.Password == model.Password);

                              //                          if (user == null)
                              //                                    return Unauthorized(new { status = false, message = "Invalid credentials" });

                              //                          // 🔐 JWT Generate
                              //                          var claims = new[]
                              //                          {
                              //    new Claim("UserId", user.Id.ToString()),
                              //    new Claim(ClaimTypes.Email, user.Email)
                              //};

                              //                          var key = new SymmetricSecurityKey(
                              //                              Encoding.UTF8.GetBytes(_config["Jwt:Key"])
                              //                          );

                              //                          var token = new JwtSecurityToken(
                              //                              issuer: _config["Jwt:Issuer"],
                              //                              audience: _config["Jwt:Audience"],
                              //                              claims: claims,
                              //                              expires: DateTime.Now.AddDays(1),
                              //                              signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                              //                          );

                              //                          return Ok(new
                              //                          {
                              //                                    status = true,
                              //                                    token = new JwtSecurityTokenHandler().WriteToken(token)
                              //                          });
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
