﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Responses;
using DatingAppCore.DTO.Matching;

namespace DatingAppCore.Interfaces
{
    public interface ISwipeService
    {
        Task<Response<bool>> Swipe(SwipeDTO request);
    }
}