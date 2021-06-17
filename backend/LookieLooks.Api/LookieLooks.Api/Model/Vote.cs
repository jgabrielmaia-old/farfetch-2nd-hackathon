﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookieLooks.Api.Model
{
    public class Vote
    {
        public Guid GameId { get; set; }
        
        public string UserName { get; set; }

        public string SelectedOption { get; set; }
    }
}
