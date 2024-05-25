using System.Collections.ObjectModel;

namespace BLE.Client.Maui.Views;

public partial class LogViewer : ContentPage
{
    public static void Log(string message) => MainThread.BeginInvokeOnMainThread(() => LogMessages.Add(message));

    public static readonly ObservableCollection<string> LogMessages = [];

    public LogViewer() {
        InitializeComponent();
    }

    private void ClearLogs(object sender, EventArgs e) => LogMessages.Clear();
}