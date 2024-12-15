using Core.Model.ValueObjects;
using CSharpFunctionalExtensions;

namespace Core.Model;

public sealed class Specialist : Entity<Guid>
{
    private readonly List<Specialty> _specialties;
    private readonly List<Service> _services;
    private readonly List<Review> _reviews;

    private Specialist(Guid id, FullName fullName, string bio, List<Specialty> specialties, List<Service> services, List<Review> reviews, ContactInfo contactInfo)
    {
        Id = id;
        FullName = fullName;
        _specialties = specialties;
        Bio = bio;
        _services = services;
        _reviews = reviews;
        ContactInfo = contactInfo;
    }
    
    public FullName FullName { get; }
    public IReadOnlyList<Specialty> Specialties => _specialties;
    public string Bio { get; }
    public IReadOnlyList<Service> Services => _services;
    public IReadOnlyList<Review> Reviews => _reviews;
    public ContactInfo ContactInfo { get; }

    public static Result<Specialist> Create(Guid id, FullName fullName, string bio, 
        List<Specialty> specialties, List<Service> services, List<Review> reviews, ContactInfo contactInfo)
    {
        return new Specialist(id, fullName, bio, specialties, services, reviews, contactInfo);
    }
}