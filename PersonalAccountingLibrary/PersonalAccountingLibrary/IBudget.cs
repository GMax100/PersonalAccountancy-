﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccountingLibrary
{
    interface IBudget
    {
        Dictionary<string, List<ItemView>> Items { get; }
    }
}
