using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Vendas_GoF.Data;
using API_Vendas_GoF.Models;
using System.Security.Cryptography.X509Certificates;
using API_Vendas_GoF.Models.FormasDePagamentos;

namespace API_Vendas_GoF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IValor _valor;

        public ClientesController(DataContext context, IValor valor)
        {
            _context = context;
            _valor = valor;
        }

        [HttpGet("{id}/pagar")]
        public JsonResult GetPagar(int id)
        { 
            List<ProdutosModel> produtosModel =  _context.Produtos
                .Include(i => i.Cliente)
                .Where(i => i.IdCliente == id).ToList();

            int index = 0;
            float valor = 0;

            foreach (int number in Iterator(produtosModel.Count()))
            {
                valor += produtosModel[number].Preco;
            }

            List<ValorModel> precos = new List<ValorModel>();

            ValorModel precoBoleto = new ValorModel();
            precoBoleto.Ds = "Pagamento por Boleto";
            precoBoleto.FormaDePagamento = EnumFormasPagamento.PagamentoBoleto;
            precoBoleto.valor = valor;
            precoBoleto.desconto = _valor.GetPagar(precoBoleto);
            precoBoleto.valor = valor - precoBoleto.desconto;
            precos.Add(precoBoleto);

            ValorModel precoCartaoCredito = new ValorModel();
            precoCartaoCredito.Ds = "Pagamento por Cartao de Credito";
            precoCartaoCredito.FormaDePagamento = EnumFormasPagamento.PagamentoCartaoCredito;
            precoCartaoCredito.valor = valor;
            precoCartaoCredito.desconto = _valor.GetPagar(precoCartaoCredito);
            precoCartaoCredito.valor = valor - precoCartaoCredito.desconto;
            precos.Add(precoCartaoCredito);

            return new JsonResult(precos);
        }

        public static IEnumerable<int> Iterator(int tamanho)
        {
            int number = 0;
            while (number < tamanho)
            {
                yield return number++;
            }
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientesModel>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientesModel>> GetClientesModel(int id)
        {
            var clientesModel = await _context.Clientes.FindAsync(id);

            if (clientesModel == null)
            {
                return NotFound();
            }

            return clientesModel;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientesModel(int id, ClientesModel clientesModel)
        {
            if (id != clientesModel.IdCliente)
            {
                return BadRequest();
            }

            _context.Entry(clientesModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientesModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClientesModel>> PostClientesModel(ClientesModel clientesModel)
        {
            _context.Clientes.Add(clientesModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientesModel", new { id = clientesModel.IdCliente }, clientesModel);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientesModel>> DeleteClientesModel(int id)
        {
            var clientesModel = await _context.Clientes.FindAsync(id);
            if (clientesModel == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(clientesModel);
            await _context.SaveChangesAsync();

            return clientesModel;
        }

        private bool ClientesModelExists(int id)
        {
            return _context.Clientes.Any(e => e.IdCliente == id);
        }
    }
}
