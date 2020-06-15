using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Vendas_GoF.Data;
using API_Vendas_GoF.Models;

namespace API_Vendas_GoF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly DataContext _context;

        public ProdutosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutosModel>>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        // GET: api/Produtos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutosModel>> GetProdutosModel(int id)
        {
            var produtosModel = await _context.Produtos.FindAsync(id);

            if (produtosModel == null)
            {
                return NotFound();
            }

            return produtosModel;
        }

        // PUT: api/Produtos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdutosModel(int id, ProdutosModel produtosModel)
        {
            if (id != produtosModel.IdProduto)
            {
                return BadRequest();
            }

            _context.Entry(produtosModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutosModelExists(id))
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

        // POST: api/Produtos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProdutosModel>> PostProdutosModel(ProdutosModel produtosModel)
        {
            _context.Produtos.Add(produtosModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdutosModel", new { id = produtosModel.IdProduto }, produtosModel);
        }

        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutosModel>> DeleteProdutosModel(int id)
        {
            var produtosModel = await _context.Produtos.FindAsync(id);
            if (produtosModel == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produtosModel);
            await _context.SaveChangesAsync();

            return produtosModel;
        }

        private bool ProdutosModelExists(int id)
        {
            return _context.Produtos.Any(e => e.IdProduto == id);
        }
    }
}
