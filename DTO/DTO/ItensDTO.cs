using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ItensDTO
    {
        public int idItem { get; set; }

        public string nome { get; set; }

        public string nomeImagem { get; set; }

        public string informacao { get; set; }

        public float valor { get; set; }

        public int idCategoria { get; set; }

        public virtual CategoriaDTO categoria { get; set; }

        //public virtual ICollection<itenspedido> itenspedido { get; set; }
    }
}
