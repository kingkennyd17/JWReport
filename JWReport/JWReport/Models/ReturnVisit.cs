using JWReport.Database;
using JWReport.Models.Enum;
using SQLite;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace JWReport.Models
{
    public class ReturnVisit : BaseModel, IIdentifiable
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string NextQuestion { get; set; }
        public string ReturnType { get; set; }
        public bool Upgraded { get; set; }
        public DateTime? NextMeeting { get; set; }
        public Color StartColor
        {
            get
            {
                if (Id % 2 == 0)
                    return Color.Silver;
                  else
                    return Color.White;
            }
        }
        public Color EndColor
        {
            get
            {
                if (Id % 2 == 0)
                    return Color.White;
                else
                    return Color.Silver;
            }
        }
    }
}
