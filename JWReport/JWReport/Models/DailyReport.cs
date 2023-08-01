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
        public int Placement { get; set; }
        public int Video { get; set; }
        public int Hours
        {
            get => (Time + TimeAuto).Hours;
        }
        public double TotalHours
        {
            get => (Time + TimeAuto).TotalHours;
        }
        public TimeSpan TimeAuto { get; set; }
        public TimeSpan Time { get; set; }
        public int ReturnVisit { get; set; }
        public int BibleStudy { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }
        public bool OnField { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
    }
}
