using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatingAppCore.Dto.Requests
{
    public class SearchUserRequest : FindMatchRequest
    {
        public Dictionary<string, string> Filter { get; set; } = new Dictionary<string, string>();

        public string QueryString => Filter
            .Select(x => $"{x.Key}={x.Value}")
            .Aggregate((x, y) => $"{x},{y}");
    }
}
