﻿using JWReport.Database;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWReport.Models
{
    public class GroupOverseer : BaseModel, IIdentifiable
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
