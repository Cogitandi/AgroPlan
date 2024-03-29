﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Core.Domain
{
    public class Fertilizer
    {
        public Guid Id { get; set; }
        public String Name { get; set; }

        public IEnumerable<FertilizerComponent> FertilizerComponents { get; set; }
    }
}
