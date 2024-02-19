using DreamNekos.Core.Entities;
using DreamNekos.Core.Entities.Activity;
using DreamNekosConnect.Lib.Entities;
using Microsoft.EntityFrameworkCore;

namespace DreamNekos.Core
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public virtual DbSet<ActivityEntity> Activity { get; set; }
        public virtual DbSet<ActivityTypeEntity> ActivityType { get; set; }
        public virtual DbSet<ActivitySubTypeEntity> ActivitySubType { get; set; }

        public virtual DbSet<SkillEntity> Skill { get; set; }

        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<UserActivityEntity> UserActivity { get; set; }
        public virtual DbSet<UserSkillEntity> UserSkill { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityTypeEntity>()
                .HasMany(x => x.SubTypes)
                .WithOne(x => x.TypeEntity);

            modelBuilder.Entity<ActivitySubTypeEntity>()
                .HasMany(x => x.Activities)
                .WithOne(x => x.ActivitySubType);

            modelBuilder.Entity<ActivityEntity>()
                .HasMany(x => x.RelatedSkills)
                .WithMany(x => x.RelatedActivities);


            /*modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.Interest)
                .WithMany(x => x.Users)
                .UsingEntity<UserActivityEntity>(
                    l => l.HasOne<ActivityEntity>(x => x.Interest).WithMany(x => x.UserInterestEntities).HasForeignKey(x => x.InterestId),
                    r => r.HasOne<UserEntity>(x => x.User).WithMany(x => x.UserInterest).HasForeignKey(x => x.UserId)
                );*/

            modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.Activities)
                .WithMany(x => x.Users)
                .UsingEntity<UserActivityEntity>();

            modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.Skills)
                .WithMany(x => x.Users)
                .UsingEntity<UserSkillEntity>();

            modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.Links)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}
