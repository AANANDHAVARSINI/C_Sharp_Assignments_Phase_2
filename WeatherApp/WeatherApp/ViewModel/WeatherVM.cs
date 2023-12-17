using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;
using WeatherApp.ViewModel.Commands;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        private string  query;

        public ObservableCollection <City> Cities { get; set; }
        public string  Query
        {
            get { return query; }
            set 
            { 
                query = value;
                OnPropertyChanged("query");
            }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set 
            { 
                selectedCity = value;
                OnPropertyChanged("SelectedCity");
                GetCurrentCondition();
            }
        }

        private CurrentConditions currenConditions;

        public CurrentConditions CurrentConditions
        {
            get { return currenConditions; }
            set 
            { 
                currenConditions = value;
                OnPropertyChanged("CurrentConditions");
            }
        }
        public async void GetCurrentCondition()
        {
            Query = string.Empty;
            Cities.Clear();
            CurrentConditions = await AccuWeatherHelper.GetCurrentConditions(SelectedCity.Key);
        }

        public SearchCommand SearchCommand { get; set; }
        public WeatherVM()
        {
            if(DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                SelectedCity = new City
                {
                    LocalizedName = "NewYork"
                };
                CurrentConditions = new CurrentConditions
                {
                    WeatherText = "Rainy",
                    Temperature = new Temperature
                    {
                        Metric = new Units
                        {
                            Value = "21"
                        }
                    }
                };
            }
            SearchCommand = new SearchCommand(this);
            Cities = new ObservableCollection<City>();
        }
        public async void MakeQuery()
        {
            var cities = await AccuWeatherHelper.GetCities(query);
            Cities.Clear();
            foreach(City city in cities)
            {
                Cities.Add(city);
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
