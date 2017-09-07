namespace ConsoleApp1
{
    public interface ITelemetryBuilder //<T> : ITelemetry
    {
         void Compose<T>(T telemetry) where T: ITelemetry;
    }
}