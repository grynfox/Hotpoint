namespace TheServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("banco_bar.grupopermicoes")]
    public partial class grupopermicoes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public grupopermicoes()
        {
            pessoa = new HashSet<pessoa>();
        }

        [Key]
        public int idgrupoPermicoes { get; set; }

        [Required]
        [StringLength(45)]
        public string nome { get; set; }

        public bool cMesa { get; set; }

        public bool eMesa { get; set; }

        public bool fMesa { get; set; }

        public bool aPedido { get; set; }

        public bool rPedido { get; set; }

        public bool ePedido { get; set; }

        public bool cProdutos { get; set; }

        public bool eProdutos { get; set; }

        public bool cGrupo { get; set; }

        public bool eGrupo { get; set; }

        public bool relatorios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pessoa> pessoa { get; set; }
    }
}
