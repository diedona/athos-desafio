using System;
using DDonah.AthosDesafio.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DDonah.AthosDesafio.Infra.Generated
{
    public partial class AthosDesafioContext : DbContext
    {
        public AthosDesafioContext()
        {
        }

        public AthosDesafioContext(DbContextOptions<AthosDesafioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administradora> Administradora { get; set; }
        public virtual DbSet<Assunto> Assunto { get; set; }
        public virtual DbSet<Condominio> Condominio { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Administradora>(entity =>
            {
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Assunto>(entity =>
            {
                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Condominio>(entity =>
            {
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Administradora)
                    .WithMany(p => p.Condominio)
                    .HasForeignKey(d => d.AdministradoraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Condominio_Administradora");

                entity.HasOne(d => d.Responsavel)
                    .WithMany(p => p.Condominio)
                    .HasForeignKey(d => d.ResponsavelId)
                    .HasConstraintName("FK_Condominio_Usuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.CondominioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.CondominioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Condominio");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}