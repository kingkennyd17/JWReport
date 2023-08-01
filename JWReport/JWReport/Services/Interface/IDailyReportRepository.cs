using JWReport.Database;
using JWReport.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JWReport.Services.Interface
{
    public interface IDailyReportRepository : IRepository<DailyReport>
    {
        Task<List<DailyReport>> GetAllDailyReportforMonthAsync(string month);
        Task<DailyReport> GetReportbyDateAsync(DateTime date);
        Task<int> SaveEditAsync(DailyReport item);
        Task<int> SaveStartAsync();
        Task<int> SaveEndAsync();
        Task<int> IncrementPlacement();
        Task<int> DecrementPlacement();
        Task<int> IncrementVideo();
        Task<int> DecrementVideo();
        Task<int> IncrementReturnVisit();
        Task<int> DecrementReturnVisit();

        Task<int> IncrementBoth();
    }
}
