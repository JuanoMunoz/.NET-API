using Microsoft.EntityFrameworkCore;
using PRACTICE.Models;

namespace PRACTICE.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
            
        }

        public DbSet<Comment> Comments {  get; set; }

        public DbSet<Stock> Stocks { get; set; }
    }

}
