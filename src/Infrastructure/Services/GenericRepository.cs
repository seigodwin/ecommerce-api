using Application.Common.Interfaces;
using Application.Common.Specifications;
using Infrastructure.Data.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{
    public sealed class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<T?> FirstOrDefaultAsync(BaseSpecification<T> spec, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _dbSet.FindAsync(id, ct);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public Task<IEnumerable<T>> GetListAsync(BaseSpecification<T> spec, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync(CancellationToken ct = default)
        {
            await _context.SaveChangesAsync(ct);
        }

     
    }
}
