using Microsoft.EntityFrameworkCore;

namespace NoticeApi.Models;

public class NoticeContext: DbContext
{
    public NoticeContext(DbContextOptions<NoticeContext> options): base(options) {}

    public DbSet<User> Users { get; set; }
    public DbSet<Notice> Notices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasKey(u => u.Username);
        
        modelBuilder.Entity<Notice>()  
            .HasKey(n => n.Id);
        
        modelBuilder.Entity<Notice>()  
            .HasOne(n => n.User)  
            .WithMany(u => u.Notices)  
            .HasForeignKey(n => n.Username);
    }
}