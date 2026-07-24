using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class PatientDetailsAPIController : ControllerBase
          {
                    public readonly    IPatientDetailsRepository _ipatientDetailsRepository;

                    public PatientDetailsAPIController(IPatientDetailsRepository ipatientDetailsRepository)
                    {
                            this.  _ipatientDetailsRepository = ipatientDetailsRepository;
                    }

                    [HttpPost("AddDoctorAssigntoPatient")]
                    public void AddDoctorAssigntoPatient(DoctorAssigntoPatientMOdel adddoctorAssigntoPatientMOdel)
                    {
                                  _ipatientDetailsRepository.AddDoctorAssigntoPatient(adddoctorAssigntoPatientMOdel);
                    }

                    [HttpPost("AddPatientDetails")]
                    public void AddPatientDetails(PatientDetailsModel patientDetailsModel)
                    {
                                          _ipatientDetailsRepository.AddPatientDetails(patientDetailsModel);
                    }
                    [HttpGet("AllDoctorAssigntoPatient")]

                    public List<DoctorAssigntoPatientMOdel> AllDoctorAssigntoPatient()
                    {
                           var doctorAssigntoPatientMOdels = _ipatientDetailsRepository.AllDoctorAssigntoPatient();
                            return doctorAssigntoPatientMOdels;
                    }

                    [HttpGet("AllPatientDetails")]
                    public List<PatientDetailsModel> AllPatientDetails()
                    {
                              var patientDetailsModels = _ipatientDetailsRepository.AllPatientDetails();
                            return patientDetailsModels;    
                    }
                    [HttpDelete("DeleteDoctorAssigntoPatient")]

                    public DoctorAssigntoPatientMOdel DeleteDoctorAssigntoPatient(int id)
                    {
                              var doctorAssigntoPatientMOdel = _ipatientDetailsRepository.DeleteDoctorAssigntoPatient(id);
                            return doctorAssigntoPatientMOdel;
                    }
                    [HttpDelete("DeletePatientDetails/{id}")]         
                    public PatientDetailsModel DeletePatientDetails(int id)
                    {
                              var patientDetailsModel = _ipatientDetailsRepository.DeletePatientDetails(id);
                            return patientDetailsModel;
                    }

                    [HttpGet("GetDoctorAssigntoPatientById/{id}")]
                    public DoctorAssigntoPatientMOdel GetDoctorAssigntoPatientById(int id)
                    {
                              var doctorAssigntoPatientMOdel = _ipatientDetailsRepository.GetDoctorAssigntoPatientById(id);
                            return doctorAssigntoPatientMOdel;
                    }

                    [HttpGet("GetPatientDetailsById/{id}")]
                    public PatientDetailsModel GetPatientDetailsById(int id)
                    {
                              var patientDetailsModel = _ipatientDetailsRepository.GetPatientDetailsById(id);
                            return patientDetailsModel;
                    }

                    [HttpPut("UpdateDoctorAssigntoPatient")]
                    public void UpdateDoctorAssigntoPatient(DoctorAssigntoPatientMOdel updatedoctorAssigntoPatientMOdel)
                    {
                              _ipatientDetailsRepository.UpdateDoctorAssigntoPatient(updatedoctorAssigntoPatientMOdel);
                    }
                    [HttpPut("UpdatePatientDetails")]
                    public void UpdatePatientDetails(PatientDetailsModel updatepatientDetailsModel)
                    {
                                                           _ipatientDetailsRepository.UpdatePatientDetails(updatepatientDetailsModel);      
                    }
          }


}
