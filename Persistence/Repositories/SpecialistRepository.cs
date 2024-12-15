namespace Persistence.Repositories;

public class SpecialistRepository : ISpecialistRepository
{
    public async Task GetAllSpecialistsAsync()
    {
        //
    }

    public async Task AddNewSpecialist()
    {
        //
    }
}

public interface ISpecialistRepository
{
    Task GetAllSpecialistsAsync();
    Task AddNewSpecialist();
}