var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres").WithPgAdmin();
var postgresdb = postgres.AddDatabase("postgresdb");

builder.AddProject<Projects.Host>("host")
    .WithReference(postgresdb)
    .WaitFor(postgresdb);

builder.Build().Run();
