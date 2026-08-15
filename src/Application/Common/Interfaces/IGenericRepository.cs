using System;

namespace Application.Common.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id , CancellationToken ct = default);
        Task<T?> FirstOrDefaultAsync(CancellationToken ct = default);
        Task<IEnumerable<T>> GetListAsync(CancellationToken ct = default);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);

        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
