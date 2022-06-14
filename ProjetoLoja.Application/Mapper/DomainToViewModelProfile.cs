using AutoMapper;
using ProjetoLoja.Application.ViewModels;
using ProjetoLoja.Domain.Models;

namespace ProjetoLoja.Application.Mapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Produto, ProdutoViewModel>();
        }
    }
}