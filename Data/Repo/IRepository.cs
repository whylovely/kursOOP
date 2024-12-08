using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace kursOOP.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id); // Получить объект по ID
        Task<IEnumerable<T>> GetAllAsync(); // Получить все объекты
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate); // Найти объекты по условию
        Task AddAsync(T entity); // Добавить объект
        Task UpdateAsync(T entity); // Обновить объект
        Task DeleteAsync(int id); // Удалить объект по ID
    }
}
