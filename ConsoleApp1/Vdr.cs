﻿using System;

namespace ConsoleApp1
{
    public class Vdr : ITelemetry
    {
        public DateTime Timestamp { get; set; }
        public string Name { get; set; }
    }
}
