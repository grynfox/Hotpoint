using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Core
{
    class ItensDAL
    {
        private ModelContext db;
        public ItensDAL(ModelContext db)
        {
            this.db = db;
        }


        public List<CategoriaDTO> pegaTodasCategorias()
        {
            var query = from cat in db.categoria
                        select new CategoriaDTO { idCategoria = cat.idCategoria, descricao = cat.descricao };

            var result = query.ToList();
            return result;

        }

        public List<ItensDTO> pegaItens(int? idCategoria)
        {

            var query = from itns in db.itens.Include(i => i.categoria)
                        select new ItensDTO
                        {
                            categoria = new CategoriaDTO
                            {
                                descricao = itns.categoria.descricao,
                                idCategoria = itns.categoria.idCategoria
                            },
                            idItem = itns.idItem,
                            informacao = itns.informacao,
                            nome = itns.nome,
                            nomeImagem = itns.nomeImagem,
                            valor = itns.valor

                        };

            if (idCategoria != null)
            {
                query = query.Where((i) => i.categoria.idCategoria == idCategoria);
            }

            var result = query.ToList();
            return result;

        }
    }
}
