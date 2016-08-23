namespace TheServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("banco_bar.mesa")]
    public partial class mesa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mesa()
        {
            mesatempedido = new HashSet<mesatempedido>();
            pedidomesa = new HashSet<pedidomesa>();
        }

        [Key]
        public int idMesa { get; set; }

        [Display(Name = "Nome da Mesa")]
        [StringLength(100)]
        public string nomeMesa { get; set; }

        [Display(Name = "Mesa Vaga")]
        public bool isMesaVaga { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mesatempedido> mesatempedido { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pedidomesa> pedidomesa { get; set; }
    }
}
