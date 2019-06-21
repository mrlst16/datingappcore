using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Mathematics;
using DatingAppCore.Dto.Geo;
using DatingAppCore.Interfaces;

namespace DatingAppCore.BLL.Services
{
    public class HaversineDistanceService : IDistanceService
    {
        public double Calculate(GeoPoint one, GeoPoint two, bool km = false)
        {
            var R = km ? 6373 : 3961;

            var φ1 = one.Latitude.ToRadians();
            var φ2 = two.Latitude.ToRadians();
            var Δφ = (two.Latitude - one.Latitude).ToRadians();
            var Δλ = (two.Longitude - one.Longitude).ToRadians();

            var a = Math.Sin(Δφ / 2) * Math.Sin(Δφ / 2) +
                    Math.Cos(φ1) * Math.Cos(φ2) *
                    Math.Sin(Δλ / 2) * Math.Sin(Δλ / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            var d = R * c;

            return d;
        }
    }
}
