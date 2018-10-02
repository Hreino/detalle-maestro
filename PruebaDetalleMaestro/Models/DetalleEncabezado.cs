namespace PruebaDetalleMaestro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetalleEncabezado")]
    public partial class DetalleEncabezado
    {
        [Key]
        public int idDetalle { get; set; }

        public int idEncabezado { get; set; }

        public int idProducto { get; set; }

        public int Cantidad { get; set; }

        [Column(TypeName = "money")]
        public decimal Total { get; set; }

        public virtual Encabezado Encabezado { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
