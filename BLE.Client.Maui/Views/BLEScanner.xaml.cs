using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Exceptions;
namespace BLE.Client.Maui.Views;

public partial class BLEScanner : ContentPage {
    private readonly BLEScannerViewModel _viewModel;
    public BLEScanner() {
        InitializeComponent();
        _viewModel = new();
        BindingContext = _viewModel;
    }

    private async void DeviceButton_Clicked(object sender, EventArgs e) {
        Guid deviceId = (Guid)(sender as Button).BindingContext;
        await this.LoadDeviceAttributes(deviceId);
    }

    private static readonly Guid LIGHT_CHARACTERISTIC = new("932c32bd-0002-47a2-835a-a8d455b859dd");
    private static readonly Guid BRIGHTNESS_CHARACTERISTIC = new("932c32bd-0003-47a2-835a-a8d455b859dd");
    private static readonly Guid TEMPERATURE_CHARACTERISTIC = new("932c32bd-0004-47a2-835a-a8d455b859dd");

    private async Task LoadDeviceAttributes(Guid deviceId) {
        IAdapter adapter = CrossBluetoothLE.Current.Adapter;
        IDevice device = adapter.DiscoveredDevices.FirstOrDefault(d => d.Id == deviceId);

        for (int i = 0; i < 3; i++) {
            try {
                await adapter.ConnectToDeviceAsync(device);
                break;
            } catch (DeviceConnectionException ex) {
                await App.ShowAlertAsync(ex.ToString());
            }
        }

        var services = await device.GetServicesAsync();
        foreach (IService service in services) {
            var characteristics = await service.GetCharacteristicsAsync();
            foreach (ICharacteristic characteristic in characteristics) {
                if (characteristic.Id == LIGHT_CHARACTERISTIC) {
                    int k = 1;
                } else if (characteristic.Id == BRIGHTNESS_CHARACTERISTIC) {
                    int k = 1;
                } else if (characteristic.Id == TEMPERATURE_CHARACTERISTIC) {
                    int k = 1;
                }
            }
        }

        /*
        await adapter.ConnectToDeviceAsync(device);
        }
        catch (DeviceConnectionException e)
        {
            // ... could not connect to device
        }

        /*
        DebugMessage("Iterating connected devices");
        foreach (IDevice connectedDevice in adapter.ConnectedDevices) {
            try {
                await connectedDevice.UpdateRssiAsync();
            } catch (Exception ex) {
                ShowAlert($"Failed to update RSSI for {connectedDevice.Name}. Error: {ex.Message}");
            }

            this.OnDeviceDiscovered(connectedDevice);
        }
        */

    }
}
