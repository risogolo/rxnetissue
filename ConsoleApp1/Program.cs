using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var vdr = new Vdr() { Name = "Vdr", Timestamp = DateTime.Now.AddSeconds(-1) };
            var lpr = new Lpr() { Name = "Lpr", Timestamp = DateTime.Now.AddSeconds(-1) };

            TelemetryBuilder b = new TelemetryBuilder();
            b.Compose(vdr);
            b.Compose(lpr);

            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }
    }
}
