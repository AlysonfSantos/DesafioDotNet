using ProjetoLoja.Domain.Models;
using ProjetoLoja.Domain.Models.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoLoja.Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> ListarProdutos();
        Task<Produto> ProdutoId(long id);
        Task<Produto> CadastrarProduto(Produto produto);
        Task<Produto> AtualizarProduto(AtualizarProdutoCommand command);
        Task<bool> DeletarProduto(long id);
    }
}