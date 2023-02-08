using System;
using System.Net;
using Newtonsoft.Json;
using Weather.Models;
using Weather.ViewModels;

namespace Weather;

public partial class HomePage : ContentPage
{

    

    public HomePage()
    {
        InitializeComponent();
        //Task.WhenAll(GetCurrentLocation());
        
        //BindingContext = new HomePageViewModel(Latitude,Longitude,Altitude);
    }

    
    // API key 2a74710e3a00414c9ad21757233001
    
    
    /// <summary>
    /// Base URL for the API
    /// </summary>
    


    

    private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {

    }
   
    
}

