var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres").WithPgAdmin().WithDataVolume(isReadOnly: false).AddDatabase("EasyBookingDb"); 

// var connectionString = builder.AddConnectionString("EasyBookingDb");

builder.AddProject<Projects.Host>("host")
    .WithReference(postgres)
    .WaitFor(postgres);

builder.AddProject<Projects.MigrationService>("migrations")
    .WithReference(postgres)
    .WaitFor(postgres);

builder.Build().Run();
