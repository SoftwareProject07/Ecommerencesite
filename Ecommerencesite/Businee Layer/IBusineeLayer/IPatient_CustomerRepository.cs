using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IPatient_CustomerRepository
          {
                    public void AddPatient_Customer(Patient_CustomerModel patientcustoermmodel);
                    public void  Update(Patient_CustomerModel _patientcustoermmodel);
                    public Patient_CustomerModel DeltePatient(int id);
          }
}
