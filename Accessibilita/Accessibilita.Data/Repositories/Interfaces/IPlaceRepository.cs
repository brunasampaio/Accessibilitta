using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessibilita.Data.Entities;
using Accessibilita.Data.Repositories.Base;

namespace Accessibilita.Data.Repositories.Interfaces
{
    public interface IPlaceRepository : IRepository<Place>, IDisposable
    {
    }
}
