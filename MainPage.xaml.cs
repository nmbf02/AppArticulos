using AppArticulos.Models;
using AppArticulos.Services;
using Microsoft.Maui.Networking;
using Microsoft.Maui.ApplicationModel;
using Plugin.BLE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Microsoft.Maui.Dispatching;

namespace AppArticulos;

public partial class MainPage : ContentPage
{
    private readonly ApiService _apiService;
    private List<Articulo> todosLosArticulos = new(); // Lista completa para filtrar
    private System.Timers.Timer estadoTimer;

    public MainPage()
    {
        InitializeComponent();
        _apiService = new ApiService();
        VerificarEstados(); // Ejecuta verificación al abrir
        IniciarVerificacionAutomatica(); // actualización automática cada 5 segundos
    }

    private async void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        var texto = e.NewTextValue?.Trim();

        if (string.IsNullOrWhiteSpace(texto))
        {
            ArticulosList.ItemsSource = null;
            MensajeVacio.IsVisible = false;
            return;
        }

        var articulos = await _apiService.ObtenerArticulosAsync(texto);
        ArticulosList.ItemsSource = articulos;
        MensajeVacio.IsVisible = articulos.Count == 0;
    }

    private async void VerificarEstados()
    {
        // Internet
        bool hayInternet = Connectivity.Current.NetworkAccess == NetworkAccess.Internet;
        InternetLabel.Text = $"Internet: {(hayInternet ? "Activo" : "No disponible")}";

        // Wi-Fi
        bool wifiActivo = Connectivity.Current.ConnectionProfiles.Contains(ConnectionProfile.WiFi);
        WifiLabel.Text = $"Wi-Fi: {(wifiActivo ? "Activo" : "No conectado")}";

        // GPS (Ubicación)
        try
        {
            var location = await Geolocation.GetLocationAsync(new GeolocationRequest
            {
                DesiredAccuracy = GeolocationAccuracy.Default,
                Timeout = TimeSpan.FromSeconds(5)
            });

            GpsLabel.Text = location != null ? "GPS: Activo" : "GPS: No disponible";
        }
        catch (Exception)
        {
            GpsLabel.Text = "GPS: No disponible";
        }

        // Bluetooth
        var bluetooth = CrossBluetoothLE.Current;
        bool bluetoothActivo = bluetooth.State == Plugin.BLE.Abstractions.Contracts.BluetoothState.On;
        BluetoothLabel.Text = $"Bluetooth: {(bluetoothActivo ? "Activo" : "Apagado")}";

        // Mostrar hora de verificación
        UltimaVerificacionLabel.Text = "Última verificación: " + DateTime.Now.ToString("hh:mm:ss tt");
    }
    private void IniciarVerificacionAutomatica()
    {
        estadoTimer = new System.Timers.Timer(5000); // cada 5 segundos
        estadoTimer.Elapsed += (sender, e) =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                VerificarEstados();
            });
        };
        estadoTimer.AutoReset = true;
        estadoTimer.Enabled = true;
    }
}
