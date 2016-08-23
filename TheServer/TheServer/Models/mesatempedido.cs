namespace TheServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("banco_bar.mesatempedido")]
    public partial class mesatempedido
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idMesa { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idPedidoMesa { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(15)]
        public string senhaPedido { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool requisitadoFechamento { get; set; }

        public virtual mesa mesa { get; set; }

        public virtual pedidomesa pedidomesa { get; set; }
    }
}
