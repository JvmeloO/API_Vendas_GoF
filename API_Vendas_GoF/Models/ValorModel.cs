using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Vendas_GoF.Models.FormasDePagamentos
{
    public class ValorModel
    {
        public string Ds { get; set; }
        public float valor { get; set; }

        public float desconto { get; set; }
        public EnumFormasPagamento FormaDePagamento { get; set; }
    }
}
