using JWReport.Database;
using JWReport.Models;
using JWReport.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JWReport.Database
{
    public class BaseRepository<T> : IRepository<T> where T : IIdentifiable, new()
    {
        public static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<BaseRepository<T>> Instance = new AsyncLazy<BaseRepository<T>>(async () =>
        {
            var instance = new BaseRepository<T>();
            CreateTableResult result = await Database.CreateTableAsync<T>();
            return instance;
        });

        public BaseRepository()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<T>> GetAllAsync()
        {
            return Database.Table<T>().ToListAsync();
        }

        public Task<List<T>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<T>("SELECT * FROM [User] WHERE [Done] = 0");
        }

        public Task<T> GetAsync(int id)
        {
            return Database.Table<T>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveAsync(T item)
        {
            if (item.Id != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteAsync(T item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
