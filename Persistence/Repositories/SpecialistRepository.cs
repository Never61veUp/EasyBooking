using Core.Model;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Persistence.Model;

namespace Persistence.Repositories;

public class SpecialistRepository : ISpecialistRepository
{
    private readonly EasyBookingDbContext _dbContext;

    public SpecialistRepository(EasyBookingDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Result<List<SpecialistEntity>>> GetAllSpecialistsAsync()
    {
        var specialists =  await _dbContext.Specialists
            .AsNoTracking()
            .ToListAsync();
        
        return specialists.Count != 0
            ? Result.Success(specialists)
            : Result.Failure<List<SpecialistEntity>>($"No Specialists found");
    }
    public async Task<Result<SpecialistEntity>> AddNewSpecialistAsync(SpecialistEntity specialist)
    {
        await _dbContext.Specialists.AddAsync(specialist);
        var saveResult = await _dbContext.SaveChangesAsync();

        return saveResult > 0 
            ? Result.Success(specialist) 
            : Result.Failure<SpecialistEntity>("Unable to create new specialist");
    }
    public async Task<Result<SpecialistEntity>> GetSpecialistByIdAsync(Guid id)
    {
        var specialist = await _dbContext.Specialists
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        return specialist != null 
            ? Result.Success(specialist) 
            : Result.Failure<SpecialistEntity>("Specialist not found");
    }
    public async Task<Result<SpecialistEntity>> UpdateSpecialist(SpecialistEntity specialist)
    {
        var existingSpecialist = await _dbContext.Specialists
            .FirstOrDefaultAsync(x => x.Id == specialist.Id);

        if (existingSpecialist is null)
            return Result.Failure<SpecialistEntity>("Specialist not found.");

        _dbContext.Entry(existingSpecialist).CurrentValues.SetValues(specialist);
        var saveResult = await _dbContext.SaveChangesAsync();

        return saveResult > 0
            ? Result.Success(specialist)
            : Result.Failure<SpecialistEntity>("Unable to update specialist.");
    }
    public async Task<Result> DeleteSpecialistAsync(Guid id)
    {
        var deleteCount = await _dbContext.Specialists
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync();

        return deleteCount > 0
            ? Result.Success()
            : Result.Failure("Specialist not found or could not be deleted.");
    }
}