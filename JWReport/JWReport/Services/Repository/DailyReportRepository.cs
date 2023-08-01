using JWReport.Database;
using JWReport.Models;
using JWReport.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JWReport.Services.Repository
{
    public class DailyReportRepository : BaseRepository<DailyReport>, IDailyReportRepository
    {
        public Task<DailyReport> GetReportbyDateAsync(DateTime date)
        {
            return Database.Table<DailyReport>().Where(i => i.Date == date.Date).FirstOrDefaultAsync();
        }

        public Task<List<DailyReport>> GetAllDailyReportforMonthAsync(string month)
        {
            return Database.Table<DailyReport>().Where(i => i.Month == month).ToListAsync();
        }
        //Placement
        public Task<int> IncrementPlacement()
        {
            var todayReport = Database.Table<DailyReport>().Where(i => i.Date == DateTime.Today).FirstOrDefaultAsync();
            if(todayReport.Result != null)
            {
                todayReport.Result.Placement++;

                return Database.UpdateAsync(todayReport.Result);
            }
            else
            {
                DailyReport dailyReport = new DailyReport();
                dailyReport.Date = DateTime.Today;
                dailyReport.Placement = 1;
                dailyReport.Month = DateTime.Now.ToString("MMMM");
                dailyReport.Year = DateTime.Now.Year;

                return Database.InsertAsync(dailyReport);
            }
        }

        public Task<int> SaveEditAsync(DailyReport item)
        {
            var todayReport = Database.Table<DailyReport>().Where(i => i.Date == item.Date.Date).FirstOrDefaultAsync();
            if (todayReport.Result != null)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> SaveStartAsync()
        {
            var todayReport = Database.Table<DailyReport>().Where(i => i.Date == DateTime.Today).FirstOrDefaultAsync();
            if (todayReport.Result != null)
            {
                todayReport.Result.StartTime = DateTime.Now;
                todayReport.Result.OnField = true;
                return Database.UpdateAsync(todayReport.Result);
            }
            else
            {
                DailyReport item = new DailyReport();
                item.StartTime = DateTime.Now;
                item.Date = DateTime.Today;
                item.Month = DateTime.Now.ToString("MMMM");
                item.Year = DateTime.Now.Year;
                item.OnField = true;
                return Database.InsertAsync(item);
            }
        }

        public Task<int> SaveEndAsync()
        {
            var todayReport = Database.Table<DailyReport>().Where(i => i.Date == DateTime.Today).FirstOrDefaultAsync();
            //if (todayReport.Result != null)
            //{
            todayReport.Result.EndTime = DateTime.Now;
            todayReport.Result.TimeAuto += (DateTime.Now - todayReport.Result.StartTime);
            todayReport.Result.OnField = false;
            return Database.UpdateAsync(todayReport.Result);
            //}
        }

        public Task<int> DecrementPlacement()
        {
            var todayReport = Database.Table<DailyReport>().Where(i => i.Date == DateTime.Today).FirstOrDefaultAsync();
            if (todayReport.Result != null)
            {
                if (todayReport.Result.Placement > 0)
                {
                    todayReport.Result.Placement--;

                    return Database.UpdateAsync(todayReport.Result);
                }
            }
            return null;
        }

        //Video
        public Task<int> IncrementVideo()
        {
            var todayReport = Database.Table<DailyReport>().Where(i => i.Date == DateTime.Today).FirstOrDefaultAsync();
            if (todayReport.Result != null)
            {
                todayReport.Result.Video++;

                return Database.UpdateAsync(todayReport.Result);
            }
            else
            {
                DailyReport dailyReport = new DailyReport();
                dailyReport.Date = DateTime.Today;
                dailyReport.Video = 1;
                dailyReport.Month = DateTime.Now.ToString("MMMM");
                dailyReport.Year = DateTime.Now.Year;

                return Database.InsertAsync(dailyReport);
            }
        }

        public Task<int> DecrementVideo()
        {
            var todayReport = Database.Table<DailyReport>().Where(i => i.Date == DateTime.Today).FirstOrDefaultAsync();
            if (todayReport.Result != null)
            {
                if (todayReport.Result.Video > 0)
                {
                    todayReport.Result.Video--;

                    return Database.UpdateAsync(todayReport.Result);
                }
            }
            return null;
        }

        public Task<int> IncrementReturnVisit()
        {
            var todayReport = Database.Table<DailyReport>().Where(i => i.Date == DateTime.Today).FirstOrDefaultAsync();
            if (todayReport.Result != null)
            {
                todayReport.Result.ReturnVisit++;

                return Database.UpdateAsync(todayReport.Result);
            }
            else
            {
                DailyReport dailyReport = new DailyReport();
                dailyReport.Date = DateTime.Today;
                dailyReport.ReturnVisit = 1;
                dailyReport.Month = DateTime.Now.ToString("MMMM");
                dailyReport.Year = DateTime.Now.Year;

                return Database.InsertAsync(dailyReport);
            }
        }

        public Task<int> DecrementReturnVisit()
        {
            var todayReport = Database.Table<DailyReport>().Where(i => i.Date == DateTime.Today).FirstOrDefaultAsync();
            if (todayReport.Result != null)
            {
                if (todayReport.Result.ReturnVisit > 0)
                {
                    todayReport.Result.ReturnVisit--;

                    return Database.UpdateAsync(todayReport.Result);
                }
            }
            return null;
        }

        //Both Video and Placement
        public Task<int> IncrementBoth()
        {
            var todayReport = Database.Table<DailyReport>().Where(i => i.Date == DateTime.Today).FirstOrDefaultAsync();
            if (todayReport.Result != null)
            {
                todayReport.Result.Video++;
                todayReport.Result.Placement++;

                return Database.UpdateAsync(todayReport.Result);
            }
            else
            {
                DailyReport dailyReport = new DailyReport();
                dailyReport.Date = DateTime.Today;
                dailyReport.Placement = 1;
                dailyReport.Video = 1;
                dailyReport.Month = DateTime.Now.ToString("MMMM");
                dailyReport.Year = DateTime.Now.Year;

                return Database.InsertAsync(dailyReport);
            }
        }
    }
}
