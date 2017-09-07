using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var vdr = new Vdr() { Name = "Vdr1", Koeficient = 1, Timestamp = DateTime.Now }; // new DateTime(2017, 08, 31, 20, 0, 0)}; //instancia 20:00:00
            var lpr = new Lpr() { Name = "Lpr1", Koeficient = 1, Timestamp = new DateTime(2017, 08, 31, 20, 1, 0)};
            var lpr1 = new Lpr() { Name = "Lpr2", Koeficient = 1, Timestamp = new DateTime(2017, 08, 31, 20, 1, 0)};

            var vdr2 = new Vdr() { Name = "Vdr1", Koeficient = 2, Timestamp =  DateTime.Now }; //instancia 20:00:00
            var lpr2 = new Lpr() { Name = "Lpr3", Koeficient = 2, Timestamp = new DateTime(2017, 09, 1, 20, 0, 0)}; //instancia 20:00:00
            var lpr3 = new Lpr() { Name = "Lpr4", Koeficient = 2, Timestamp = new DateTime(2017, 09, 1, 20, 0, 0)}; //instancia 20:00:00

            /*
            TelemetryBuilder b = TelemetryBuilder();
            b.Compose(vdr);
            b.Compose(lpr);

            b.Compose(lpr1);
            b.Compose(lpr2);
            b.Compose(lpr3);
            */
            TelemetryBuilder.Compose(vdr);
            TelemetryBuilder.Compose(lpr);
            TelemetryBuilder.Compose(lpr1);
            Thread.Sleep(6000);

            TelemetryBuilder.Compose(vdr2);
            TelemetryBuilder.Compose(lpr2);
            TelemetryBuilder.Compose(lpr3);
            //TelemetryBuilder.Compose(lpr3);


            Console.WriteLine("press any key to exit");
            //while(true);

            Console.Read(); //.ReadKey();
        }
    }
}
