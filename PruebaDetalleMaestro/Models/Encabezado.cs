namespace PruebaDetalleMaestro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Encabezado")]
    public partial class Encabezado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Encabezado()
        {
            DetalleEncabezado = new HashSet<DetalleEncabezado>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Cliente { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleEncabezado> DetalleEncabezado { get; set; }
    }
}
