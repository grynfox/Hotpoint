namespace TheServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("banco_bar.itenspedido")]
    public partial class itenspedido
    {
        [Key]
        public int iditensPedido { get; set; }

        public int idPedidoMesa { get; set; }

        public int idItem { get; set; }

        public DateTime dataPedido { get; set; }

        public float quantidade { get; set; }

        public float valorTotal { get; set; }

        [StringLength(400)]
        public string observacao { get; set; }

        public int? progresso { get; set; }

        public virtual itens itens { get; set; }

        public virtual pedidomesa pedidomesa { get; set; }
    }
}
