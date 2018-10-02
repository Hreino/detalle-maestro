namespace PruebaDetalleMaestro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Producto")]
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            DetalleEncabezado = new HashSet<DetalleEncabezado>();
        }

        [Key]
        public int idProducto { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Column(TypeName = "money")]
        public decimal Precio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleEncabezado> DetalleEncabezado { get; set; }
    }
}
