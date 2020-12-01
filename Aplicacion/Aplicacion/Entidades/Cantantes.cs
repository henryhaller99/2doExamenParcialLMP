namespace Aplicacion
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cantantes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cantantes()
        {
            Albums = new HashSet<Albums>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string apellido { get; set; }

        public int? edad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Albums> Albums { get; set; }
    }
}
