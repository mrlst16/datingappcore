﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Repository;
using CommonCore.Responses;
using DatingAppCore.BLL.Adapters;
using DatingAppCore.BLL.Helpers.RepoHelpers;
using DatingAppCore.BLL.Services.Interfaces;
using DatingAppCore.DTO.Messages;
using DatingAppCore.Repo.Messaging;

namespace DatingAppCore.BLL.Services
{
    public class SendMessageService : ISendMessageService
    {
        public async Task<Response<bool>> Send(MessageDTO request)
        {
            return Response<bool>.Wrap(() => RepoCache.Get<Message>().SendMessage(request));
        }
    }
}
