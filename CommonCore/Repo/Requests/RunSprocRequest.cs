using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCore.Repo.Requests
{
    public class RunSprocRequest
    {
        public Type ContextType {get; set;}
        public string SprocName { get; set; }
        public IDictionary<string, string> Parameters { get; set; }
    }
}
