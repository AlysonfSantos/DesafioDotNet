using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ProjetoLoja.Infra.Data.EF.Extensions
{
    public static class EntityFrameworkExtensions
    {
        public static IServiceCollection AddEFConfiguration(this IServiceCollection services,
            string connectionString)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ProdutoLojaContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                },
                ServiceLifetime.Scoped);

            return services;
        }
    }
}