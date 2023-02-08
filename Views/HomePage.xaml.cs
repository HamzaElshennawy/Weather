using System;
using System.Net;
using Newtonsoft.Json;
using Weather.Models;
using Weather.ViewModels;

namespace Weather;

public partial class HomePage : ContentPage
{

    string Latitude;
    string Longitude;
    string Altitude;

    public HomePage()
    {
        InitializeComponent();
        Task.WhenAll(GetCurrentLocation());
        
        //BindingContext = new HomePageViewModel(Latitude,Longitude,Altitude);
    }

    
    // API key 2a74710e3a00414c9ad21757233001
    
    
    /// <summary>
    /// Base URL for the API
    /// </summary>
    


    private CancellationTokenSource _cancelTokenSource;
    private bool _isCheckingLocation;
    public async Task GetCurrentLocation()
    {
        //ask for the location permission
        
        try
        {
            _isCheckingLocation = true;

            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(30));

            _cancelTokenSource = new CancellationTokenSource();

            Microsoft.Maui.Devices.Sensors.Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

            if (location != null)
            {
                Longitude = location.Longitude.ToString();
                Latitude = location.Latitude.ToString();
                Altitude = location.Altitude.ToString();
                //TestLBL.Text = text;
            }
        }
        // Catch one of the following exceptions:
        //   FeatureNotSupportedException
        //   FeatureNotEnabledException
        //   PermissionException
        catch (FeatureNotSupportedException )
        {
            // Handle not supported on device exception
            await Application.Current.MainPage.DisplayAlert("Error", "Your device does not support this feature\nPlease search for the loctaion you want instead", "OK");
        }
        catch (FeatureNotEnabledException)
        {
            // Handle not enabled on device exception
            await Application.Current.MainPage.DisplayAlert("Error", "Your device does not have this feature enabled\nPlease enable it from settings", "OK");
        }
        catch (PermissionException)
        {
            // Handle permission exception
            await Application.Current.MainPage.DisplayAlert("Error", "You have not given permission to access your location\nPlease give permission from settings", "OK");
        }
        catch (Exception)
        {
            // Unable to get location
            await Application.Current.MainPage.DisplayAlert("Error", "Unable to get your location\nPlease search for the loctaion you want instead", "OK");
        }
        finally
        {
            _isCheckingLocation = false;
        }
    }

    public void CancelRequest()
    {
        if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
            _cancelTokenSource.Cancel();
    }

    private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {

    }
   
    
}

