using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IHiringServiceRepository
          {

                    // Job Postings (Employer)
                    Task<IEnumerable<Team_HiringModules>> GetAllJobPostingsAsync();
                    Task<Team_HiringModules> GetJobPostingByIdAsync(int id);
                    Task<Team_HiringModules> CreateJobPostingAsync(Team_HiringModules jobPosting);
                    Task<Team_HiringModules> UpdateJobPostingAsync(Team_HiringModules updatejobposting);
                    Task<Team_HiringModules> DeleteJobPostingAdync(Team_HiringModules deletejobposting);

                    // Candidate Applications (Employee)
                    Task<IEnumerable<CandidateApplicationModule>> GetAllApplicationsAsync();
                    Task<CandidateApplicationModule> ApplyJobAsync(CandidateApplicationModule application);
                    Task<bool> UpdateApplicationStatusAsync(int id, string status);
          }
}
