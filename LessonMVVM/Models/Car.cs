using LessonMVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LessonMVVM.Models
{
    public class Car : NotificationService
    {
        private string make;
        private string model;
        private string makeAndModel;

        [JsonPropertyName("make")]
        public string Make { get => make; set { make = value; OnPropertyChanged(); } }
        
        [JsonPropertyName("model")]
        public string Model { get => model; set { model = value; OnPropertyChanged(); } }

        [JsonPropertyName("makeAndModel")]
        public string MakeAndModel { get => Make + " " + Model; set { makeAndModel = value; OnPropertyChanged(); } } // for combobox

        public Car() { }

        public Car(string make, string model)
        {
            Make = make;
            Model = model;
        }
    }
}
