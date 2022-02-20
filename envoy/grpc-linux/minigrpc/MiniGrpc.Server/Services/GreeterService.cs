using Grpc.Core;
using MiniGrpc.Server;

namespace MiniGrpc.Server.Services;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;

    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        var hostName = Environment.MachineName;

        _logger.LogInformation(
            "got request from: {RemoteAddress}, local hostname: {HostName}",
            context.GetHttpContext().Connection.RemoteIpAddress,
            hostName);

        return Task.FromResult(new HelloReply
        {
            Message = $"Hello {request.Name} from {hostName}",
        });
    }
}
