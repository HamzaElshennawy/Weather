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
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace Weather.ViewModels
{
    [QueryProperty("Weather", "Weather")]
    public class HomePageViewModel : BaseViewModel
    {

        public _Weather weather { get; set; }


        string Latitude;
        string Longitude;
        string Altitude;

        public AsyncCommand isRefreshing { set; get; }

        

        public ObservableCollection<Forecastday> foreCasts { set; get; }

        public static string APIKey = "2a74710e3a00414c9ad21757233001";


        public static string baseURL = "https://api.weatherapi.com/v1";


        string CurrentWeather = baseURL + "/" + "forecast.json?key=" + APIKey + "&days=5" + "&q=auto:ip";


        public double screenHeight { get; set; }
        public double MaxHeight { get; set; }
        public double WindowSize { get; set; }
        public HomePageViewModel()
        {
            screenHeight = DeviceDisplay.MainDisplayInfo.Height;
            WindowSize = screenHeight;
            MaxHeight = screenHeight;
#if WINDOWS
            WindowSize = 500;
            screenHeight = 500;
            MaxHeight = 500;
#endif



            isRefreshing = new AsyncCommand(Refresh);
            foreCasts = new ObservableCollection<Forecastday>();
            weather = new _Weather();
            Task.WhenAll(GetWeather());

        }


        public async Task GetWeather()
        {

            //await GetCurrentLocation();
            string RequestLink = baseURL + "/" + "forecast.json?key=" + APIKey;
            string _CurrentWeather = $"&q={Latitude},{Longitude}";

            //if (LocationRequestFailed)
            //{
            //    RequestLink += "&q=auto:ip";
            //}
            //else
            //{
            //    RequestLink += _CurrentWeather;
            //}
            HttpClient client = new HttpClient();
            RequestLink += "&q=auto:ip";
            try
            {
                var response = await client.GetAsync(CurrentWeather);
                var content = await response.Content.ReadAsStringAsync();
                weather = JsonConvert.DeserializeObject<_Weather>(content);
                weather.current.condition.icon = weather.current.condition.icon.Replace("//", "https://");
                foreCasts.Clear();
                for(int i = 0;i< weather.forecast.forecastday.Length;i++)
                {
                    foreCasts.Add(weather.forecast.forecastday[i]);
                    OnPropertyChanged(nameof(foreCasts));
                }
                OnPropertyChanged(nameof(weather));
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
#if WINDOWS
     
#endif
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


        
        async Task Refresh()
        {
            IsNotBusy = false;
            await GetWeather();
            IsNotBusy = true;
        }
    }
}
