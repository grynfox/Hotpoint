using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Core
{
    class PedidoDAL
    {
        private ModelContext db;
        public PedidoDAL(ModelContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Persiste um pedido a um pedido mesa
        /// </summary>
        /// <param name="pm"> o pedido mesa</param>
        /// <param name="idItem"> o id do item a inserir</param>
        /// <param name="quantidade">quantidade</param>
        /// <param name="observacao">Obs, não obrigatorio</param>
        /// <returns></returns>
        public bool inserePedidoItem(pedidomesa pm, int idItem, float quantidade, string observacao = null)
        {

            var itemPedido = db.itenspedido.Add(new itenspedido { pedidomesa = pm, idItem = idItem, quantidade = quantidade, observacao = observacao });
            db.Entry(pm).State = EntityState.Unchanged;
            db.SaveChanges();
            return true;

        }
    }
}
