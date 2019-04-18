using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Extensions;
using CommonCore.Repo;
using DatingAppCore.DTO.Members;
using DatingAppCore.Repo.Members;
using UserDTO = DatingAppCore.DTO.Members.UserDTO;

namespace DatingAppCore.BLL.Adapters
{
    public static class MembersAdapterExtensions
    {
        public static UserDTO ToDto(this Repo.Members.User entity)
        {
            return new UserDTO()
            {
                ID = entity.ID,
                ExternalID = entity.ExternalID,
                IdType = entity.IdType,
                UserName = entity.UserName,
                Profile = entity.Profile?.Where(x=>x.IsSetting == false).ToDictionary(x => x.Name, field => field.Value),
                Settings = entity.Profile?.Where(x=>x.IsSetting == true).ToDictionary(x => x.Name, field => field.Value),
                Photos = entity.Photos?.Select(x => x.ToDto()).ToList()
            };
        }

        public static PhotoDTO ToDto(this Photo entity)
        {
            return new PhotoDTO()
            {
                ID = entity.ID,
                UserID = entity.UserID,
                Access = entity.Access,
                Caption = entity.Caption,
                Rank = entity.Rank,
                Url = entity.Url
            };
        }

        public static Repo.Members.User ToEntity(this UserDTO dto)
        {
            var properties = dto.Settings.AddRange(dto.Profile);

            return new Repo.Members.User()
            {
                ID = dto.ID,
                ExternalID = dto.ExternalID,
                IdType = dto.IdType,
                UserName = dto.UserName,
                Profile = properties.Select(x =>
                {
                    return new UserProfileField()
                    {
                        Name = x.Key,
                        Value = x.Value,
                        UserID = dto.ID
                    }.EnsureID();
                }).ToList(),
                Photos = dto.Photos.Select(x => x.ToEntity()).ToList()
            }.EnsureID();
        }

        public static Photo ToEntity(this PhotoDTO dto)
        {
            return new Photo()
            {
                ID = dto.ID,
                UserID = dto.UserID,
                Access = dto.Access,
                Caption = dto.Caption,
                Url = dto.Url,
                Rank = dto.Rank,
                LastUpdated = DateTime.UtcNow
            }.EnsureID();
        }
    }
}
