namespace TheServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("banco_bar.pedidomesa")]
    public partial class pedidomesa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pedidomesa()
        {
            itenspedido = new HashSet<itenspedido>();
            mesatempedido = new HashSet<mesatempedido>();
        }

        [Key]
        public int idPedidoMesa { get; set; }

        public int? idMesa { get; set; }

        public DateTime dataAbertura { get; set; }

        public DateTime? dataFechamento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<itenspedido> itenspedido { get; set; }

        public virtual mesa mesa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mesatempedido> mesatempedido { get; set; }
    }
}
