using AutoMapper;
using Core.Model;
using CSharpFunctionalExtensions;
using Persistence.Model;
using Persistence.Repositories;

namespace Application.Services;

public class SpecialistService : ISpecialistService
{
    private readonly ISpecialistRepository _specialistRepository;
    private readonly IMapper _mapper;

    public SpecialistService(ISpecialistRepository specialistRepository, IMapper mapper)
    {
        _specialistRepository = specialistRepository;
        _mapper = mapper;
    }

    public async Task<Result<List<Specialist>>> GetAllSpecialistsAsync()
    {
        var specialistEntitiesResult = await _specialistRepository.GetAllSpecialistsAsync();
        if (!specialistEntitiesResult.IsFailure) 
            return Result.Failure<List<Specialist>>(specialistEntitiesResult.Error);
        
        var specialists = _mapper.Map<List<Specialist>>(specialistEntitiesResult.Value);
        return Result.Success(specialists);

    }
    public async Task<Result<Specialist>> AddNewSpecialist(Specialist specialist)
    {
        var specialistEntity = _mapper.Map<SpecialistEntity>(specialist);
        
        var specialistEntityResult = await _specialistRepository.AddNewSpecialistAsync(specialistEntity);
        if (specialistEntityResult.IsFailure) 
            return Result.Failure<Specialist>(specialistEntityResult.Error);
        
        return Result.Success(specialist);
    }
    public async Task<Result<Specialist>> GetSpecialistByIdAsync(Guid id)
    {
        var specialistEntityResult = await _specialistRepository.GetSpecialistByIdAsync(id);
        
        if(specialistEntityResult.IsFailure)
            return Result.Failure<Specialist>(specialistEntityResult.Error);
        
        var specialist = _mapper.Map<Specialist>(specialistEntityResult.Value);
        return Result.Success(specialist);
    }
    public async Task<Result<Specialist>> UpdateSpecialist(Specialist specialist)
    {
        var specialistEntity = _mapper.Map<SpecialistEntity>(specialist);
        
        var specialistsEntityResult = await _specialistRepository.UpdateSpecialist(specialistEntity);
        if(specialistsEntityResult.IsFailure)
            return Result.Failure<Specialist>(specialistsEntityResult.Error);
        
        return Result.Success(specialist);
    }
    public async Task<Result> DeleteSpecialistAsync(Guid id)
    {
        var specialistResult = await _specialistRepository.DeleteSpecialistAsync(id);
        
        if(specialistResult.IsFailure)
            return Result.Failure(specialistResult.Error);
        
        return Result.Success();
    }
}