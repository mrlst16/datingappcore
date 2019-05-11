﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Comparers;
using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Requests;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.Repo.Members;

namespace DatingAppCore.BLL.Services
{
    public class SetPropertiesService : ISetProfileService
    {
        public async Task<Response<bool>> Set(SetPropertiesRequest request)
        {
            return Response<bool>.Wrap(() =>
            {
                var properties = request
                    .Properties
                    ?.Select(x => new UserProfileField()
                    {
                        UserID = request.UserID,
                        IsSetting = false,
                        Name = x.Key,
                        Value = x.Value
                    }) ?? new List<UserProfileField>();

                var comparer = new ComparerFunc<UserProfileField>((x, y) =>
                {
                    return x.Name == y.Name && x.UserID == y.UserID && x.IsSetting == y.IsSetting;
                });

                RepoCache
                    .Get<UserProfileField>()
                    .AddRange(properties, comparer, true);
                return true;
            });
        }
    }
}