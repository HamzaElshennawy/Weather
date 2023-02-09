using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Models;
using System.Net.Http;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Weather.ViewModels
{
    [QueryProperty("Weather","Weather")]
    public class HomePageViewModel : BaseViewModel
    {

        public _Weather weather { get; set; }


        string Latitude;
        string Longitude;
        string Altitude;


        public ObservableCollection<_Weather> _weather;
        public static string APIKey = "2a74710e3a00414c9ad21757233001";


        public static string baseURL = "https://api.weatherapi.com/v1";


        string CurrentWeather = baseURL + "/" + "current.json?key=" + APIKey + "&q=auto:ip";

        
        
        public HomePageViewModel()
        {
            _weather = new ObservableCollection<_Weather>();
            weather = new _Weather();
            Task.WhenAll(GetWeather());
            
        }
        

        public async Task GetWeather()
        {

            await GetCurrentLocation();
            string RequestLink = baseURL + "/" + "forecast.json?key=" + APIKey;
            string _CurrentWeather = $"&q={Latitude},{Longitude}";

            if (LocationRequestFailed)
            {
                RequestLink += "&q=auto:ip";
            }
            else
            {
                RequestLink += _CurrentWeather;
            }
            HttpClient client = new HttpClient();
            
            try
            {
                var response = await client.GetAsync(RequestLink);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weather = JsonConvert.DeserializeObject<_Weather>(content);
                    weather.current.condition.icon = weather.current.condition.icon.Replace("//", "https://");
                    OnPropertyChanged(nameof(weather));
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }






        private CancellationTokenSource _cancelTokenSource;
        private bool _isCheckingLocation;
        
        
        bool LocationRequestFailed;
        
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
            catch (FeatureNotSupportedException)
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
                LocationRequestFailed = true;
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
    }
}
