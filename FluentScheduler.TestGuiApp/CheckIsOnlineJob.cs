using System.Net;
using System.Net.NetworkInformation;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace FluentScheduler.TestGuiApp;

public class CheckIsOnlineJob : IJob
{
    private readonly IPAddress _address;
    private readonly Ping _ping;

    public CheckIsOnlineJob(IPAddress address)
    {
        _address = address;
        _ping = new Ping();
    }

    public void Execute()
    {
        var pingResult = _ping.Send(_address);
        StrongReferenceMessenger.Default.Send(new ValueChangedMessage<CheckIsOnlineChangedMessage>(new CheckIsOnlineChangedMessage(pingResult.Status, _address)));
    }
}

public record CheckIsOnlineChangedMessage(IPStatus Status, IPAddress Address);