﻿namespace BLE.Client.Maui.WinUI;

public partial class App : MauiWinUIApplication {
    public App() {
        this.InitializeComponent();
    }

    protected override MauiApp CreateMauiApp() => Views.App.CreateMauiApp();
}