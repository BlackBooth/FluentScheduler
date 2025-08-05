namespace FluentScheduler;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Some asynchrounous work to be done.
/// Make sure there's a parameterless constructor (avoid System.MissingMethodException).
/// </summary>
public interface IAsyncJob : IJob
{
    /// <summary>
    /// Executes the job.
    /// </summary>
    Task ExecuteAsync();
}