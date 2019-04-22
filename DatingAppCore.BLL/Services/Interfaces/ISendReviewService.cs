﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Responses;
using DatingAppCore.DTO.Reviewing;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface ISendReviewService
    {
        Response<bool> Send(ReviewDTO request);
    }
}