using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;

namespace ConsoleApp1
{
    public class TelemetryBuilder
    {
        private static List<ISubject<ITelemetry>> list;

        public TelemetryBuilder()
        {
            list = new List<ISubject<ITelemetry>>();
        }

        public void Compose<T>(T telemetry) where T : ITelemetry
        {
            Subject<ITelemetry> subject = null;

            // ReplaySubject<ITelemetry> replay = null;
            // AsyncSubject<ITelemetry> async = null;

            //replay = new ReplaySubject<ITelemetry>();

            if (telemetry.Name == "Vdr")
            {
                var o = Observable.Range(1, 10);
                //var c = Observable.Return(1).SelectMany()

                subject = new Subject<ITelemetry>();

                subject
                    .TakeWhile(x => x.Timestamp < DateTime.Now)
                    .Take(5)
                    .Subscribe(
                        x => { Console.WriteLine($"Name {x.Name} timestamp {x.Timestamp}"); },
                        e => { },
                        () => { Console.WriteLine("Complete"); });

                list.Add(subject);
            }

           // Observable.Do(() => Console.WriteLine(""));

            //Observable.Return(telemetry);


            while (true)
            {
                if (subject != null && !subject.IsDisposed)
                {
                    Console.WriteLine(telemetry.GetType());
                    list.ForEach(x => subject.OnNext(telemetry));
                }
            }
        }
    }
}
