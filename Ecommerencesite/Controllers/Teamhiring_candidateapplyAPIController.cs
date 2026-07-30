using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class Teamhiring_candidateapplyAPIController : ControllerBase
          {
                    public readonly IHiringServiceRepository hiringservices;

                    public Teamhiring_candidateapplyAPIController(IHiringServiceRepository _hiringServiceRepository)
                    {
                              this.hiringservices = _hiringServiceRepository; // Added missing semicolon
                    }

                    // --- 1. Get All Job Postings ---
                    [HttpGet("get-all-jobs")]
                    public async Task<ActionResult<IEnumerable<Team_HiringModules>>> GetAllJobs()
                    {
                              var jobs = await hiringservices.GetAllJobPostingsAsync();
                              return Ok(jobs);
                    }

                    // --- 2. Get Job Posting By Id ---
                    [HttpGet("get-job-by-id/{id}")]
                    public async Task<ActionResult<Team_HiringModules>> GetJobById(int id)
                    {
                              var job = await hiringservices.GetJobPostingByIdAsync(id);
                              if (job == null)
                              {
                                        return NotFound(new { message = "Job posting not found" });
                              }
                              return Ok(job);
                    }

                    // --- 3. Create Job Posting (Employer) ---
                    [HttpPost("create-job")]
                    public async Task<ActionResult<Team_HiringModules>> CreateJob([FromBody] Team_HiringModules jobPosting)
                    {
                              if (!ModelState.IsValid)
                              {
                                        return BadRequest(ModelState);
                              }

                              var createdJob = await hiringservices.CreateJobPostingAsync(jobPosting);
                              return Ok(new { message = "Job created successfully", data = createdJob });
                    }

                    // --- 4. Update Job Posting ---
                    [HttpPut("update-job")]
                    public async Task<ActionResult<Team_HiringModules>> UpdateJob([FromBody] Team_HiringModules updateJobPosting)
                    {
                              if (!ModelState.IsValid)
                              {
                                        return BadRequest(ModelState);
                              }

                              var updated = await hiringservices.UpdateJobPostingAsync(updateJobPosting);
                              return Ok(new { message = "Job updated successfully", data = updated });
                    }

                    // --- 5. Delete Job Posting ---
                    [HttpDelete("delete-job/{id}")]
                    public async Task<IActionResult> DeleteJob(int id)
                    {
                              var existingJob = await hiringservices.GetJobPostingByIdAsync(id);
                              if (existingJob == null)
                              {
                                        return NotFound(new { message = "Job posting not found" });
                              }

                              await hiringservices.DeleteJobPostingAdync(existingJob);
                              return Ok(new { message = "Job posting deleted successfully" });
                    }

                    // --- 6. Candidate Apply for Job ---
                    [HttpPost("apply-job")]
                    public async Task<ActionResult<CandidateApplicationModule>> ApplyJob([FromBody] CandidateApplicationModule application)
                    {
                              if (!ModelState.IsValid)
                              {
                                        return BadRequest(ModelState);
                              }

                              var submittedApp = await hiringservices.ApplyJobAsync(application);
                              return Ok(new { message = "Applied successfully", data = submittedApp });
                    }

                    // --- 7. Get All Candidate Applications ---
                    [HttpGet("get-all-applications")]
                    public async Task<ActionResult<IEnumerable<CandidateApplicationModule>>> GetAllApplications()
                    {
                              var applications = await hiringservices.GetAllApplicationsAsync();
                              return Ok(applications);
                    }

                    // --- 8. Update Application Status ---
                    [HttpPut("update-application-status/{id}")]
                    public async Task<IActionResult> UpdateApplicationStatus(int id, [FromBody] string status)
                    {
                              var result = await hiringservices.UpdateApplicationStatusAsync(id, status);
                              if (!result)
                              {
                                        return NotFound(new { message = "Candidate application not found" });
                              }

                              return Ok(new { message = "Application status updated successfully" });
                    }
          }
}