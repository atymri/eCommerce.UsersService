using Dapper;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.RepositoryContracts;
using eCommerce.Infrastructure.DatabaseContext;
using Microsoft.IdentityModel.Tokens;

namespace eCommerce.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly DapperDbContext _context;
    public UserRepository(DapperDbContext context)
    {
        _context = context;
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();

        var query =
            "INSERT INTO public.\"Users\" (\"UserId\", \"Email\", \"Password\", \"PersonName\", \"Gender\") " + 
            "VALUES (@UserId, @Email ,@Password, @PersonName, @Gender);";

        var rowsEffected = await _context.DbConnection.ExecuteAsync(query, user);
        return rowsEffected > 0 ? user : null;
    }

    public async Task<ApplicationUser?> FindUserByEmailAndPassword(string? email, string? password)
    {
        var query = 
            "SELECT * " +
            "FROM public.\"Users\" " +
            "WHERE \"Password\"=@Password AND \"Email\"=@Email;";

        var user = await _context.DbConnection
            .QueryFirstOrDefaultAsync<ApplicationUser>(query, new
        {
            Password = password,
            Email = email
        });

        return user;
    }

    public async Task<ApplicationUser?> GetUserByUserID(Guid userId)
    {
        var query =
            "SELECT * " +
            "FROM public.\"Users\" " +
            "WHERE \"UserId\"=@UserId";

        var user = await _context.DbConnection
            .QueryFirstOrDefaultAsync<ApplicationUser>(query, new { UserId = userId });

        return user;
    }
}

