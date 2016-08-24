namespace TheServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("banco_bar.itens")]
    public partial class itens
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public itens()
        {
            itenspedido = new HashSet<itenspedido>();
        }

        [Key]
        public int idItem { get; set; }

        [Required]
        [StringLength(100)]
        public string nome { get; set; }

        [StringLength(400)]
        public string informacao { get; set; }
        
        [DataType(DataType.Currency)]
        public float valor { get; set; }

        public int idCategoria { get; set; }

        public virtual categoria categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<itenspedido> itenspedido { get; set; }
    }
}
