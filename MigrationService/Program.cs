using Application.Services;
using MigrationService;
using Persistence;
using Persistence.Repositories;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));

builder.AddNpgsqlDbContext<EasyBookingDbContext>("EasyBookingDb");

var host = builder.Build();
host.Run();