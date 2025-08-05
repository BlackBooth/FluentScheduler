using System.Net;

namespace FluentScheduler.TestGuiApp;

public class MyJobRegistry : Registry
{
    public MyJobRegistry()
    {
        Schedule(new CheckIsOnlineJob(IPAddress.Parse("10.29.32.11")))
            .ToRunNow()
            .AndEvery(10)
            .Seconds();

        Schedule(new CheckIsOnlineJob(IPAddress.Parse("10.29.1.3")))
            .ToRunNow()
            .AndEvery(10)
            .Seconds();

        Schedule(new DelayJob(TimeSpan.FromSeconds(5)))
            .NonReentrant()
            .WithName("DelayJob")
            .ToRunNow()
            .AndEvery(1)
            .Seconds();
    }
}