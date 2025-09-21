namespace GrpcService.Data;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
}

public class Order
{
    public int Id { get; set; }
    public string Product { get; set; } = default!;
    public double Amount { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = default!;
}
