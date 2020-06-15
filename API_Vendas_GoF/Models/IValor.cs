using API_Vendas_GoF.Models.FormasDePagamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Vendas_GoF.Models
{
    public interface IValor
    {
        float GetPagar(ValorModel valorModel);
    }
}
