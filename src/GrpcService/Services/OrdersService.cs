using Grpc.Core;
using GrpcService.Data;
using Microsoft.EntityFrameworkCore;

namespace GrpcService.Services;

public class OrdersService : Orders.OrdersBase
{
    private readonly AppDbContext _db;

    public OrdersService(AppDbContext db)
    {
        _db = db;
    }

    public override async Task<OrdersReply> GetOrders(UserRequest request, ServerCallContext context)
    {
        var orders = await _db.Orders
            .Where(o => o.UserId == request.UserId)
            .Select(o => new OrderInfo
            {
                Id = o.Id,
                Product = o.Product,
                Amount = o.Amount
            }).ToListAsync();

        var reply = new OrdersReply();
        reply.Orders.AddRange(orders);
        return reply;
    }
}
