namespace BLE.Client.Maui;

public static class MauiProgram
{
    // Not sure this needs to be in a separate file but I do think it needs to not be inside of the App class.
    public static MauiApp InitApp() {
        return MauiApp.CreateBuilder()
            .UseMauiApp<Views.App>()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .Build();
    }
}
