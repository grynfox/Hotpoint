using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheServer.Attributes;
using TheServer.Models;

namespace TheServer.DAL
{
    public class MesaDAL: IDisposable
    {
        public void Dispose()
        {
            
        }

        public List<MesaDTO> listaMesas()
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
                                    senhaPedido = mtp.senhaPedido

                                }).ToList(),
                                nomeMesa = mesa.nomeMesa,
                                pedidomesa = mesa.pedidomesa.Select(pm => new PedidomesaDTO
                                {
                                    dataAbertura = pm.dataAbertura,
                                    dataFechamento = pm.dataFechamento,
                                    idPedidoMesa = pm.idPedidoMesa,

                                }).ToList()
                            };

                var result = query.ToList();
                return result;                
            }
        }
    }
}