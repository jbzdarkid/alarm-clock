namespace BLE.Client.Maui.Views;

public partial class App : Application {
    public App() {
		InitializeComponent();
        MainPage = new AppShell();
	}

    public static Task ShowAlertAsync(string message, string title = "BLE Scanner", string cancel="OK")
        => Current.MainPage.DisplayAlert(title, message, cancel);

    public static Task<bool> ShowConfirmationAsync(string title, string message, string accept = "Yes", string cancel = "No")
        => Current.MainPage.DisplayAlert(title, message, accept, cancel);
}
