using JWReport.Database;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWReport.Models
{
    public class MonthlyReport : BaseModel, IIdentifiable
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public int Placement { get; set; }
        public int Video { get; set; }
        public int Hour { get; set; }
        public TimeSpan ExtraMinute { get; set; }
        public TimeSpan Time { get; set; }
        public int ReturnVisit { get; set; }
        public int BibleStudy { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
    }
}
