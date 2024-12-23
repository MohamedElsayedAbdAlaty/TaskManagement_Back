﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}