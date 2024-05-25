using Android.App;
using Android.Runtime;

namespace BLE.Client.Maui.Views;

[Application]
public class MainApplication : MauiApplication
{
    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
        : base(handle, ownership)
    {
    }

    protected override MauiApp CreateMauiApp() => App.CreateMauiApp();
}

