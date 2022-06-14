using Microsoft.AspNetCore.Mvc;
using ProjetoLoja.Application.Services.Interfaces;
using ProjetoLoja.Application.ViewModels;
using System.Threading.Tasks;

namespace ProjetoLoja.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;
        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarProdutos()
        {
            var produtos = await _produtoAppService.ListarProdutos();
            if (produtos == null) return NotFound("Nenhum produto encontrado");
            return Ok(produtos);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ProdutoId(long id)
        {
            var produtos = await _produtoAppService.ProdutoId(id);
            if (produtos == null) return NotFound("Nenhum produto encontrado");
     
            return Ok(produtos);
        }


        [HttpPost]
        public async Task<IActionResult> CadastrarProduto([FromBody] NovoProdutoViewModel vm)
        {
            var result = await _produtoAppService.CadastrarProduto(vm);
            if (result == null) return BadRequest("Não foi possível cadastrar o produto");
            return Ok(result);
        }

        [HttpPut]

        public async Task<IActionResult> AtualizarProduto([FromBody] AtualizarProdutoViewModel vm)
        {
            var result = await _produtoAppService.AtualizarProduto(vm);
            if (result == null) return BadRequest("Não foi possível Atualizar o produto");
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> DeletarProduto(long id)
        {
            var result = await _produtoAppService.DeletarProduto(id);
            if (!result) return BadRequest($"Não foi possível excluir produto {id}");
            if (result) return Ok();
            return NotFound();
        }

    }
}