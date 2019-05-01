using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Extensions;
using CommonCore.Repo;
using DatingAppCore.Dto.Members;
using DatingAppCore.DTO.Members;
using DatingAppCore.Repo.Members;
using UserDTO = DatingAppCore.DTO.Members.UserDTO;

namespace DatingAppCore.BLL.Adapters
{
    public static class Extensions
    {
        public static ICollection<T> AddRange<T>(this ICollection<T> collection, ICollection<T> add)
        {
            foreach(var item in add)
            {
                collection.Add(item);
            }
            return collection;
        }
    }

    public static class MembersAdapterExtensions
    {

        public static GrantedPermissionsDTO ToDto(this GrantedPermission entity)
        {
            return new GrantedPermissionsDTO()
            {
                GranteeID = entity.GranteeID,
                GrantorID = entity.GrantorID,
                Permissions = entity.Permissions
            };
        }

        public static GrantedPermission ToEntity(this GrantedPermissionsDTO dto)
        {
            return new GrantedPermission()
            {
                GranteeID = dto.GranteeID,
                GrantorID = dto.GrantorID,
                Permissions = dto.Permissions
            };
        }

        public static UserDTO ToDto(this User entity)
        {
            return new UserDTO()
            {
                ID = entity.ID,
                ExternalID = entity.ExternalID,
                IdType = entity.IdType,
                UserName = entity.UserName,
                Profile = entity.Profile?.Where(x => x.IsSetting == false).ToDictionary(x => x.Name, field => field.Value),
                Settings = entity.Profile?.Where(x => x.IsSetting == true).ToDictionary(x => x.Name, field => field.Value),
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

        public static User ToEntity(this UserDTO dto)
        {
            var properties = dto.Settings.AddRange(dto.Profile);

            var result = new User()
            {
                ID = dto.ID,
                ExternalID = dto.ExternalID,
                IdType = dto.IdType,
                UserName = dto.UserName,
            }.EnsureID();
            result.Photos = dto.Photos?.Select(x => x.ToEntity(result.ID)).ToList();
            result.Profile = dto.Settings?.Select(x =>
            {
                return new UserProfileField()
                {
                    Name = x.Key,
                    Value = x.Value,
                    UserID = result.ID,
                    IsSetting = true
                }.EnsureID();
            }).ToList();
            result.Profile.AddRange(dto.Profile?.Select(x =>
            {
                return new UserProfileField()
                {
                    Name = x.Key,
                    Value = x.Value,
                    UserID = result.ID,
                    IsSetting = false
                }.EnsureID();
            }).ToList());
            result.Inbox = dto.Inbox?.Select(x => x.ToEntity()).ToList();
            result.Sent = dto.Sent?.Select(x => x.ToEntity()).ToList();
            result.SwipesReceived = dto.SwipesReceived?.Select(x => x.ToEntity()).ToList();
            result.SwipesSent = dto.SwipesSent?.Select(x => x.ToEntity()).ToList();
            result.ReviewReceived = dto.ReviewReceived?.Select(x => x.ToEntity()).ToList();
            result.ReviewsSent = dto.ReviewsSent?.Select(x => x.ToEntity()).ToList();
            result.AsGrantee = dto.AsGrantee?.Select(x => x.ToEntity()).ToList();
            result.AsGrantor = dto.AsGrantor?.Select(x => x.ToEntity()).ToList();

            return result;
        }

        public static Photo ToEntity(this PhotoDTO dto, Guid userid)
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
