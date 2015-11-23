﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessibilitta.Data.Context;
using Accessibilitta.Data.Entities;
using Accessibilitta.Data.Repositories.Base;
using Accessibilitta.Data.Repositories.Interfaces;


namespace Accessibilitta.Data.Repositories
{
    public class PlaceRepository : Repository<Place>, IPlaceRepository
    {
        public PlaceRepository(AccessibilittaContext context) : base(context) { }
    }
}