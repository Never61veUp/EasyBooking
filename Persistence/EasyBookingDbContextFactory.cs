// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;
// using Microsoft.Extensions.Configuration;
// using System.IO;
//
// namespace Persistence;
//
// public class EasyBookingDbContextFactory : IDesignTimeDbContextFactory<EasyBookingDbContext>
// {
//     // public EasyBookingDbContext CreateDbContext(string[] args)
//     // {
//     //     var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__EasyBookingDb");
//     //
//     //     if (string.IsNullOrEmpty(connectionString))
//     //     {
//     //         throw new InvalidOperationException("Строка подключения не найдена в переменной окружения.");
//     //     }
//     //
//     //     var optionsBuilder = new DbContextOptionsBuilder<EasyBookingDbContext>();
//     //     optionsBuilder.UseNpgsql(connectionString);
//     //
//     //     return new EasyBookingDbContext(optionsBuilder.Options);
//     // }
// }