using AutoMapper;
using Core.Model;
using Persistence.Model;

namespace Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SpecialistEntity, Specialist>();
        CreateMap<SpecialtyEntity, Specialty>();
        CreateMap<ServiceEntity, Service>();
    }
}