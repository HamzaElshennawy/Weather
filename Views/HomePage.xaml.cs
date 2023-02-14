using System;
using System.Net;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using Weather.Models;
using Weather.ViewModels;

namespace Weather;

public partial class HomePage : ContentPage
{

    

    public HomePage()
    {
        InitializeComponent();
        
    }

    
   


    

    private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {

    }

    private void RefreshBTN_Clicked(object sender, EventArgs e)
    {
        RefreshBTN.RotateTo(180, 1000,Easing.Linear);
        RefreshBTN.RotateTo(0, 1000, Easing.Linear);
        
    }

    private async void ForeCastListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var item = ((ListView)sender).SelectedItem as Forecastday;
        await DisplayAlert("ForecastDay item is moon up", item.astro.is_moon_up.ToString(), "ok");
    }
}

