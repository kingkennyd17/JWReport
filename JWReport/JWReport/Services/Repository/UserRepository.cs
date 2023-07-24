using JWReport.Database;
using JWReport.Models;
using JWReport.Services.Interface;
using System.Threading.Tasks;

namespace JWReport.Services.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public Task<int> SaveUserInfoAsync(User item)
        {
            var user = Database.Table<User>().Where(i => i.Id == 1).FirstOrDefaultAsync();
            if (user.Result != null)
            {
                item.Id = user.Result.Id;
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }
    }
}
