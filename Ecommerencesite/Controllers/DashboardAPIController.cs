using Ecommerencesite.Businee_Layer.BusinessLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class DashboardAPIController : ControllerBase
          {
                  public readonly IDashboardRepository _context;
                    public DashboardAPIController(IDashboardRepository context)
                    {
                              this._context = context;

                    }

                    [HttpGet("{userId}")]
                    public IActionResult GetDashboard(int userId)
                    {
                              if (userId <= 0)
                                        return BadRequest("Invalid userId");

                              var result = _context.GetDashboard(userId);
                              return Ok(result);
                    }

                    // 🔹 CREATE MEDICATION + HEALTH (SAME SCREEN)
                    //[HttpPost("create")]
                    //public IActionResult CreateDashMedicineReport([FromBody] Medicationgetmodel objmedication)
                    //{
                    //          if (objmedication == null)
                    //                    return BadRequest("Medication object is null.");

                    //          _context.CreateDashboardData(objmedication, new HealthReport
                    //          {
                    //                    UserId = objmedication.UserId,
                    //                    Weight = null,
                    //                    BloodGlucose = null,
                    //                    s = null,
                    //                    Notes = null
                    //          });
                    //          _context.SaveChanges();

                    //          return Ok(new { message = "Medication added successfully" });
                    //}


                    //[HttpPost("createDashMedication")]
                    //public void CreateDashMedicineReport(Medicationgetmodel objmedication)
                    //{

                    //          //_context.CreateDashMedicineReport(
                    //          //    model.Medication
                    //          //);

                    //          //return Ok(new { message = "Dashboard data created successfully" });
                    //          _context.CreateDashMedicineReport(objmedication);
                    //}

          }
}