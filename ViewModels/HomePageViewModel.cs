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
        
        _Weather weather;

        ObservableCollection<_Weather> _weather;
        public static string APIKey = "2a74710e3a00414c9ad21757233001";


        public static string baseURL = "http://api.weatherapi.com/v1";


        string CurrentWeather = baseURL + "/" + "current.json?key=" + APIKey + "&q=auto:ip" + "&lang=ar";

        
        
        public HomePageViewModel()
        {
            _weather = new ObservableCollection<_Weather>();
            weather = new _Weather();
            Task.WhenAll(GetWeather());
            
        }
        

        public async Task GetWeather()
        {
            HttpClient client = new HttpClient();
            
            try
            {
                var response = await client.GetAsync(CurrentWeather);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weather = JsonConvert.DeserializeObject<_Weather>(content);
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
