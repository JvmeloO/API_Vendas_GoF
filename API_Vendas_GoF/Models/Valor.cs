using API_Vendas_GoF.Models.FormasDePagamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Vendas_GoF.Models
{
    public class Valor : IValor
    {
        private readonly IEnumerable<IFormasDePagamentos> _formasDePagamento;

        public Valor(IEnumerable<IFormasDePagamentos> formasDePagamento)
        {
            _formasDePagamento = formasDePagamento;
        }

        public float GetPagar(ValorModel valorModel)
        {
            var forma = _formasDePagamento.FirstOrDefault(x => x.formaDePagamento == valorModel.FormaDePagamento);
            var valor = forma.GetPagar(valorModel);

            return valor;
        }

    }
}
