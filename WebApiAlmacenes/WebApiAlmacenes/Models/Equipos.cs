namespace WebApiAlmacenes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Equipos
    {
        [Key]
        public int iIdEquipo { get; set; }

        public int iIdMarca { get; set; }

        public int iIdModelo { get; set; }

        [StringLength(100)]
        public string vchNoSerie { get; set; }

        public int? iExistencia { get; set; }

        public int iIdProveedor { get; set; }

        public int iIdAlmacen { get; set; }

        public virtual Almacenes Almacenes { get; set; }

        public virtual Marcas Marcas { get; set; }

        public virtual Modelos Modelos { get; set; }

        public virtual Proveedores Proveedores { get; set; }
    }
}
