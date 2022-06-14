using Microsoft.EntityFrameworkCore;
using ProjetoLoja.Domain.Interfaces;
using ProjetoLoja.Domain.Interfaces.Repositories;
using ProjetoLoja.Infra.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjetoLoja.Infra.Data.Repositories.Abstract
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
      where T : class
    {
        protected readonly ProdutoLojaContext _context;
        public BaseRepository(ProdutoLojaContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
    }
}