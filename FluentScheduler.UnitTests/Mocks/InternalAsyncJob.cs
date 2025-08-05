namespace FluentScheduler.UnitTests.Mocks;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

[SuppressMessage("Design", "CA1812")]
internal class AsyncJob : IAsyncJob
{
    public static int Calls { get; private set; }

    public async Task ExecuteAsync()
    {
        ++Calls;
        await Task.CompletedTask;
    }
}
