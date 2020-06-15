using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Vendas_GoF.Models.FormasDePagamentos
{
    public interface IFormasDePagamentos
    {
        EnumFormasPagamento formaDePagamento { get; }
        public float GetPagar(ValorModel valorModel);
    }
}
