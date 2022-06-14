using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ProjetoLoja.Domain.Interfaces;
using ProjetoLoja.Domain.Models;
using ProjetoLoja.Infra.Data.EF.Maps;

namespace ProjetoLoja.Infra.Data.EF
{
    public class ProdutoLojaContext : DbContext, IUnitOfWork
    {
        public ProdutoLojaContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
            CriarBancoCasoNaoExista();
        }

        private void CriarBancoCasoNaoExista()
        {
            if (!(Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMapping());
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}