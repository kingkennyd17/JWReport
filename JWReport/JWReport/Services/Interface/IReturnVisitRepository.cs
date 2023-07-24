using JWReport.Database;
using JWReport.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JWReport.Services.Interface
{
    public interface IReturnVisitRepository : IRepository<ReturnVisit>
    {
        Task<List<ReturnVisit>> GetReturnVisitAsync();
    }
}
