using CommonCore.Repo.Entities;

namespace DatingAppCore.Entities.Logging
{
    public class RequestLog : EntityBase
    {
        public string Url { get; set; }
        public string Body { get; set; }
        public string Method { get; set; }
    }
}
