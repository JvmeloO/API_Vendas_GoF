using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Vendas_GoF.Models.FormasDePagamentos
{
    public class PagamentoBoleto : IFormasDePagamentos
    {
        public EnumFormasPagamento formaDePagamento => EnumFormasPagamento.PagamentoBoleto;

        public float GetPagar(ValorModel valorModel) => ((valorModel.valor * 5)/100);
    }
}
