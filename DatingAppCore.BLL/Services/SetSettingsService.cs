﻿using CommonCore.Comparers;
using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Helpers.RepoHelpers;
using DatingAppCore.BLL.Requests;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Repo.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services
{
    public class SetSettingsService : ISetSettingsService
    {
        public async Task<Response<bool>> Set(SetPropertiesRequest request)
        {
            return Response<bool>.Wrap(() => RepoCache.Get<UserProfileField>().SetSettings(request));
        }
    }
}