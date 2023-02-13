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
        
    }

    
   


    

    private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {

    }

    private void RefreshBTN_Clicked(object sender, EventArgs e)
    {
        
    }
}

