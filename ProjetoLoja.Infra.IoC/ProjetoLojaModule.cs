using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProjetoLoja.Application.Mapper;
using ProjetoLoja.Application.Services;
using ProjetoLoja.Application.Services.Interfaces;
using ProjetoLoja.Domain.Interfaces.Repositories;
using ProjetoLoja.Domain.Interfaces.Services;
using ProjetoLoja.Domain.Services;
using ProjetoLoja.Infra.Data.Repositories;

namespace ProjetoLoja.Infra.IoC
{
    public static class ProjetoLojaModule
    {
        private static void ConfigureMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainToViewModelProfile());
            });

            services.AddSingleton(mapperConfig.CreateMapper());
        }
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services.ConfigureMapper();

            return services;
        }

        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            return services;
        }
    }
}