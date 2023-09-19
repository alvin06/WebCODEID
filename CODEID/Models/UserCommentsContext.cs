using Microsoft.EntityFrameworkCore;

namespace CODEID.Models;

public class UserCommentsContext : DbContext
{
    public UserCommentsContext(DbContextOptions<UserCommentsContext> options)
        : base(options)
    {
    }

    public DbSet<UserComments> UserComments { get; set; } = null!;
}