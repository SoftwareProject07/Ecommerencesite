using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class Patient_CustomerRepository : IPatient_CustomerRepository
          {
                    private readonly Ecommerecewebstedatabase _dbcontext;
                    public Patient_CustomerRepository(Ecommerecewebstedatabase dbcontext)
                    {
                              this._dbcontext = dbcontext;
                    }
                    public void AddPatient_Customer(Patient_CustomerModel patientcustoermmodel)
                    {
                             _dbcontext.patient_CustomerModels.Add(patientcustoermmodel);
                                _dbcontext.SaveChanges();
                    }

                    public Patient_CustomerModel DeletePatient(int id)
                    {
                           var delete= _dbcontext.patient_CustomerModels.Find(id);     
                            
                                        _dbcontext.patient_CustomerModels.Remove(delete);
                                        _dbcontext.SaveChanges();
                              return delete;
                    }

                    public Patient_CustomerModel DeltePatient(int id)
                    {
                              var delete= _dbcontext.patient_CustomerModels.Find(id);     
                            
                                        _dbcontext.patient_CustomerModels.Remove(delete);
                                        _dbcontext.SaveChanges();
                              return delete;
                    }

                    public List<Patient_CustomerModel> GetAllPatients_Customers()
                    {
                            var listpatient=  _dbcontext.patient_CustomerModels.ToList();
                              return listpatient;
                    }

                    public void Update(Patient_CustomerModel _patientcustoermmodel)
                    {
                              _dbcontext.patient_CustomerModels.Update(_patientcustoermmodel);
                              _dbcontext.SaveChanges();
                    }

                   
          }
}
