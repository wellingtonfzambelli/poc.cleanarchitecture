using CleanArchitecture.Infrastructure.Context;
using CleanArchitecture.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.DI.Configuration;

public static class SqlDatabaseConfig
{
    public static void AddSqlServerDatabase(this IServiceCollection services, IConfiguration config)
    {
        string connection = config.SqlServerConnectionString();

        services.AddDbContext<CleanArchitectureDbContext>(options =>
            options.UseSqlServer(connection));
    }

    public static void AddSqliteDatabase(this IServiceCollection services, IConfiguration config)
    {
        string connection = config.SqlLiteConnectionString();

        services.AddDbContext<CleanArchitectureDbContext>(options =>
            options.UseSqlite(connection));
    }

    public static void AddMySqlDatabase(this IServiceCollection services, IConfiguration config)
    {
        throw new NotImplementedException();
        //string connection = config.GetConnectionString("DefaultConnection");
        //var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));

        //services.AddDbContext<CleanArchitectureDbContext>(options =>
        //    options.UseMySql(connection, serverVersion));
    }

}