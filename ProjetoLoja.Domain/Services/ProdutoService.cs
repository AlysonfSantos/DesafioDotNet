using ProjetoLoja.Domain.Interfaces.Repositories;
using ProjetoLoja.Domain.Interfaces.Services;
using ProjetoLoja.Domain.Models;
using ProjetoLoja.Domain.Models.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoLoja.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Produto>> ListarProdutos()
        {
            return await _produtoRepository.ListarProdutos();
        }

        public async Task<Produto> ProdutoId(long id)
        {
          //  var produto = await _produtoRepository.Get(x => x.Id == id);
         //   return await _produtoRepository.ProdutoId(produto);
            return  await _produtoRepository.Get(x => x.Id == id);
        }

        public async Task<Produto> CadastrarProduto(Produto produto)
        {
            await _produtoRepository.CadastrarProduto(produto);
            await _produtoRepository.UnitOfWork.SaveChangesAsync();

            return produto;
        }

        public async Task<Produto> AtualizarProduto(AtualizarProdutoCommand command) 
        {
            var produto = await _produtoRepository.Get(x => x.Id == command.Id);
            if (produto == null) return null;

            produto.Atualizar(command.Nome, command.Marca, command.Valor, command.DataUpdate );
            await _produtoRepository.AtualizarProduto(produto);
            await _produtoRepository.UnitOfWork.SaveChangesAsync();
            return produto;
        }

        public async Task<bool> DeletarProduto(long id)
        {
            var produto = await _produtoRepository.Get(x => x.Id == id);
            if (produto == null) return false;

            await _produtoRepository.DeletarProduto(produto);
            await _produtoRepository.UnitOfWork.SaveChangesAsync();

            return true;
               
        }
    }
}