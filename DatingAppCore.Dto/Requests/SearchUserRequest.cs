using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatingAppCore.Dto.Requests
{
    public class KVP
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class SearchUserRequest : FindMatchRequest
    {
        public List<KVP> Filter { get; set; } = new List<KVP>();

        public string QueryString => Filter
            .Select(x => $"{x.Key}={x.Value}")
            .Aggregate((x, y) => $"{x},{y}")
            .Trim(' ', ',');
    }
}
