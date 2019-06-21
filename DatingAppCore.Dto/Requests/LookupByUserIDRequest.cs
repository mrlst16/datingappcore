﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCore.Dto.Requests
{
    public class LookupByUserIDRequest : PaginatedRequest
    {
        public Guid UserID { get; set; }
    }
}
