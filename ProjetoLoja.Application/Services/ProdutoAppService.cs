using AutoMapper;
using ProjetoLoja.Application.Services.Interfaces;
using ProjetoLoja.Application.ViewModels;
using ProjetoLoja.Domain.Interfaces.Services;
using ProjetoLoja.Domain.Models;
using ProjetoLoja.Domain.Models.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoLoja.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;
        public ProdutoAppService(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoViewModel>> ListarProdutos()
        {
            var produtos = await _produtoService.ListarProdutos();
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(produtos);
        }

        public async Task<ProdutoViewModel> ProdutoId(long id)
        {
            var produtos = await _produtoService.ProdutoId(id);
            return _mapper.Map<ProdutoViewModel>(produtos);
        }

        public async Task<ProdutoViewModel> CadastrarProduto(NovoProdutoViewModel novoProdutoViewModel)
        {
            var novoProduto = new Produto(novoProdutoViewModel.Nome,
                novoProdutoViewModel.Marca,
                novoProdutoViewModel.Valor,
                novoProdutoViewModel.DataCriacao);

            var produtoCadastrado = await _produtoService.CadastrarProduto(novoProduto);

            return _mapper.Map<ProdutoViewModel>(produtoCadastrado);
        }

        public async Task<ProdutoViewModel> AtualizarProduto(AtualizarProdutoViewModel atualizarProdutoViewModel) 
        {
            var command = new AtualizarProdutoCommand
            {
                Id = atualizarProdutoViewModel.Id,
                DataUpdate = atualizarProdutoViewModel.DataUpdate,
                Nome =  atualizarProdutoViewModel.Nome,
                Marca = atualizarProdutoViewModel.Marca,
                Valor = atualizarProdutoViewModel.Valor

            };
            var produtoAtualizado = await _produtoService.AtualizarProduto(command);
            return _mapper.Map<ProdutoViewModel>(produtoAtualizado);
        }

        public async Task<bool> DeletarProduto(long id) 
        {
            return await _produtoService.DeletarProduto(id);
        }


    }
}