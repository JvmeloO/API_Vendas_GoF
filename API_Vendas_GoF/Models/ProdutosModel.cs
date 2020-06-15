using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Vendas_GoF.Models
{
    public class ProdutosModel
    {
        [Key]
        public int IdProduto { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public float Preco { get; set; }

        [Required]
        public int IdCliente { get; set; }

        public virtual ClientesModel Cliente { get; set; }
    }
}
