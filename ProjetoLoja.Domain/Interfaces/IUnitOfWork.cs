﻿using System.Threading;
using System.Threading.Tasks;

namespace ProjetoLoja.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}