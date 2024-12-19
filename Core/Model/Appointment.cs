using Core.Model.ValueObjects;
using CSharpFunctionalExtensions;

namespace Core.Model;

public enum Status
{
    Pending,
    Confirmed,
    Cancelled,
    Completed
}
public sealed class Appointment : Entity<Guid>
{
    private Appointment(Guid id, Guid masterId, Guid customerId, Guid serviceId, DateRange dateRange) : base(id)
    {
        MasterId = masterId;
        CustomerId = customerId;
        ServiceId = serviceId;
        DateRange = dateRange;
        Status = Status.Pending;
    }
    
    public Guid MasterId { get; }
    public Guid CustomerId { get; }
    public Guid ServiceId { get; }
    public DateRange DateRange { get; }
    public Status Status { get; private set; }

    public static Result<Appointment> Create(Guid id, Guid masterId, Guid customerId, Guid serviceId, DateRange dateRange)
    {
        return Result.Success(new Appointment(id, masterId, customerId, serviceId, dateRange));
    }
    public Result Cancel()
    {
        if (Status == Status.Cancelled)
            return Result.Failure("Appointment is already canceled");

        Status = Status.Cancelled;
        return Result.Success();
    }
    public Result Confirm()
    {
        if (Status == Status.Cancelled)
            return Result.Failure("Appointment is already canceled");
        if (Status == Status.Confirmed)
            return Result.Failure("Appointment is already confirmed");

        Status = Status.Confirmed;
        return Result.Success();
    }
}