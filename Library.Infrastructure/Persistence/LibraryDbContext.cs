using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Persistence
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        // DbSet no plural para seguir convenções de nomenclatura
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Configurações das entidades
            builder.Entity<Book>(e =>
            {
                e.HasKey(b => b.Id); // Definir chave primária
                e.Property(b => b.Title).IsRequired().HasMaxLength(100); // Título obrigatório e com limite de caracteres
                e.Property(b => b.Author).IsRequired().HasMaxLength(100); // Autor obrigatório e com limite de caracteres
                e.Property(b => b.PublicationYear).IsRequired(); // Ano obrigatório
            });

            builder.Entity<User>(e =>
            {
                e.HasKey(u => u.Id); // Definir chave primária
                e.Property(u => u.Username).IsRequired().HasMaxLength(50); // Nome de usuário obrigatório e com limite de caracteres
                e.Property(u => u.Email).IsRequired().HasMaxLength(100); // Email obrigatório e com limite de caracteres
            });

            builder.Entity<Loan>(e =>
            {
                e.HasKey(l => l.Id); // Definir chave primária
                e.Property(l => l.LoanDate); // Data de empréstimo obrigatória
                e.Property(l => l.ReturnDate); // Data de devolução opcional

                // Definir relacionamentos com Book e User
                e.HasOne(l => l.Book)
                      .WithMany()
                      .HasForeignKey(l => l.BookId)
                      .OnDelete(DeleteBehavior.Cascade); // Cascatear a exclusão

                e.HasOne(l => l.User)
                      .WithMany()
                      .HasForeignKey(l => l.UserId)
                      .OnDelete(DeleteBehavior.Cascade); // Cascatear a exclusão
            });

            base.OnModelCreating(builder);
        }
    }
}
