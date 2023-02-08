using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Models
{
    public class _Weather : INotifyPropertyChanged
    {
        [JsonProperty("location")]
        public Location _location;
        public Location location
        {
            get => _location;
            set
            {
                if (_location == value)
                    return;
                _location = value;
                NotifyPropertyChanged(nameof(_location));
            }
        }
        

        [JsonProperty("current")]
        public Current current { get; set; }

        [JsonProperty("air_quality")]
        public Air_Quality air_quality { get; set; }
        

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
