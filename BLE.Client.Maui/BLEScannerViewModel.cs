using BLE.Client.Maui.Views;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;

namespace BLE.Client.Maui;

public class BLEScannerViewModel {
    public BLEScannerViewModel() {
        MainThread.BeginInvokeOnMainThread(async () => await this.Init());
    }

    private async Task Init() {
        LogViewer.Log("Checking BLE state");
        IBluetoothLE ble = CrossBluetoothLE.Current;
        if (ble?.IsOn != true)
        {
            string errorMessage = ble?.State switch {
                BluetoothState.Unavailable => "BLE is not available on this device.",
                BluetoothState.Unauthorized => "You are not authorized to use BLE.",
                BluetoothState.TurningOn => "BLE is warming up, please wait.",
                BluetoothState.On => "BLE is now on, please try again.",
                BluetoothState.TurningOff => "BLE is turning off, please wait and then turn it on.",
                BluetoothState.Off => "BLE is off. Please turn it on.",
                _ => "Unknown BLE state.",
            };
            await App.ShowAlertAsync(errorMessage);
            return;
        }

        LogViewer.Log("Verifying Bluetooth permissions");
        var permissionResult = await Permissions.CheckStatusAsync<Permissions.Bluetooth>();
        if (permissionResult != PermissionStatus.Granted)
        {
            LogViewer.Log("BLE permission not granted, requesting...");
            permissionResult = await Permissions.RequestAsync<Permissions.Bluetooth>();
        }
        LogViewer.Log($"Result of requesting Bluetooth permissions: '{permissionResult}'");
        if (permissionResult != PermissionStatus.Granted)
        {
            await App.ShowAlertAsync("Unable to get permissions for BLE, cannot scan for devices.");
            AppInfo.ShowSettingsUI();
            return;
        }

        LogViewer.Log("Cleared device list");

        LogViewer.Log("Scanning for connected devices");
        IAdapter adapter = ble.Adapter;
        adapter.ScanMode = ScanMode.LowLatency;
        adapter.ScanTimeout = 60_000; // 30s
        adapter.DeviceDiscovered += OnDeviceDiscovered;
        await adapter.StartScanningForDevicesAsync();
        LogViewer.Log("Finished scanning devices");
    }

    private void OnDeviceDiscovered(object sender, DeviceEventArgs args) {
        MainThread.BeginInvokeOnMainThread(() => {
            var device = args.Device;
            LogViewer.Log($"Discovered device {device.Id}: {device.Name}");
            // device.
        });
    }
}
