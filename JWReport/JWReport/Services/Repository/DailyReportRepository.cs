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
                dailyReport.Video = 0;
                dailyReport.BibleStudy = 0;
                dailyReport.ReturnVisit = 0;
                dailyReport.Hour = 0;

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
                dailyReport.Placement = 0;
                dailyReport.Video = 1;
                dailyReport.BibleStudy = 0;
                dailyReport.ReturnVisit = 0;
                dailyReport.Hour = 0;

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

        public Task<int> IncrementHour()
        {
            var todayReport = Database.Table<DailyReport>().Where(i => i.Date == DateTime.Today).FirstOrDefaultAsync();
            if (todayReport.Result != null)
            {
                todayReport.Result.Hour++;

                return Database.UpdateAsync(todayReport.Result);
            }
            else
            {
                DailyReport dailyReport = new DailyReport();
                dailyReport.Date = DateTime.Today;
                dailyReport.Placement = 0;
                dailyReport.Video = 0;
                dailyReport.BibleStudy = 0;
                dailyReport.ReturnVisit = 0;
                dailyReport.Hour = 1;

                return Database.InsertAsync(dailyReport);
            }
        }

        public Task<int> DecrementHour()
        {
            var todayReport = Database.Table<DailyReport>().Where(i => i.Date == DateTime.Today).FirstOrDefaultAsync();
            if (todayReport.Result != null)
            {
                if (todayReport.Result.Hour > 0)
                {
                    todayReport.Result.Hour--;

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
                dailyReport.Placement = 0;
                dailyReport.Video = 0;
                dailyReport.BibleStudy = 0;
                dailyReport.ReturnVisit = 1;
                dailyReport.Hour = 0;

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

        public Task<int> IncrementBibleStudy()
        {
            var todayReport = Database.Table<DailyReport>().Where(i => i.Date == DateTime.Today).FirstOrDefaultAsync();
            if (todayReport.Result != null)
            {
                todayReport.Result.BibleStudy++;

                return Database.UpdateAsync(todayReport.Result);
            }
            else
            {
                DailyReport dailyReport = new DailyReport();
                dailyReport.Date = DateTime.Today;
                dailyReport.Placement = 0;
                dailyReport.Video = 0;
                dailyReport.BibleStudy = 1;
                dailyReport.ReturnVisit = 0;
                dailyReport.Hour = 0;

                return Database.InsertAsync(dailyReport);
            }
        }

        public Task<int> DecrementBibleStudy()
        {
            var todayReport = Database.Table<DailyReport>().Where(i => i.Date == DateTime.Today).FirstOrDefaultAsync();
            if (todayReport.Result != null)
            {
                if (todayReport.Result.BibleStudy > 0)
                {
                    todayReport.Result.BibleStudy--;

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
                dailyReport.BibleStudy = 0;
                dailyReport.ReturnVisit = 0;
                dailyReport.Hour = 0;

                return Database.InsertAsync(dailyReport);
            }
        }
    }
}
