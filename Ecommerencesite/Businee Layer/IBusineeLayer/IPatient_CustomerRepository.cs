using Ecommerencesite.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IPatient_CustomerRepository
          {
                    public void AddPatient_Customer(Patient_CustomerModel patientcustoermmodel);
                    public void  Update(Patient_CustomerModel _patientcustoermmodel);
                    public Patient_CustomerModel DeletePatient(int id);
                    public  List<Patient_CustomerModel> GetAllPatients_Customers();
                    public Patient_CustomerModel SearchCustomerProfile(int id);
                    //public Patient_CustomerModel  DetailsCustomerProfile(int id);

                    public Patient_CustomerModel DetailsCustomerProfile(int userId);
                    


          }
}
