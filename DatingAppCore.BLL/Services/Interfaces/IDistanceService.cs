using DatingAppCore.DTO.Geo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.BLL.Services.Interfaces
{
    public interface IDistanceService
    {
        double Calculate(GeoPoint one, GeoPoint two, bool km);
    }
}
