using Ecommerencesite.Model;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IPatientDetailsRepository
          {
                    public List<PatientDetailsModel> AllPatientDetails();
                    public void AddPatientDetails(PatientDetailsModel patientDetailsModel);
                    public void UpdatePatientDetails(PatientDetailsModel updatepatientDetailsModel);      
                    public PatientDetailsModel GetPatientDetailsById(int id);
                    public PatientDetailsModel DeletePatientDetails(int id);

                    // DoctorAssigntoPatientMOdel 
                    public List<DoctorAssigntoPatientMOdel> AllDoctorAssigntoPatient();   
                    public void AddDoctorAssigntoPatient(DoctorAssigntoPatientMOdel adddoctorAssigntoPatientMOdel);
                    public void UpdateDoctorAssigntoPatient(DoctorAssigntoPatientMOdel   updatedoctorAssigntoPatientMOdel);
                    public DoctorAssigntoPatientMOdel GetDoctorAssigntoPatientById(int id);
                    public DoctorAssigntoPatientMOdel DeleteDoctorAssigntoPatient(int id);



                    //DeliveryAssignto
                    public List<DeliveryAssigntoModel> AllDeliveryAssignto();
                    public void AddDeliveryAssignto(DeliveryAssigntoModel adddeliveryAssignto);
                    public void UpdateDeliveryAssignto(DeliveryAssigntoModel updatedeliveryAssignto);
                    public DeliveryAssigntoModel GetDeliveryAssigntoById(int id);
                    public DeliveryAssigntoModel DeleteDeliveryAssignto(int id);









          }
}
