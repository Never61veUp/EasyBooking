using AutoMapper;
using Core.Model;
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

    public async Task<List<Specialist>> GetAllSpecialists()
    {
        var specialists = await _specialistRepository.GetAllSpecialistsAsync();
        return _mapper.Map<List<Specialist>>(specialists);
    }

    public async Task<bool> AddNewSpecialist(Specialist specialist)
    {
        var specialistEntity = _mapper.Map<SpecialistEntity>(specialist);
        return await _specialistRepository.AddNewSpecialist(specialistEntity);
    }
}

public interface ISpecialistService
{
    Task<List<Specialist>> GetAllSpecialists();
    Task<bool> AddNewSpecialist(Specialist specialist);
}