using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

                    //[HttpPost("AddPatient_Customer")]
                    //public IActionResult AddPatient_Customer(Patient_CustomerModel model)
                    //{
                    //          //if (!ModelState.IsValid)
                    //          //{
                    //          //          // Isse aapko pata chalega ki kaunsi field fail ho rahi hai
                    //          //          return BadRequest(ModelState);
                    //          //}

                    //          //// Aapka saving logic yahan...
                    //          //return Ok(new { message = "Success" });
                    //}


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
                              //return Ok(_patientcustoermmodel);
                    }
                    [HttpGet("SearchCustomerProfile")]
                    public IActionResult SearchCustomerProfile(int id)
                    {
                              var serach = _patient_CustomerRepository.SearchCustomerProfile(id);
                              return Ok(serach);
                    }
                  

                    [HttpGet("GetAllPatients_Customers")]
                    public List<Patient_CustomerModel> GetAllPatients_Customers()
                    {
                              var listpartient = _patient_CustomerRepository.GetAllPatients_Customers().ToList();
                              return listpartient;
                    }



                    [HttpGet("GetAddressesByEmail/{email}")]
                    public async Task<ActionResult> GetAddressesByEmail(string email)
                    {
                              if (string.IsNullOrEmpty(email)) return BadRequest("Email is missing");

                              var addresses = await _patient_CustomerRepository.GetAddressesByEmailAsync(email);
                              return Ok(new { data = addresses });
                    }



          }
}
