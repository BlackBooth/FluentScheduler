namespace FluentScheduler.TestGuiApp;

public class DelayJob : IAsyncJob
{
    private readonly TimeSpan _delay;

    public DelayJob(TimeSpan delay)
    {
        _delay = delay;
    }

    public async Task ExecuteAsync()
    {
        await Task.Delay(_delay);

        throw new Exception("Test failed");
    }
}