using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Extensions;
using CommonCore.Repo;
using DatingAppCore.Dto.Members;
//using DatingAppCore.Repo.EF.Members;
//using DatingAppCore.Repo.Members;
using UserDTO = DatingAppCore.Dto.Members.UserDTO;

namespace DatingAppCore.BLL.Adapters
{
    public static class Extensions
    {
        public static ICollection<T> AddRange<T>(this ICollection<T> collection, ICollection<T> add)
        {
            foreach (var item in add)
            {
                collection.Add(item);
            }
            return collection;
        }
    }

    public static class MembersAdapterExtensions
    {
        //private static UserProfileComparer userProfileComparer = new UserProfileComparer();

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
            }.EnsureID();
        }

        public static UserDTO ToDto(this User entity)
        {
            //var userProfileComparer = new UserProfileComparer();
            //var result = new UserDTO()
            //{
            //    ID = entity.ID,
            //    ExternalID = entity.ExternalID,
            //    IdType = entity.IdType,
            //    ClientID = entity.ClientID,
            //    Birthday = entity.Birthday,
            //    UserName = entity.UserName,
            //    Profile = entity.Profile?.Distinct(userProfileComparer)?.Where(x => x.IsSetting == false).ToDictionary(x => x.Name, field => field.Value),
            //    Settings = entity.Profile?.Distinct(userProfileComparer)?.Where(x => x.IsSetting == true).ToDictionary(x => x.Name, field => field.Value),
            //    Photos = entity.Photos?.Select(x => x.ToDto()).ToList()
            //};
            return null;
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
                FileName = entity.FileName,
                ContentType = entity.ContentType
            };
        }

        public static User ToEntity(this UserDTO dto)
        {
            var properties = dto.Settings.AddRange(dto.Profile);

            var result = new User()
            {
                ID = dto.ID,
                ExternalID = dto.ExternalID,
                ClientID = dto.ClientID,
                IdType = dto.IdType,
                UserName = dto.UserName,
                Birthday = dto.Birthday
            }.EnsureID();
            //result.Photos = dto.Photos?.Select(x => x.ToEntity(result.ID)).ToList();
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
            //result.Inbox = dto.Inbox?.Select(x => x.ToEntity()).ToList();
            //result.Sent = dto.Sent?.Select(x => x.ToEntity()).ToList();
            //result.SwipesReceived = dto.SwipesReceived?.Select(x => x.ToEntity()).ToList();
            //result.SwipesSent = dto.SwipesSent?.Select(x => x.ToEntity()).ToList();
            //result.ReviewReceived = dto.ReviewReceived?.Select(x => x.ToEntity()).ToList();
            //result.ReviewsSent = dto.ReviewsSent?.Select(x => x.ToEntity()).ToList();
            result.AsGrantee = dto.AsGrantee?.Select(x => x.ToEntity()).ToList();
            result.AsGrantor = dto.AsGrantor?.Select(x => x.ToEntity()).ToList();

            return result;
        }

        public static Photo ToEntity(this PhotoDTO dto)
        {
            return new Photo()
            {
                ID = dto.ID,
                UserID = dto.UserID,
                Access = dto.Access,
                Caption = dto.Caption,
                Rank = dto.Rank,
                LastUpdated = DateTime.UtcNow
            }.EnsureID();
        }

        public static Photo ToEntity(this PhotoDTO dto, Guid userid)
        {
            return new Photo()
            {
                ID = dto.ID,
                UserID = userid,
                Access = dto.Access,
                Caption = dto.Caption,
                Rank = dto.Rank,
                LastUpdated = DateTime.UtcNow
            }.EnsureID();
        }

        public static UserLocation ToEntity(this UserLocationDTO dto)
        {
            return new UserLocation()
            {
                ID = dto.ID,
                CreateDate = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                Lat = dto.Lat,
                Lon = dto.Lon,
                UserID = dto.UserID
            }.EnsureID();
        }

        public static UserLocationDTO ToDto(this UserLocation entity)
        {
            return new UserLocationDTO()
            {
                ID = entity.ID,
                Lat = entity.Lat,
                Lon = entity.Lon,
                UserID = entity.UserID
            };
        }
    }
}
