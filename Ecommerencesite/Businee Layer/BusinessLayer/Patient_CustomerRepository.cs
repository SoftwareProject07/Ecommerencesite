using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Http.HttpResults;

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

                    // Profile customer 
                    public Patient_CustomerModel DetailsCustomerProfile(int userId)
                    {
                              return _dbcontext.patient_CustomerModels
                                               .FirstOrDefault(x => x.UsersId == userId);
                    }

                    //public Patient_CustomerModel DetailsCustomerProfile(int id)
                    //{
                    //          var customer = _dbcontext.patient_CustomerModels
                    //                         .FirstOrDefault(x => x.UserId == id);

                    //          return customer;
                    //}


                    //public Patient_CustomerModel DetailsCustomerProfile(int int userId)
                    //{
                    //          var customer = _dbcontext.patient_CustomerModels
                    //                         .FirstOrDefault(x => x.UserId == loginUserId);

                    //          return customer;
                    //}


                    public List<Patient_CustomerModel> GetAllPatients_Customers()
                    {
                            var listpatient=  _dbcontext.patient_CustomerModels.ToList();
                              return listpatient;
                    }

                    //public Patient_CustomerModel SearchCustomerProfile(int id)
                    //{
                    //          throw new NotImplementedException();
                    //}

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
