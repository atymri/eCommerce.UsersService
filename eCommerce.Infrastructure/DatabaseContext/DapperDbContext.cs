using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace eCommerce.Infrastructure.DatabaseContext;
internal class DapperDbContext
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _dbConnection;
    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        var connectionStringTemplate = _configuration.GetConnectionString("PostgresConnection")
            ?? throw new KeyNotFoundException("Connection string was not found.");

        var connectionString = connectionStringTemplate
            .Replace("$POSTGRES_HOST", Environment.GetEnvironmentVariable("POSTGRES_HOST"))
            .Replace("$POSTGRES_PASS", Environment.GetEnvironmentVariable("POSTGRES_PASS");

        _dbConnection = new NpgsqlConnection(connectionString);
    }

    public IDbConnection DbConnection => _dbConnection;
}

