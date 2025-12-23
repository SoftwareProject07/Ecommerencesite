using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class MedicineRepository : IMedicineRepositort
          {
                    private readonly Ecommerecewebstedatabase dbcontext;
                    public MedicineRepository(Ecommerecewebstedatabase _dbcontext)
                    {
                              this.dbcontext = _dbcontext;
                    }

             
                    public ResponseModel CreateMedicine(Medicine createMedicine)
                    {
                              if (createMedicine.ExpiryDate.HasValue)
                              {
                                        createMedicine.ExpiryDate =
                                            DateTime.SpecifyKind(createMedicine.ExpiryDate.Value, DateTimeKind.Utc);
                              }

                              createMedicine.STATUS = 1;

                              dbcontext.medicinesss.Add(createMedicine);
                              dbcontext.SaveChanges();

                              return new ResponseModel
                              {
                                        status = true,
                                        responseMessage = "Medicine Create successfully",
                                        medicine = createMedicine
                              };
                    }




                    //return createmedicines;





                    public ResponseModel DeleteMedicine(int id)
                    {
                              //var delemedicine = new ResponseModel();
                              //try
                              //{
                                        var delemedicines = dbcontext.medicinesss.Where(s => s.id == id).FirstOrDefault();
                              dbcontext.medicinesss.Remove(delemedicines);
                              dbcontext.SaveChanges();

                              return new ResponseModel
                              {
                                        status = true,
                                        responseMessage = "Medicine Delete successfully",
                                        medicine = delemedicines
                              };
                              return null;
                              }
                                      
                          
                    

                    public ResponseModel DetailsMedicine(int id)
                    {
                             var details= new ResponseModel();
                              try
                              {
                                        var detail = dbcontext.medicinesss.Where(m => m.id == id).FirstOrDefault();
                                        details.status = true;
                                        details.responseMessage = "Medicine Details successfully";
                                        details.Data = detail;

                              }
                              catch (Exception ex)
                              {
                                        details.status = false;
                                        details.responseMessage = ex.Message;
                              }
                                                                      return details;

                    }

                    public List<Medicine> lstmedicine()
                    {
                              try
                              {
                                        return dbcontext.medicinesss
                                                       .Where(x => x.STATUS == 1).OrderBy(x=>x.id)
                                                       .ToList();
                                      
                              }
                              catch
                              {
                                        return new List<Medicine>(); // ❗ NEVER throw 500
                              }
                    }
                   

                    public ResponseModel SearchMedicine(int id)
                    {
                              var SearchMedicine = new ResponseModel();
                              try
                              {
                                        var SearchMedicineS = dbcontext.medicinesss.Where(m => m.id == id).FirstOrDefault();
                                        SearchMedicine.status = true;
                                        SearchMedicine.responseMessage = "Medicine Search successfully";
                                        SearchMedicine.Data = SearchMedicineS;

                              }
                              catch (Exception ex)
                              {
                                        SearchMedicine.status = false;
                                        SearchMedicine.responseMessage = ex.Message;
                              }
                              return SearchMedicine;
                    }

                    //public void UpdateMedicine(Medicine updatemedicine)
                    //{
                    //        dbcontext.medicinesss.Update(updatemedicine);
                    //          dbcontext.SaveChanges();
                    //}

                    //public ResponseModel UpdateMedicine(Medicine updatemedicine)
                    //{
                    //          //var updatemedicines= new ResponseModel();
                    //          // try
                    //          // {

                    //          if (updatemedicine.ExpiryDate.HasValue)
                    //          {
                    //                    updatemedicine.ExpiryDate =
                    //                        DateTime.SpecifyKind(updatemedicine.ExpiryDate.Value, DateTimeKind.Utc);
                    //          }

                    //          updatemedicine.STATUS = 1;
                    //          dbcontext.medicinesss.Update(updatemedicine);
                    //          dbcontext.SaveChanges();

                    //          return new ResponseModel
                    //          {

                    //                    status = true,
                    //                    responseMessage = "Medicine Update successfully",
                    //                    medicine = updatemedicine



                    //          };

                    public ResponseModel UpdateMedicine(Medicine updatemedicine)
                    {
                              var existingMedicine = dbcontext.medicinesss
                                                              .FirstOrDefault(x => x.id == updatemedicine.id);

                              if (existingMedicine == null)
                              {
                                        return new ResponseModel
                                        {
                                                  status = false,
                                                  responseMessage = "Medicine not found"
                                        };
                              }

                              // 🔹 Fields update karo (Id ko kabhi mat chhedna)
                              existingMedicine.Name = updatemedicine.Name;
                              existingMedicine.Manufacturer = updatemedicine.Manufacturer;
                              existingMedicine.UnitPrice = updatemedicine.UnitPrice;
                              existingMedicine.Discount = updatemedicine.Discount;
                              existingMedicine.Quantity = updatemedicine.Quantity;
                              existingMedicine.ExpiryDate = updatemedicine.ExpiryDate;

                              if (updatemedicine.ExpiryDate.HasValue)
                              {
                                        existingMedicine.ExpiryDate =
                                            DateTime.SpecifyKind(updatemedicine.ExpiryDate.Value, DateTimeKind.Utc);
                              }

                              existingMedicine.STATUS = 1;

                              dbcontext.SaveChanges();

                              return new ResponseModel
                              {
                                        status = true,
                                        responseMessage = "Medicine updated successfully",
                                        medicine = existingMedicine
                              };
                    }


                                 //return null;
                    }
}

