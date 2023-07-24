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
        Task<DailyReport> GetReportbyDateAsync(DateTime date);
        Task<int> IncrementPlacement();
        Task<int> DecrementPlacement();
        Task<int> IncrementVideo();
        Task<int> DecrementVideo();
        Task<int> IncrementHour();
        Task<int> DecrementHour();
        Task<int> IncrementReturnVisit();
        Task<int> DecrementReturnVisit();
        Task<int> IncrementBibleStudy();
        Task<int> DecrementBibleStudy();

        Task<int> IncrementBoth();
    }
}
