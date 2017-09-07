using System;

namespace ConsoleApp1
{
    public interface ITelemetry
    {
        string Name { get; set; }
        DateTime Timestamp { get; set; }
    }
}