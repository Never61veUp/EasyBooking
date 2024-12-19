using Core.Model;
using CSharpFunctionalExtensions;
using Persistence.Model;

namespace Persistence.Repositories;

public interface ISpecialistRepository
{
    Task<Result<List<SpecialistEntity>>> GetAllSpecialistsAsync();
    Task<Result<SpecialistEntity>> AddNewSpecialistAsync(SpecialistEntity specialist);
    Task<Result<SpecialistEntity>> GetSpecialistByIdAsync(Guid id);
    Task<Result<SpecialistEntity>> UpdateSpecialist(SpecialistEntity specialist);
    Task<Result> DeleteSpecialistAsync(Guid id);
}