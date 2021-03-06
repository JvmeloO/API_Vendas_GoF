﻿// <auto-generated />
using API_Vendas_GoF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API_Vendas_GoF.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200615074837_Migration01")]
    partial class Migration01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API_Vendas_GoF.Models.ClientesModel", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("API_Vendas_GoF.Models.ProdutosModel", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Preco")
                        .HasColumnType("real");

                    b.HasKey("IdProduto");

                    b.HasIndex("IdCliente");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("API_Vendas_GoF.Models.ProdutosModel", b =>
                {
                    b.HasOne("API_Vendas_GoF.Models.ClientesModel", "Cliente")
                        .WithMany("Produtos")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK_PRODUTOS_CLIENTE")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
