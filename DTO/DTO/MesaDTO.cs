using System.Collections.Generic;

namespace DTO
{
    public class MesaDTO
    {
        public int idMesa { get; set; }
        public bool isMesaVaga { get; set; }
        public IEnumerable<MesatempedidoDTO> mesatempedido { get; set; }
        public string nomeMesa { get; set; }
        public IEnumerable<PedidomesaDTO> pedidomesa { get; set; }
    }
}
