using Microsoft.AspNetCore.Server.Kestrel.Core;
using MiniGrpc.Server.Services;

namespace MiniGrpc.Server;

internal static class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

        // Add services to the container.
        builder.Services.AddGrpc();
        builder.Services.AddGrpcReflection();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.MapGrpcService<GreeterService>();
        app.MapGrpcReflectionService();

        app.Run();
    }
}