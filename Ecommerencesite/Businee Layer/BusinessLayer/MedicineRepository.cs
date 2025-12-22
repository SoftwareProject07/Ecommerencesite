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

                    //public ResponseModel CreateMedicine(Medicine createMedicine)
                    //{
                    //          //var createmedicines = new ResponseModel();
                    //          //res.medicine.id= createMedicine.id,
                    //          //res.m
                    //          //try
                    //          //{
                    //          dbcontext.medicinesss.Add(createMedicine);
                    //          dbcontext.SaveChanges();
                    //          return new ResponseModel
                    //          {


                    //                    status = true,
                    //                    responseMessage = "Medicine Create successfully",
                    //                    medicine = createMedicine
                    //          };
                    //}
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

                    public ResponseModel lstmedicine()
                    {
                                   var lstmedicine = dbcontext.medicinesss.ToList();

                              return new ResponseModel
                              {
                                        status = true,
                                        responseMessage = "Order List Retrieved Successfully",
                                        LSTmedicines = lstmedicine
                              };

                              return null;
                                        //  return lstm
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

                    public ResponseModel UpdateMedicine(Medicine updatemedicine)
                    {
                              //var updatemedicines= new ResponseModel();
                              // try
                              // {
                              dbcontext.medicinesss.Update(updatemedicine);
                              dbcontext.SaveChanges();

                              return new ResponseModel
                              {

                                        status = true,
                                        responseMessage = "Medicine Update successfully",
                                        medicine = updatemedicine



                              };
                              //catch (Exception ex)
                              //{
                              //          updatemedicines.status = false;
                              //          updatemedicines.responseMessage = ex.Message;
                              //}
                              return null;
                    }
          }
}
