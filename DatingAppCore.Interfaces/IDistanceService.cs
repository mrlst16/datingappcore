using DatingAppCore.Dto.Geo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Interfaces
{
    public interface IDistanceService
    {
        double Calculate(GeoPoint one, GeoPoint two, bool km);
    }
}