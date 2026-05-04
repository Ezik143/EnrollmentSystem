using EnrollmentManagementSystemAPI.Repositories;
using EnrollmentManagementSystemAPI.Services.Interfaces;
using System.Linq.Expressions;

namespace EnrollmentManagementSystemAPI.Services.Implementations
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public Task AddAsync(T entity)
        {
            return _repository.AddAsync(entity);
        }

        public Task DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<bool> ExistsAsync(int id)
        {
            return _repository.ExistsAsync(id);
        }

        public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return _repository.FindAsync(predicate);
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<T?> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task UpdateAsync(T entity)
        {
            return _repository.UpdateAsync(entity);
        }
    }
}
