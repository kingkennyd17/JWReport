using JWReport.Database;
using SQLite;
using System;

namespace JWReport.Models
{
    public class DailyReport : BaseModel, IIdentifiable
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public int? Placement { get; set; }
        public int? Video { get; set; }
        public int? HourAuto
        {
            get => (EndTime.Value - StartTime.Value).Hours;
        }
        public int? Hour { get; set; }
        public TimeSpan? Time
        {
            get => EndTime - StartTime;
        }
        //public double Minute
        //{
        //    get => ((EndTime - StartTime).TotalHours - (double)(EndTime - StartTime).Hours) * 60;
        //}
        public int? ReturnVisit { get; set; }
        public int? BibleStudy { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime Date { get; set; }
        public bool OnField { get; set; }
        public string Month 
        { 
            get => Date.ToString("MMMM");
        }
    }
}
