using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class Patient_CustomerRepository : IPatient_CustomerRepository
          {
                    private readonly Ecommerecewebstedatabase _dbcontext;
                    public Patient_CustomerRepository(Ecommerecewebstedatabase dbcontext)
                    {
                              this._dbcontext = dbcontext;

                    }
                    public void  AddPatient_Customer(Patient_CustomerModel patientcustoermmodel)
                    {
                           _dbcontext.patient_CustomerModels.Add(patientcustoermmodel);
                           //   return Ok(a);
                                _dbcontext.SaveChanges();
                    }

                    public Patient_CustomerModel DeletePatient(int id)
                    {
                           var delete= _dbcontext.patient_CustomerModels.Find(id);     
                            
                                        _dbcontext.patient_CustomerModels.Remove(delete);
                                        _dbcontext.SaveChanges();
                              return delete;
                    }

                    public async Task<List<Patient_CustomerModel>> GetAddressesByEmailAsync(string email)
                    {
                              return await _dbcontext.patient_CustomerModels
                                 .Where(x => x.Email.ToLower() == email.ToLower())
                                 .ToListAsync();
                    }

                    // Return type ko List banayein taaki saare addresses mil sakein
                    //public List<Patient_CustomerModel> DeliveryAddress(int userid)
                    //{
                    //          // .Where() filter karega ki sirf usi user ka data mile
                    //          // .ToList() saare matching addresses ko ek saath nikaal lega
                    //          var deliveryaddresses = _dbcontext.patient_CustomerModels
                    //                                           .Where(s => s.Patient_CustomerId == userid)
                    //                                           .ToList();

                    //          return deliveryaddresses;
                    //}



                    public List<Patient_CustomerModel> GetAllPatients_Customers()
                    {
                            var listpatient=  _dbcontext.patient_CustomerModels.ToList();
                              return listpatient;
                    }

                  

                    public Patient_CustomerModel SearchCustomerProfile(int id)
                    {
                              var customerprofile = _dbcontext.patient_CustomerModels.Where(s => s.Patient_CustomerId == id).FirstOrDefault();
                              return customerprofile;
                    }

                    public void Update(Patient_CustomerModel _patientcustoermmodel)
                    {
                              _dbcontext.patient_CustomerModels.Update(_patientcustoermmodel);
                              _dbcontext.SaveChanges();
                    }


                   
          }
}
