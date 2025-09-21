using GrpcService.Data;
using GrpcService.Services;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

Console.Title = "GrpcService";
var builder = WebApplication.CreateBuilder(args);

var connStr = builder.Configuration.GetConnectionString("Postgres") ??
              "Host=localhost;Port=5432;Database=observabilitydemo;Username=postgres;Password=123456";

// EF Core PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connStr));

// gRPC
builder.Services.AddGrpc();

// OpenTelemetry
builder.Services.AddOpenTelemetry()
    .WithTracing(tracerProviderBuilder =>
    {
        tracerProviderBuilder
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("GrpcService"))
            .AddAspNetCoreInstrumentation()
            .AddEntityFrameworkCoreInstrumentation()
            .AddConsoleExporter()
            .AddOtlpExporter(opt =>
            {
                opt.Endpoint = new Uri("http://localhost:4317"); // Tempo OTLP gRPC
                opt.Protocol = OpenTelemetry.Exporter.OtlpExportProtocol.Grpc;
            });
    });

var app = builder.Build();

app.MapGrpcService<OrdersService>();
app.MapGet("/", () => "GrpcService is running...");

app.Run();
