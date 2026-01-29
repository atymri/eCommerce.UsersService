using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace eCommerce.Infrastructure.DatabaseContext;
internal class DapperDbContext
{
    private readonly IDbConnection _dbConnection;
    public DapperDbContext(string connectionString)
    {
        _dbConnection = new NpgsqlConnection(connectionString);
    }

    public IDbConnection DbConnection => _dbConnection;
}

