using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SNSModels;
namespace SNSDataAccessLayer.Contexts
{
    public class NotificationSystemContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=notifiy;Username=postgres;password=root");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(u => u.Id).HasName("PK_UserId");
                u.HasData(new User() { Id = 101, Name = "Krishna", Email = "krishna@gamil.com", PhoneNumber = "9998887776" });
            });

            modelBuilder.Entity<Notification>(n =>
            {
                n.HasKey(n => n.Id).HasName("PK_NotificationId");
                n.HasOne(n => n.User).WithMany(n => n.Notifications)
                .HasForeignKey(u => u.FromUserId).HasConstraintName("FK_User_Notification")
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}