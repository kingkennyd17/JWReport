using System;
using System.Collections.Generic;
using System.Text;

namespace JWReport.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            Active = true;
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
