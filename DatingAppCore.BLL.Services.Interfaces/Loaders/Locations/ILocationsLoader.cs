using DatingAppCore.Dto.Requests;
using DatingAppCore.Entities.Members;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Interfaces.Loaders.Locations
{
    public interface ILocationsLoader
    {
        Task<IEnumerable<UserLocation>> UsersWithinLocation(FindMatchesRequest request);
    }
}
