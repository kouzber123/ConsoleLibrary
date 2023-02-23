using bookLibary.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace bookLibary.Data
{
  public class DataContext : DbContext
  {

    //we have to set the classes as dbset
    public DbSet<Author>? Authors { get; set; }
    // public DbSet<AuthorProfile>? AuthorProfiles { get; set; }
    public DbSet<Book>? Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(GetConnectionString());
    }

    private static string GetConnectionString()
    {
      var builder = new SqlConnectionStringBuilder
      {
        DataSource = "localhost\\SQLEXPRESS",
        InitialCatalog = "BookLibrary",
        IntegratedSecurity = true,
        TrustServerCertificate = true,
      };
      return builder.ConnectionString;

    }

  }


}