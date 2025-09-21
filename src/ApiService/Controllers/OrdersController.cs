using Grpc.Net.Client;
using GrpcService;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    [HttpGet("{userId}")]
    public async Task<IActionResult> Get(int userId)
    {
        using var channel = GrpcChannel.ForAddress("http://localhost:5162"); // gRPC 服务地址
        var client = new Orders.OrdersClient(channel);

        var reply = await client.GetOrdersAsync(new UserRequest { UserId = userId });
        return Ok(reply.Orders);
    }
}
