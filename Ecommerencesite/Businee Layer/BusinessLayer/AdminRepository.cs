using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public class AdminRepository : IAdminRepository
          {
                    private readonly Ecommerecewebstedatabase _context;
                    public AdminRepository(Ecommerecewebstedatabase context)
                    {
                              this._context = context;
                    }

                    public ResponseModel CREATERegistoryAdmin(AdminREGMODEL adminREGMODEL)
                    {
                              var res = new ResponseModel();

                              try
                              {
                                        if (adminREGMODEL.CreateOn == null)
                                                  adminREGMODEL.CreateOn = DateTime.Now;

                                        _context.adminREGMODELSs.Add(adminREGMODEL);
                                        _context.SaveChanges();

                                        res.status = true;
                                        res.responseMessage = "User registered successfully";
                                        res.Data = adminREGMODEL;
                              }
                              catch (Exception ex)
                              {
                                        res.status = false;
                                        res.responseMessage = ex.Message;
                              }

                              return res;
                    }

                    public ResponseModel LOGINAdmin(AdminLogindto _adminlogindto)
                    {

                              var user = _context.userMediciness
                                  .FirstOrDefault(u => u.Email == _adminlogindto.Email
                                                    && u.Password == _adminlogindto.Password);
                              //var user = _context.userMedicines
                              //    .FirstOrDefault(_userlogindto.Email == _userlogindto.Password);


                              if (user != null)
                              {
                                        return new ResponseModel
                                        {
                                                  status = true,
                                                  responseMessage = "Login Successful",
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
          }
}

