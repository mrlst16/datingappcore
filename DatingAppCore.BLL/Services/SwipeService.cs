﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Adapters;
using DatingAppCore.BLL.Helpers.RepoHelpers;
using DatingAppCore.DTO.Matching;
using DatingAppCore.Interfaces;
using DatingAppCore.Repo.Matching;

namespace DatingAppCore.BLL.Services
{
    public class SwipeService : ISwipeService
    {
        public  async Task<Response<bool>> Swipe(SwipeDTO request)
        {
            return Response<bool>.Wrap(() => RepoCache.Get<Swipe>().AddSwipe(request));
        }
    }
}