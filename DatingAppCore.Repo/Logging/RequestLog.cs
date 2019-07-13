using CommonCore.Repo.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCore.Repo.Logging
{
    public class RequestLog : EntityBase
    {
        public string Url { get; set; }
        public string Body { get; set; }
        public string Method { get; set; }
    }
}
