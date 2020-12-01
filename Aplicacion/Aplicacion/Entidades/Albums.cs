namespace Aplicacion
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Albums
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_cantante { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_cancion { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string nombre { get; set; }

        public virtual Canciones Canciones { get; set; }

        public virtual Cantantes Cantantes { get; set; }
    }
}
