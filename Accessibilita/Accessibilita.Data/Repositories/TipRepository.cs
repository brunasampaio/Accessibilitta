using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessibilita.Data.Context;
using Accessibilita.Data.Entities;
using Accessibilita.Data.Repositories.Base;
using Accessibilita.Data.Repositories.Interfaces;

namespace Accessibilita.Data.Repositories
{
    public class TipRepository : Repository<Tip>, ITipRepository
    {
        public TipRepository(AccessibilitaContext context) : base(context) { }

    }
}
