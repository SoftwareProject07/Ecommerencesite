using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class HiringServiceRepository : IHiringServiceRepository
          {
                    public readonly Ecommerecewebstedatabase _hringservices;

                    public HiringServiceRepository(Ecommerecewebstedatabase _candidateapplication)
                    {
                              this._hringservices = _candidateapplication;
                    }

                    // 1. Candidate Apply Job
                    public async Task<CandidateApplicationModule> ApplyJobAsync(CandidateApplicationModule application)
                    {
                              await _hringservices.Set<CandidateApplicationModule>().AddAsync(application);
                              await _hringservices.SaveChangesAsync();
                              return application;
                    }

                    // 2. Create Job Posting
                    public async Task<Team_HiringModules> CreateJobPostingAsync(Team_HiringModules jobPosting)
                    {
                              await _hringservices.Set<Team_HiringModules>().AddAsync(jobPosting);
                              await _hringservices.SaveChangesAsync();
                              return jobPosting;
                    }

                    // 3. Delete Job Posting
                    public async Task<Team_HiringModules> DeleteJobPostingAdync(Team_HiringModules deletejobposting)
                    {
                              _hringservices.Set<Team_HiringModules>().Remove(deletejobposting);
                              await _hringservices.SaveChangesAsync();
                              return deletejobposting;
                    }

                    // 4. Get All Candidate Applications
                    public async Task<IEnumerable<CandidateApplicationModule>> GetAllApplicationsAsync()
                    {
                              return await _hringservices.Set<CandidateApplicationModule>().ToListAsync();
                    }

                    // 5. Get All Job Postings
                    public async Task<IEnumerable<Team_HiringModules>> GetAllJobPostingsAsync()
                    {
                              return await _hringservices.Set<Team_HiringModules>().ToListAsync();
                    }

                    // 6. Get Job Posting By Id
                    public async Task<Team_HiringModules> GetJobPostingByIdAsync(int id)
                    {
                              return await _hringservices.Set<Team_HiringModules>().FindAsync(id);
                    }

                    // 7. Update Application Status
                    public async Task<bool> UpdateApplicationStatusAsync(int id, string status)
                    {
                              var application = await _hringservices.Set<CandidateApplicationModule>().FindAsync(id);
                              if (application == null)
                              {
                                        return false;
                              }

                              application.Status = status;
                              _hringservices.Set<CandidateApplicationModule>().Update(application);
                              await _hringservices.SaveChangesAsync();
                              return true;
                    }

                    // 8. Update Job Posting
                    public async Task<Team_HiringModules> UpdateJobPostingAsync(Team_HiringModules updatejobposting)
                    {
                              _hringservices.Set<Team_HiringModules>().Update(updatejobposting);
                              await _hringservices.SaveChangesAsync();
                              return updatejobposting;
                    }
          }
}