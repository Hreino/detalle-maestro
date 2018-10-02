namespace PruebaDetalleMaestro.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modelo : DbContext
    {
        public Modelo()
            : base("name=Modelo1")
        {
        }

        public virtual DbSet<DetalleEncabezado> DetalleEncabezado { get; set; }
        public virtual DbSet<Encabezado> Encabezado { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleEncabezado>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Encabezado>()
                .Property(e => e.Cliente)
                .IsUnicode(false);

            modelBuilder.Entity<Encabezado>()
                .HasMany(e => e.DetalleEncabezado)
                .WithRequired(e => e.Encabezado)
                .HasForeignKey(e => e.idEncabezado);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.DetalleEncabezado)
                .WithRequired(e => e.Producto)
                .WillCascadeOnDelete(false);
        }
    }
}
