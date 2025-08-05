using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace FluentScheduler.TestGuiApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        StrongReferenceMessenger.Default.Register<ValueChangedMessage<CheckIsOnlineChangedMessage>>(this, MessageHandler);

        JobManager.Initialize(new MyJobRegistry());

        JobManager.JobStart += (s) =>
        {
            AddToTextBox($"Started {s.Name}: {s.StartTime}");
        };

        JobManager.JobException += info =>
        {
            AddToTextBox($"Job failed: {info.Name}{Environment.NewLine}{info.Exception.Message}");
        };

        button1.Command = StartJobmanagerCommand;
        button2.Command = StopJobmanagerCommand;
    }

    [RelayCommand]
    private void StartJobmanager()
    {
        JobManager.Start();
    }

    [RelayCommand]
    private void StopJobmanager()
    {
        JobManager.Stop();
    }

    private void MessageHandler(object recipient, ValueChangedMessage<CheckIsOnlineChangedMessage> message)
    {
        AddToTextBox($"{message.Value.Address}: {message.Value.Status}");
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // JobManager.Start();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        // JobManager.Stop();
    }

    private void AddToTextBox(string message)
    {
        if (InvokeRequired)
        {
            Invoke(new Action<string>(s =>
            {
                textBox1.Text += $"{s}{Environment.NewLine}";
            }), message);

            return;
        }

        textBox1.Text += $"{message}{Environment.NewLine}";
    }
}