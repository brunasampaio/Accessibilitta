using System;
using Accessibilita.Data.Entities;
using Accessibilita.Service.Base;

namespace Accessibilita.Service.Interfaces
{
    public interface IPlaceService : IService<Place>, IDisposable
    {
        void InsertIfNotExist(Place place);
    }
}
