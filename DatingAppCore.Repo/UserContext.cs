using CommonCore.Repo.MongoDb;
using DatingAppCore.Entities.Members;
using DatingAppCore.Repo.Intefaces;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace DatingAppCore.Repo
{
    public class UserContext : IUserContext
    {
        private readonly IMongoDbContext _mongoDbContext;

        public UserContext(
            IMongoDbContext mongoDbContext
            )
        {
            _mongoDbContext = mongoDbContext;
        }

        public async Task AddUser(User user)
        {
            var collection = _mongoDbContext.GetCollection<User>();
            await collection.InsertOneAsync(user);
        }

        public async Task<User> GetUser(Guid id)
        {
            var collection = _mongoDbContext.GetCollection<User>();
            var pointer = await collection.FindAsync<User>(x => x.ID == id);
            return await pointer?.FirstOrDefaultAsync();
        }
    }
}
