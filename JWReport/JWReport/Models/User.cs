using JWReport.Database;
using JWReport.Models.Enum;
using JWReport.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWReport.Models
{
    public class User : BaseModel, IIdentifiable
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? BaptismDate { get; set; }
        public string Congregation { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public PrivilegeOfService Privilege { get; set; }
    }
}
