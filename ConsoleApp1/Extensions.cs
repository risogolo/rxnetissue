using System;
using System.Linq.Expressions;

namespace ConsoleApp1
{
    public static class Extensions
    {
        public static Func<ITelemetry, bool> SupportedLayout(Configuration configuration)
        {
            var predicate = PredicateBuilder.False<ITelemetry>();

            predicate = predicate.Or(p => p.Name == "Lpr3");
            //predicate = predicate.Or(p => p.Name == "Lpr4");


            
            return predicate.Compile();
        }
    }
}