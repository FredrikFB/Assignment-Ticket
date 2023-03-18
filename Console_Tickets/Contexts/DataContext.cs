using Console_Tickets.Models.Entitites;
using Microsoft.EntityFrameworkCore;

namespace Console_Tickets.Contexts;

internal class DataContext : DbContext
{
    private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\fredr\Desktop\skola\Datalagring\Console-Assignment\Console_Tickets\Contexts\sql-Asignment.mdf;Integrated Security=True;Connect Timeout=30";
    public DbSet<CustomerEntity> Customers { get; set; } = null!;
    public DbSet<TicketEntity> Tickets { get; set; } = null!;
    public DbSet<CommentEntity> Comments { get; set; } = null!;
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TicketEntity>()
            .HasOne<CustomerEntity>(i => i.Customer)
            .WithMany(c => c.Tickets)
            .HasForeignKey(i => i.CustomerId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<CommentEntity>()
            .HasOne<TicketEntity>(c => c.Ticket)
            .WithMany(i => i.Comments)
            .HasForeignKey(c => c.TicketId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
