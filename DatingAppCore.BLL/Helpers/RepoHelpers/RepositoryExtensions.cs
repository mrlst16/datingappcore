using CommonCore.Comparers;
using CommonCore.Repo.Repository;
using DatingAppCore.BLL.Adapters;
using DatingAppCore.Dto.Matching;
using DatingAppCore.Dto.Members;
using DatingAppCore.Dto.Messages;
using DatingAppCore.Dto.Requests;
using DatingAppCore.Dto.Reviewing;
using DatingAppCore.Repo.Matching;
using DatingAppCore.Repo.Members;
using DatingAppCore.Repo.Messaging;
using DatingAppCore.Repo.Reviewing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatingAppCore.BLL.Helpers.RepoHelpers
{
    public static class RepositoryExtensions
    {
        public static UserDTO GetUser(this Repository<User> repository, GetUserRequest request)
        {
            var query = repository
                    .GetQuery()
                    .Where(x => x.ID == request.UserID);

            if (request.IncludeProfile)
            {
                query = query.Include(x => x.Profile);
            }

            if (request.IncludeMessages)
            {
                query = query.Include(x => x.Inbox);
                query = query.Include(x => x.Sent);
            }

            if (request.IncludeSwipes)
            {
                query = query.Include(x => x.SwipesReceived);
                query = query.Include(x => x.SwipesSent);
            }

            if (request.IncludePhotos)
            {
                query = query.Include(x => x.Photos);
            }

            if (request.IncludeReviews)
            {
                query = query.Include(x => x.ReviewReceived);
                query = query.Include(x => x.ReviewsSent);
            }

            if (request.IncludePermissions)
            {
                query = query.Include(x => x.AsGrantee);
                query = query.Include(x => x.AsGrantor);
            }

            var result = query
                .FirstOrDefault()
                ?.ToDto();

            result.Photos = result.Photos?.OrderBy(x => x.Rank).ToList() ?? null;

            return result;
        }

        public static Conversation GetConversation(this Repository<Conversation> repo, GetConversationRequest request)
        {
            return repo
                .GetQuery()
                .Where(x => Conversation.AreEqual(x, request.User1ID, request.User2ID))
                .Include(x => x.Messages)
                .FirstOrDefault();
        }

        public static IEnumerable<Message> GetMessagesBetween(this Repository<Message> repo, LookupByUserIDRequest request)
        {
            return repo.GetQuery()
                .Where(x =>
                    x.SenderID == request.UserID
                    || x.ReceiverID == request.UserID)
                .Skip(request.Skip)
                .Take(request.Take);
        }

        public static IEnumerable<UserDTO> GetMatches(this Repository<Swipe> repo, LookupByUserIDRequest request)
        {
            var resultUsers = new List<Guid>();

            var peopleTheUserSwipedOn = repo.GetQuery()
                .Where(x => x.UserFromID == request.UserID && x.IsLike)
                .Skip(request.Skip)
                .Take(request.Take)
                .Select(x => x.UserToID)
                .Distinct();

            var peopleWhoSwipedOnTheUser = repo.GetQuery()
                .Where(x => x.UserToID == request.UserID && x.IsLike)
                .Skip(request.Skip)
                .Take(request.Take)
                .Select(x => x.UserFromID)
                .Distinct();

            foreach (var personWhoSwipedOnTheUsed in peopleWhoSwipedOnTheUser)
            {
                if (peopleTheUserSwipedOn.Contains(personWhoSwipedOnTheUsed))
                    resultUsers.Add(personWhoSwipedOnTheUsed);
            }

            return resultUsers.Select(x => RepoCache.Get<User>().GetUser(new GetUserRequest()
            {
                UserID = x,
                IncludeMessages = true,
                IncludePhotos = true,
                IncludeProfile = true,
                IncludeReviews = true
            }));
        }

        public static bool IsMatch(this Repository<Swipe> repository, Guid user1id, Guid user2id)
        {
            var repo = RepoCache.Get<Swipe>();
            var swipeFromUser1 = repo.GetQuery()
                .FirstOrDefault(
                    x => x.UserFromID == user1id
                    && x.UserToID == user2id
                    && x.IsLike
                );
            if (swipeFromUser1 == null) return false;

            var swipeFromUser2 = repo.GetQuery()
                .FirstOrDefault(
                    x => x.UserFromID == user2id
                    && x.UserToID == user1id
                    && x.IsLike
                );
            if (swipeFromUser2 == null) return false;

            return true;
        }

        public static bool UpdateUserLocation(this Repository<User> repo, UserLocation userLocation)
        {
            var user = repo.GetQuery().FirstOrDefault(x => x.ID == userLocation.UserID);
            user.Lat = userLocation.Lat;
            user.Lon = userLocation.Lon;
            repo.Save();
            return true;
        }

        public static bool SendMessage(this Repository<Message> repository, MessageDTO request)
        {
            Conversation conversation = RepoCache.Get<Conversation>()
                .RegisterOrLogin(request.From, request.To);

            var entity = request.ToEntity();
            entity.ConversationID = conversation.ID;
            repository
                    .Add(entity)
                    .Save();
            return true;
        }

        public static Conversation RegisterOrLogin(this Repository<Conversation> repository, Guid user1, Guid user2)
        {
            Conversation conversation = repository.GetQuery()
                .FirstOrDefault(x =>
                    Conversation.AreEqual(x, user1, user2)
            );

            if (conversation != null) return conversation;

            conversation = new Conversation()
            {
                ID = Guid.NewGuid(),
                User1ID = user1,
                User2ID = user2
            };

            repository
                .Add(conversation)
                .Save();

            return conversation;
        }

        public static bool SendReview(this Repository<Review> repository, SaveReviewRequest request)
        {
            repository
                    .Add(request.ToEntity())
                    .Save();
            return true;
        }

        public static Review GetReviewOfUser(this Repository<Review> repository, Guid userid)
        {
            return repository
                .GetQuery()
                .FirstOrDefault(x => x.ReceiverID == userid);
        }

        public static bool SavePhotos(this Repository<Photo> repository, SetPhotosRequest request)
        {
            var photos = request.Photos.Select(x =>
            {
                x.UserID = request.UserID;
                return x.ToEntity();
            });
            repository
                .RemoveRange(photos)
                .AddRange(request.Photos.Select(x =>
                {
                    x.UserID = request.UserID;
                    return x.ToEntity();
                }))
                .Save();
            return true;
        }

        public static bool SavePhotosOrer(this Repository<Photo> repository, SetPhotosRequest request)
        {
            List<Photo> updateThis = new List<Photo>();

            for (int i = 0; i < request.Photos.Count; i++)
            {
                var photo = request.Photos[i].ToEntity();
                photo = repository.GetQuery().FirstOrDefault(x => x == photo);
                if (photo == null) photo = request.Photos[i].ToEntity();

                photo.UserID = request.UserID;
                photo.Rank = i;
                updateThis.Add(photo);
            }

            repository
                .RemoveRange(x => x.UserID == request.UserID)
                .AddRange(updateThis)
                .Save();
            return true;
        }

        public static bool SetProfile(this Repository<UserProfileField> repository, SetPropertiesRequest request)
        {
            var properties = request
                    .Properties
                    ?.Where(x => !string.IsNullOrWhiteSpace(x.Value))
                    ?.Select(x => new UserProfileField()
                    {
                        UserID = request.UserID,
                        IsSetting = false,
                        Name = x.Key,
                        Value = x.Value
                    }) ?? new List<UserProfileField>();

            var removeThese = repository
                .GetQuery()
                .Where(x => x.UserID == request.UserID
                            && x.IsSetting == false);

            repository.RemoveRange(removeThese);

            var comparer = new ComparerFunc<UserProfileField>((x, y) =>
            {
                return x.Name == y.Name && x.UserID == y.UserID && x.IsSetting == y.IsSetting;
            });

            repository.AddRange(properties, comparer, true);
            return true;
        }

        public static bool SetPoperties(this Repository<UserProfileField> repository, SetPropertiesRequest request)
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

            repository.AddRange(properties, comparer, true);
            return true;
        }

        public static bool SetSettings(this Repository<UserProfileField> repository, SetPropertiesRequest request)
        {
            var properties = request
                  .Properties
                  ?.Where(x => !string.IsNullOrWhiteSpace(x.Value))
                  ?.Select(x => new UserProfileField()
                  {
                      UserID = request.UserID,
                      IsSetting = true,
                      Name = x.Key,
                      Value = x.Value
                  }) ?? new List<UserProfileField>();

            var removeThese = repository
                .GetQuery()
                .Where(x => x.UserID == request.UserID
                    && x.IsSetting == true);

            repository.RemoveRange(removeThese);

            var comparer = new ComparerFunc<UserProfileField>((x, y) =>
            {
                return x.Name == y.Name && x.UserID == y.UserID && x.IsSetting == y.IsSetting;
            });

            repository.AddRange(properties, comparer, true);
            return true;
        }

        public static bool AddSwipe(this Repository<Swipe> repository, SwipeDTO request)
        {
            repository.Add(request.ToEntity(), true);
            return true;
        }

        public static IEnumerable<ReviewBadgeTemplate> GetClientReviewBadges(this Repository<ReviewBadgeTemplate> repository, Guid clientID)
        {
            return repository.GetQuery()
                .Where(x => x.ClientID == clientID);
        }
    }
}