using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
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
                    //[HttpGet("SearchCustomerProfile")]
                    //public IActionResult SearchCustomerProfile(string email, string phone)
                    //{
                    //          if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone))
                    //          {
                    //                    return BadRequest(new
                    //                    {
                    //                              status = false,
                    //                              message = "Email and Phone required"
                    //                    });
                    //          }

                    //          var customer = _patient_CustomerRepository
                    //              .FirstOrDefault(x => x.Email == email && x.Phone == phone);

                    //          if (customer == null)
                    //          {
                    //                    return NotFound(new
                    //                    {
                    //                              status = false,
                    //                              message = "Customer not found"
                    //                    });
                    //          }

                    //          return Ok(new
                    //          {
                    //                    status = true,
                    //                    data = customer
                    //          });
                    //}

                    [HttpGet("GetAllPatients_Customers")]
                    public IActionResult GetAllPatients_Customers()
                    {
                              try
                              {
                                        var result = _patient_CustomerRepository.GetAllPatients_Customers().ToList();

                                        return Ok(result);
                              }
                              catch (Exception ex)
                              {
                                        // 🔴 Ye error Render logs me dikhega
                                        return StatusCode(500, ex.Message);
                              }
                    }

          }
}
