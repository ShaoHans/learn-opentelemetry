using Grpc.Net.Client;
using GrpcService;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ILogger _logger;

    public OrdersController(ILogger<OrdersController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> Get(int userId)
    {
        _logger.LogInformation("查询用户{userId}的订单信息", userId);
        using var channel = GrpcChannel.ForAddress("http://localhost:5162"); // gRPC 服务地址
        var client = new Orders.OrdersClient(channel);

        var reply = await client.GetOrdersAsync(new UserRequest { UserId = userId });
        return Ok(reply.Orders);
    }
}
