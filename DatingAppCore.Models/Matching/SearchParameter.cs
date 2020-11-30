using CommonCore.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCore.Entities.Matching
{
    public abstract class SearchParameter
    {
        public string Type { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public ComparisonOperatorEnum Operator { get; set; }

        public abstract bool Match(SearchParameter other);
    }
}
