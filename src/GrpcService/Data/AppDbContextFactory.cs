using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GrpcService.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        // 这里写你的 PostgreSQL 连接字符串
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=observabilitydemo;Username=postgres;Password=123456");

        return new AppDbContext(optionsBuilder.Options);
    }
}
