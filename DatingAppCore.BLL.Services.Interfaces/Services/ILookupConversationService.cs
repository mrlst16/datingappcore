using CommonCore.Responses;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Entities.Messaging;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface ILookupConversationService
    {
        Task<Response<Conversation>> Lookup(GetConversationRequest request);
    }
}
