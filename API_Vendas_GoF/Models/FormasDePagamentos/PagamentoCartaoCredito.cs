using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Vendas_GoF.Models.FormasDePagamentos
{
    public class PagamentoCartaoCredito : IFormasDePagamentos
    {
        public EnumFormasPagamento formaDePagamento => EnumFormasPagamento.PagamentoCartaoCredito;

        public float GetPagar(ValorModel valorModel) => ((valorModel.valor * 15)/100);
    }
}
