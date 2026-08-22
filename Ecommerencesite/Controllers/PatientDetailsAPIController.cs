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

                    // Doctor AssigntoPatient
                    [HttpPost("AddDoctorAssigntoPatient")]
                    public void AddDoctorAssigntoPatient(DoctorAssigntoPatientMOdel adddoctorAssigntoPatientMOdel)
                    {
                              _ipatientDetailsRepository.AddDoctorAssigntoPatient(adddoctorAssigntoPatientMOdel);
                    }

                    //[HttpPost("AddDoctorAssigntoPatient")]
                    //public IActionResult AddDoctorAssigntoPatient([FromBody] DoctorAssigntoPatientMOdel adddoctorAssigntoPatientMOdel)
                    //{
                    //          _ipatientDetailsRepository.AddDoctorAssigntoPatient(adddoctorAssigntoPatientMOdel);
                    //          return Ok(new { message = "Doctor added successfully" });
                    //}

                    [HttpPost("AddPatientDetails")]
                    public void AddPatientDetails(PatientDetailsModel patientDetailsModel)
                    {
                                          _ipatientDetailsRepository.AddPatientDetails(patientDetailsModel);
                    }
                    // Doctor AssigntoPatient

                    [HttpGet("AllDoctorAssigntoPatient")]

                    public List<DoctorAssigntoPatientMOdel> AllDoctorAssigntoPatient()
                    {
                              var doctorAssigntoPatientMOdels = _ipatientDetailsRepository.AllDoctorAssigntoPatient();
                              return doctorAssigntoPatientMOdels;
                    }

                    //[HttpGet("AllDoctorAssigntoPatient")]
                    //public ActionResult<List<DoctorAssigntoPatientMOdel>> AllDoctorAssigntoPatient()
                    //{
                    //          var doctorAssigntoPatientMOdels = _ipatientDetailsRepository.AllDoctorAssigntoPatient();
                    //          return Ok(doctorAssigntoPatientMOdels);
                    //}
                    // PatientDetails
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
                    //[HttpPut("UpdatePatientDetails")]
                    //public void UpdatePatientDetails(PatientDetailsModel updatepatientDetailsModel)
                    //{
                    //                                       _ipatientDetailsRepository.UpdatePatientDetails(updatepatientDetailsModel);      
                    //}

                  //  DeliveryAssignto
                    [HttpGet("AllDeliveryAssignto")]
                    public List<DeliveryAssigntoModel> AllDeliveryAssignto()
                    {
                              var deliveryAssigntoModels = _ipatientDetailsRepository.AllDeliveryAssignto().ToList();
                              return deliveryAssigntoModels;
                    }

                    //[HttpGet("AllDeliveryAssigntoModel")]
                    //public ActionResult<List<DeliveryAssigntoModel>> AllDeliveryAssigntoModel()
                    //{
                    //          var deliveryModels = _ipatientDetailsRepository.AllDeliveryAssignto().ToList();
                    //          return Ok(deliveryModels);
                    //}

                    [HttpPost("AddDeliveryAssignto")]
                    public void AddDeliveryAssignto(DeliveryAssigntoModel adddeliveryAssignto)
                    {
                              _ipatientDetailsRepository.AddDeliveryAssignto(adddeliveryAssignto);

                    }

                    //[HttpPost("AddDeliveryAssigntoModel")]
                    //public IActionResult AddDeliveryAssigntoModel([FromBody] DeliveryAssigntoModel addDeliveryModel)
                    //{
                    //          _ipatientDetailsRepository.AddDeliveryAssignto(addDeliveryModel);
                    //          return Ok(new { message = "Delivery person added successfully" });
                    //}


                    [HttpPut("UpdateDeliveryAssignto")]
                    public void UpdateDeliveryAssignto(DeliveryAssigntoModel updatedeliveryAssignto)
                    {
                              _ipatientDetailsRepository.UpdateDeliveryAssignto(updatedeliveryAssignto);
                    }

                    [HttpGet("GetDeliveryAssignt")]
                    public DeliveryAssigntoModel GetDeliveryAssigntoById(int id)
                    {
                              var deliveryAssigntoModel = _ipatientDetailsRepository.GetDeliveryAssigntoById(id);
                            return deliveryAssigntoModel;
                    }

                    [HttpDelete("DeleteDeliveryAssignto")]
                    public DeliveryAssigntoModel DeleteDeliveryAssignto(int id)
                    {
                              var deliveryAssigntoModel = _ipatientDetailsRepository.DeleteDeliveryAssignto(id);
                            return deliveryAssigntoModel;
                    }



          }


}
