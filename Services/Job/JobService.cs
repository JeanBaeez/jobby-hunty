using JobHunt.Data;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Services.Job;
using JobHunt.Data.Models;
public class JobService : IJobService
{
    private readonly ApplicationDbContext _context;
    public JobService(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<Job>> GetJobsAsync()
    {
        try
        {

            return await _context.Jobs.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            throw;
        }
    }

    public async Task<Job> GetJobByIdAsync(int id) => throw new NotImplementedException();

    public async Task<Job> AddJobAsync(Job job)
    {
        try
        {
            await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();
            return job;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            throw;
        }
    }

    public async Task<Job> UpdateJobAsync(Job job)
    {
        Console.WriteLine(job.Id);
        try
        {
            var entity = _context.Jobs.FirstOrDefault(e => e.Id == job.Id);
            if (entity == null)
            {
                return null;
            }
            _context.Entry(entity).CurrentValues.SetValues(job);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return job;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            throw;
        }
    }

    public Task<Job> DeleteJobAsync(int id)
    {
        var entity = _context.Jobs.FirstOrDefault(e => e.Id == id);
        if (entity == null)
        {
            return null;
        }
        _context.Jobs.Remove(entity);
        _context.SaveChanges();
        return Task.FromResult(entity);
    }
}