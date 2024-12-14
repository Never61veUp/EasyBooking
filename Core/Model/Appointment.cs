using CSharpFunctionalExtensions;

namespace Core.Model;

public sealed class Appointment : Entity<Guid>
{
    public Service Service { get; }
    public Specialist Specialist { get;  }
    public User Client { get; }
    public DateTime AppointmentDate { get; }
    public string Status { get; }

    public Appointment(Guid id, Service service, Specialist specialist, User client, DateTime appointmentDate)
    {
        Id = id;
        Service = service;
        Specialist = specialist;
        Client = client;
        AppointmentDate = appointmentDate;
        Status = "Pending";
    }

    public static Result<Appointment> Create(Guid id, Service service, Specialist specialist, User client,  DateTime appointmentDate)
    {
        if (appointmentDate <= DateTime.Now)
            return Result.Failure<Appointment>("Appointment date must be in the future.");
        return new Appointment(id, service, specialist, client, DateTime.Now);
    }
}