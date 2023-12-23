
using DreamNekosConnect.Lib.Entities;
using DreamNekosConnect.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace DreamNekosConnect.Lib
{
    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        private DbConnectEnv _dbConnectEnv;
        public ApplicationDbContext(DbConnectEnv DbConnectEnv)
        {
            _dbConnectEnv = DbConnectEnv;
        }
        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<InterestEntity> Interests { get; set; }
        public virtual DbSet<InterestTypeEntity> InterestType { get; set; }
        public virtual DbSet<UserInterestEntity> UserInterest { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectStr = $"Server=postgres_db;Database={_dbConnectEnv.Database};Username={_dbConnectEnv.Username};Password={_dbConnectEnv.Password}";
            optionsBuilder.UseNpgsql(connectStr);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.Interest)
                .WithMany(x => x.Users)
                .UsingEntity<UserInterestEntity>(
                    l => l.HasOne<InterestEntity>(x => x.Interest).WithMany( x => x.UserInterestEntities).HasForeignKey(x => x.InterestId),
                    r => r.HasOne<UserEntity>(x => x.User).WithMany(x => x.UserInterest).HasForeignKey(x => x.UserId)
                );

            modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.Links)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<InterestEntity>()
                .HasOne(x => x.InterestType)
                .WithMany(x => x.Interests)
                .HasForeignKey(x => x.InterestTypeId);
        }

    }
}
