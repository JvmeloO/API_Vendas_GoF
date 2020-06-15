using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Vendas_GoF.Models
{
    public class ClientesModel
    {
        [Key]
        public int IdCliente { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        public virtual ICollection<ProdutosModel> Produtos { get; set; }
    }
}
