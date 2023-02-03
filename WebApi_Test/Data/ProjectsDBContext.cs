using Microsoft.EntityFrameworkCore;
using WebApi_Test.Data.Maps;
using WebApi_Test.Models;

namespace WebApi_Test.Data
{
    public class ProjectsDBContext : DbContext
    {
        public ProjectsDBContext(DbContextOptions<ProjectsDBContext> options) : base(options)
        {
        }

        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<ItemModel> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new ItemMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
