using System;

namespace ConsoleApp1
{
    public interface ITelemetry
    {
        string Name { get; set; }
        DateTime Timestamp { get; set; }

        int Koeficient {get;set;}

        string Status { get; set; }
    }
}