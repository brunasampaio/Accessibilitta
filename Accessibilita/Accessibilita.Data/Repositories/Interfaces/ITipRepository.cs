using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessibilitta.Data.Entities;
using Accessibilitta.Data.Repositories.Base;

namespace Accessibilitta.Data.Repositories.Interfaces
{
    public interface ITipRepository : IRepository<Tip>, IDisposable
    {
    }
}
