var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Host>("host");

builder.Build().Run();
