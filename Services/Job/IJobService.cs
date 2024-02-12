
namespace JobHunt.Services.Job;
using JobHunt.Data.Models;
public interface IJobService
{
    public Task<IEnumerable<Job>> GetJobsAsync();
    public Task<Job> GetJobByIdAsync(int id);
    public Task<Job> AddJobAsync(Job job);
    public Task<Job> UpdateJobAsync(Job job);
    public Task<Job> DeleteJobAsync(int id);
    
}