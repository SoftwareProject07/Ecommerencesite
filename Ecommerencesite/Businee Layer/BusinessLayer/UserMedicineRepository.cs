


using Ecommerencesite.Businee_Layer.BusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class UserMedicineRepository : IUserMedicineRepository
          {
                    private readonly Ecommerecewebstedatabase _context;

                    public UserMedicineRepository(Ecommerecewebstedatabase context)
                    {
                              _context = context;
                    }

                    public ResponseModel CREATERegisterUser(UserMedicine userregistMedicine)
                    {
                              var res = new ResponseModel();

                              try
                              {
                                        if (userregistMedicine.CreateOn == null)
                                                  userregistMedicine.CreateOn = DateTime.Now;

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
                              var user = _context.userMediciness
                                  .FirstOrDefault(u => u.Email == _userlogindto.Email
                                                    && u.Password == _userlogindto.Password);
                              //var user = _context.userMedicines
                              //    .FirstOrDefault(_userlogindto.Email == _userlogindto.Password);


                              if (user != null)
                              {
                                        return new ResponseModel
                                        {
                                                  status = true,
                                                  responseMessage = "Customer Login Successful",
                                                  userMedicine = user     // return actual user data
                                        };
                              }
                              else
                              {
                                        return new ResponseModel
                                        {
                                                  status = false,
                                                  responseMessage = "Invalid Email or Password",
                                                  userMedicine = null
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
                              return null;

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
                              return null;
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
                              return null;
                    }


                    public ResponseModel UserList()
                    {
                              var users = _context.userMediciness.ToList();
                              return new ResponseModel
                              {
                                        status = true,
                                        responseMessage = "User List Retrieved Successfully",
                                        LSTuserMedicines = users
                              };
                              return null;
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



          }
}