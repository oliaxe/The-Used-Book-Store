using Microsoft.EntityFrameworkCore;
using UsedBookStore.API.Models.Entities;

namespace UsedBookStore.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public virtual DbSet<BookEntity> Books { get; set; }
        public virtual DbSet<ConditionEntity> Conditions { get; set; }
        public virtual DbSet<FormatEntity> Formats { get; set; }
        public virtual DbSet<GenreEntity> Genres { get; set; }
        public virtual DbSet<CustomerEntity> Customers { get; set; }
        public virtual DbSet<OrderEntity> Orders { get; set; }
        public virtual DbSet<OrderRowEntity> OrderRows { get; set; }
    }
}
