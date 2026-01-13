using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class Patient_CustomerAPIController : ControllerBase
          {
                  private readonly IPatient_CustomerRepository _patient_CustomerRepository;
                    public Patient_CustomerAPIController(IPatient_CustomerRepository patient_CustomerRepository)
                    {
                              this._patient_CustomerRepository = patient_CustomerRepository;
                    }
                    [HttpPost]
                    [Route("AddPatient_Customer")]
                    public void AddPatient_Customer(Patient_CustomerModel patientcustoermmodel)
                    {
                              _patient_CustomerRepository.AddPatient_Customer(patientcustoermmodel);
                    }
                    [HttpDelete]
                    [Route("DeletePatient/{id}")]
                    public IActionResult DeletePatient(int id)
                    {
                              var deletepatient= _patient_CustomerRepository.DeletePatient(id);
                              return Ok(deletepatient);
                    }
                    [HttpPut]
                    [Route("UpdatePatient_Customer")]
                    public void UpdatePatient_Customer( Patient_CustomerModel _patientcustoermmodel)
                    {
                              _patient_CustomerRepository.Update( _patientcustoermmodel);
                    }
                    [HttpGet("GetAllPatients_Customers")] 
                    public List<Patient_CustomerModel> GetAllPatients_Customers()
                    {
                              var listpatients= _patient_CustomerRepository.GetAllPatients_Customers();
                              return listpatients;
                    }
          }
}
