﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackPR___NewsBot.Entities
{
    public class LUIS_Result
    {
        public string query { get; set; }
        public Intent[] intents { get; set; }
        public Entity[] entities { get; set; }
    }
}