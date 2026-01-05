using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public class AdminRepository : IAdminRepository
          {
                    private readonly Ecommerecewebstedatabase context;
                    public AdminRepository(Ecommerecewebstedatabase _context)
                    {
                              this.context = _context;
                    }

                    public ResponseModel CREATERegistoryAdmin(AdminREGMODEL adminREGMODEL)
                    {
                              var res = new ResponseModel();

                              try
                              {
                                        if (adminREGMODEL.CreateOn == null)
                                                  adminREGMODEL.CreateOn = DateTime.Now;

                                        context.adminREGMODELSs.Add(adminREGMODEL);
                                        context.SaveChanges();

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

                              var adminlogindto = context.adminREGMODELSs
                                  .FirstOrDefault(u => u.Email == _adminlogindto.Email
                                                    && u.Password == _adminlogindto.Password);
                              //var user = _context.userMedicines
                              //    .FirstOrDefault(_userlogindto.Email == _userlogindto.Password);


                              if (adminlogindto != null)
                              {
                                        return new ResponseModel
                                        {
                                                  status = true,
                                                  responseMessage = "Admin Login Successful",
                                                  adminREGMODEL = adminlogindto     // return actual adminlogin data
                                        };
                              }
                              else
                              {
                                        return new ResponseModel
                                        {
                                                  status = false,
                                                  responseMessage = "Invalid Email or Password",
                                                  adminREGMODEL = null
                                        };
                              }
                    }
          }
}

