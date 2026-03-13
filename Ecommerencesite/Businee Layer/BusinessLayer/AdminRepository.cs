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
                                        if (adminREGMODEL.CreatedOn == null)
                                                  adminREGMODEL.CreatedOn = DateTime.Now;

                                        context.adminREGMODELSs.Add(adminREGMODEL);
                                        context.SaveChanges();

                                        res.status = true;
                                        res.responseMessage = "CompanyAdmin registered successfully";
                                        res.Data = adminREGMODEL;
                              }
                              catch (Exception ex)
                              {
                                        res.status = false;
                                        res.responseMessage = ex.Message;
                              }

                              return res;
                    }

                    public ResponseModel DeleteAdmin(int id)
                    {
                              var res = new ResponseModel();
                              try
                              {
                                        var admin = context.adminREGMODELSs.Find(id);
                                        if (admin == null)
                                        {
                                                  res.status = false;
                                                  res.responseMessage = "Admin not found";
                                                  return res;
                                        }
                                        context.adminREGMODELSs.Remove(admin);
                                        context.SaveChanges();
                                        res.status = true;
                                        res.responseMessage = "Admin deleted successfully";
                              }
                              catch (Exception ex)
                              {
                                        res.status = false;
                                        res.responseMessage = ex.Message;
                              }
                              return res;

                    }

                    public ResponseModel GETALLRegistoryAdmin()
                    {
                              var res = new ResponseModel();
                              try
                              {
                                        var admins = context.adminREGMODELSs.ToList();
                                        res.status = true;
                                        res.responseMessage = "Admins retrieved successfully";
                                        res.Data = admins;
                              }
                              catch (Exception ex)
                              {
                                        res.status = false;
                                        res.responseMessage = ex.Message;
                              }
                              return res;

                    }

                    public ResponseModel GETRegistoryAdmin(int id)
                    {
                              var a = context.adminREGMODELSs.Find(id);
                              var res = new ResponseModel();
                              if (a != null)
                              {
                                        res.status = true;
                                        res.responseMessage = "Admin retrieved successfully";
                                        res.Data = a;
                              }
                              else
                              {
                                        res.status = false;
                                        res.responseMessage = "Admin not found";
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

                    public ResponseModel UPDATERegistoryAdmin(AdminREGMODEL adminREGMODEL)
                    {

                              var res = new ResponseModel();
                              try
                              {
                                        var existingAdmin = context.adminREGMODELSs.Find(adminREGMODEL.ADMINid);
                                        if (existingAdmin == null)
                                        {
                                                  res.status = false;
                                                  res.responseMessage = "Admin not found";
                                                  return res;
                                        }
                                        // Update properties
                                        existingAdmin.FirstName = adminREGMODEL.FirstName;
                                        existingAdmin.MiddleName = adminREGMODEL.MiddleName;
                                        existingAdmin.LastName = adminREGMODEL.LastName;
                                        existingAdmin.Password = adminREGMODEL.Password;
                                        existingAdmin.Email = adminREGMODEL.Email;
                                        existingAdmin.MobileNumber = adminREGMODEL.MobileNumber;
                                        existingAdmin.Fund = adminREGMODEL.Fund;
                                        existingAdmin.type = adminREGMODEL.type;
                                        context.SaveChanges();
                                        res.status = true;
                                        res.responseMessage = "Admin updated successfully";
                                        res.Data = existingAdmin;
                              }
                              catch (Exception ex)
                              {
                                        res.status = false;
                                        res.responseMessage = ex.Message;
                              }
                              return res;
                    }

          }
}