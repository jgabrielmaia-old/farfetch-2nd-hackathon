﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookieLooks.Api.Model
{
    public class ClosedGame
    {
        public int ProductId { get; set; }

        public IDictionary<string, string> ClosedAttributes { get; set; }

        public bool isClosed { get; set; }
    }
}
