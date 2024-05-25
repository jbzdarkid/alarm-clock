using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using BLE.Client.Maui.Views;

namespace BLE.Client.Maui;

class Program : MauiApplication {
    protected override MauiApp CreateMauiApp() => App.CreateMauiApp();

    static void Main(string[] args) {
        var app = new Program();
        app.Run(args);
    }
}