using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Core
{
    static class ItensDAL
    {
        public static List<CategoriaDTO> pegaTodasCategorias()
        {
            using (var db = new ModelContext())
            {
                var query = from cat in db.categoria
                            select new CategoriaDTO{ idCategoria = cat.idCategoria, descricao = cat.descricao };

                var result = query.ToList();
                return result;
            }
        }
    }
}
