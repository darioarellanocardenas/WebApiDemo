namespace WebApiAlmacenes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Modelos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Modelos()
        {
            Equipos = new HashSet<Equipos>();
        }

        [Key]
        public int iIdModelo { get; set; }

        [StringLength(100)]
        public string vchNombre { get; set; }

        [StringLength(10)]
        public string vchClave { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Equipos> Equipos { get; set; }
    }
}
