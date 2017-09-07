using System;

namespace ConsoleApp1
{
    public class Lpr : ITelemetry
    {
        public DateTime Timestamp { get; set; }

        public string Name { get; set; }

        public string NiecoNaviac { get; set; } //property naviac oproti interfacu
        public string Status { get; set; }
        public int Koeficient { get; set; }
    }
}
