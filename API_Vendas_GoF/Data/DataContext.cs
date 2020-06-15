using API_Vendas_GoF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Vendas_GoF.Data
{
    public class DataContext : DbContext
    {
        public DbSet<ClientesModel> Clientes { get; set; }

        public DbSet<ProdutosModel> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Vendas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClientesModel>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder.Entity<ProdutosModel>(entity =>
            {
                entity.HasOne(c => c.Cliente)
                      .WithMany(p => p.Produtos)
                      .HasForeignKey(c => c.IdCliente)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_PRODUTOS_CLIENTE");
            });
        }
    }
}
