using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessibilita.Data.Entities;
using Accessibilita.Service.Base;

namespace Accessibilita.Service.Interfaces
{
    public interface IRateService : IService<Rate>, IDisposable
    {
        object[] RatesByPlace(int placeId);
        bool RatePlace(int accountId, int placeId, int rateTypeId, int rating);
    }
}
