using CommonCore.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Repo.Logging
{
    public class TraceLog : EntityBase
    {
        public string Exception { get; set; }
        public string StackTrace { get; set; }
        public string Message { get; set; }
        public int Level { get; set; }
    }
}
