using Microsoft.EntityFrameworkCore;
using ProjekatAsp.Domain;
using System;

namespace ProjekatAsp.DataAccess
{
    public class ShopDbContext : DbContext
    {
        public IApplicationUser User { get; }
        public ShopDbContext(DbContextOptions options = null) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<UserUseCase>().HasKey(x => new { x.UserId, x.UserCaseId });
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-S8HRDVP;Initial Catalog=ShopProjekat;Integrated Security=True");
        }


        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.UtcNow;
                            e.UpdatedBy = User?.Identity;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<AvailableData> AvailableDatas { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<UserUseCase> UserUseCase { get; set; }
        public DbSet<UserUseCase> ImageProduct { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<ProductsCart> ProductsCarts { get; set; }
        public DbSet<Cart> Carts { get; set; }

    }
}
