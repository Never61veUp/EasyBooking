using Core.Model;
using CSharpFunctionalExtensions;

namespace Application.Services;

public interface ISpecialistService
{
    Task<Result<List<Specialist>>> GetAllSpecialistsAsync();
    Task<Result<Specialist>> AddNewSpecialist(Specialist specialist);
    Task<Result<Specialist>> GetSpecialistByIdAsync(Guid id);
    Task<Result<Specialist>> UpdateSpecialist(Specialist specialist);
    Task<Result> DeleteSpecialistAsync(Guid id);

}