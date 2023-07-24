using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JWReport.Database
{
    public interface IIdentifiable
    {
        int Id { get; set; }
    }
    public interface IRepository<T> where T : IIdentifiable
    {
        Task<T> GetAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<int> SaveAsync(T item);
        Task<int> DeleteAsync(T item);
    }
}
