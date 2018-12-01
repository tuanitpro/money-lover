namespace Core.DataProvider
{
    using Core.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(ConfigureAccount);
            modelBuilder.Entity<Expense>(ConfigureExpense);
        }

        private void ConfigureAccount(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.Property(ci => ci.Email)
                .IsRequired(true)
                .HasMaxLength(250);
        }

        private void ConfigureExpense(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable("Expense");
            builder.Property(ci => ci.Money)
                .IsRequired(true)
                .HasColumnType("decimal(18,0)");
        }
    }
}