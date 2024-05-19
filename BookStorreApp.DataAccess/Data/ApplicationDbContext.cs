using BookStoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
}
