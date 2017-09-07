using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
    public class Tdr
    {
        public Tdr()
        {
            
            Identifier = Guid.NewGuid();
            Console.WriteLine($"New record composition started {Identifier}");
        }

        public Guid Identifier { get; set; }

        public IEnumerable<Vdr> Vdrs { get; set; }

        public IEnumerable<Lpr> Lprs { get; set; }

        public void Compose<T>(T telemetry) where T: ITelemetry
        {
            var property = GetType().GetRuntimeProperties().FirstOrDefault(p => p.PropertyType == typeof(T) || p.PropertyType == typeof(IEnumerable<T>));

            if (property == null)
            {
                throw new ArgumentOutOfRangeException("There is not assignable property defined in TDR");
            }

            if (typeof(IEnumerable<T>).IsAssignableFrom(property.PropertyType)) //if it is a list then add "entity"
                ((IList<T>)property.GetValue(this, null)).Add(telemetry);
            else
                property.SetValue(this, telemetry); //if it is not an list then assign entity

            Console.WriteLine($"Name {telemetry.Name} timestamp {telemetry.Timestamp} status {telemetry.Status} identifier {Identifier}"); 
        }

        public void Completed()
        {
            Console.WriteLine($"Record coposition completed {Identifier}");
        }
    }
}
