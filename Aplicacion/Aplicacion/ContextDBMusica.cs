using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Aplicacion
{
    public partial class ContextDBMusica : DbContext
    {
        public ContextDBMusica()
            : base("name=ContextDBMusica")
        {
        }

        public virtual DbSet<Canciones> Canciones { get; set; }
        public virtual DbSet<Cantantes> Cantantes { get; set; }
        public virtual DbSet<Albums> Albums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Canciones>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Canciones>()
                .HasMany(e => e.Albums)
                .WithRequired(e => e.Canciones)
                .HasForeignKey(e => e.id_cancion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cantantes>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cantantes>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Cantantes>()
                .HasMany(e => e.Albums)
                .WithRequired(e => e.Cantantes)
                .HasForeignKey(e => e.id_cantante)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Albums>()
                .Property(e => e.nombre)
                .IsUnicode(false);
        }
    }
}
