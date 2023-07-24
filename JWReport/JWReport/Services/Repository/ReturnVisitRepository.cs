using JWReport.Database;
using JWReport.Models;
using JWReport.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JWReport.Services.Repository
{
    public class ReturnVisitRepository : BaseRepository<ReturnVisit>, IReturnVisitRepository
    {
        public Task<List<ReturnVisit>> GetReturnVisitAsync()
        {
            return Database.Table<ReturnVisit>().Where(i => i.Upgraded == false).ToListAsync();
        }
    }
}
