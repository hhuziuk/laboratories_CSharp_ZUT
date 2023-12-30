using System.Data.Entity;

namespace lab10
{
    public class InvoiceContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoicePos> InvoicePos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
                .HasMany(i => i.InvoicePosCollection)
                .WithRequired(ip => ip.Invoice)
                .HasForeignKey(ip => ip.InvoiceId)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }

    }
}
