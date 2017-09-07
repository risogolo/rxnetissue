using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;

namespace ConsoleApp1
{
    public static class TelemetryBuilder
    {
        private static List<ISubject<ITelemetry>> _list = new List<ISubject<ITelemetry>>();
        private static Dictionary<Guid, Tdr> _tdrs = new Dictionary<Guid, Tdr>();
        private static ReplaySubject<ITelemetry> subject = null;
        public static void Compose<T>(T telemetry) where T : ITelemetry
        {
            if (telemetry.Name == "Vdr1") //resp mastertimestampid
            {
                Tdr tdr = new Tdr();
          
                var vdrko = telemetry as Vdr;
                subject = new ReplaySubject<ITelemetry>(TimeSpan.FromMinutes(1));

                var pokus = subject
                .TakeUntil(vdrko.Timestamp.Add(TimeSpan.FromSeconds(5)))
                .Where(x => string.IsNullOrEmpty(x.Status))
                .Do(x => { x.Status = "Processed " + tdr.Identifier; })
                .Subscribe(
                    x =>
                    {
                        tdr.Compose(x);
                    },
                    e => { Console.WriteLine(e.Message); },
                    () =>
                    {
                        tdr.Completed();
                    });
            }

            subject.OnNext(telemetry);
        }
    }
}
