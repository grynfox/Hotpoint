using DAL.Models;
using DTO;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using System;

[assembly: InternalsVisibleTo("TheServer")]
namespace DAL.Core
{
    static class MesaDAL
    {

        internal static pedidomesa InserePedidoEmMesa(mesa mesa, string senha)
        {
            try
            {
                using (var db = new ModelContext())
                {
                    pedidomesa pm = db.pedidomesa.Add(new pedidomesa { idMesa = mesa.idMesa });

                    mesatempedido mtp = db.mesatempedido.Add(new mesatempedido { mesa = mesa, pedidomesa = pm, senhaPedido = senha });
                    db.Entry(mesa).State = EntityState.Unchanged;
                    db.Entry(pm).State = EntityState.Added;
                    db.SaveChanges();
                    return pm;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Retorna uma mesa com suas informaçoes, se existir
        /// </summary>
        /// <param name="mesaId"></param>
        /// <returns></returns>
        public static mesa PegaMesaPorId(int mesaId)
        {
            using (var db = new ModelContext())
            {
                var query = from mesa in db.mesa.Include(m => m.pedidomesa).Include(m => m.mesatempedido)
                            where mesa.idMesa == mesaId
                            select mesa;

                var result = query.FirstOrDefault();
                return result;
            }
        }


        /// <summary>
        /// Retorna uma lista das mesas leftJoin pedidoMesa e mesaTemPedido em DTO
        /// </summary>
        /// <returns></returns>
        public static List<MesaDTO> listaMesas(string nomeMesa = null)
        {
            using (var db = new ModelContext())
            {
                var query = from mesa in db.mesa.Include(m => m.pedidomesa).Include(m => m.mesatempedido)
                            select new MesaDTO
                            {
                                idMesa = mesa.idMesa,
                                isMesaVaga = mesa.isMesaVaga,
                                mesatempedido = mesa.mesatempedido.Select(mtp => new MesatempedidoDTO
                                {
                                    requisitadoFechamento = mtp.requisitadoFechamento,
                                    //senhaPedido = mtp.senhaPedido

                                }).ToList(),
                                nomeMesa = mesa.nomeMesa,
                                pedidomesa = mesa.pedidomesa.Select(pm => new PedidomesaDTO
                                {
                                    dataAbertura = pm.dataAbertura,
                                    dataFechamento = pm.dataFechamento,
                                    idPedidoMesa = pm.idPedidoMesa,

                                }).ToList()
                            };

                if (!string.IsNullOrEmpty(nomeMesa))
                {
                    query = query.Where(m => m.nomeMesa == nomeMesa);
                }

                var result = query.ToList();
                return result;
            }
        }

    }
}
