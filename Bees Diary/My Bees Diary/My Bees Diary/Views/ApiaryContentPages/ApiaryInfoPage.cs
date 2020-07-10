using My_Bees_Diary.Models.Entities;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace My_Bees_Diary.Views.ApiaryContentPages
{
    /// <summary>
    /// In this page the user can edit his/hers apiary notes. Edits can be realised by clicking the added buttons.
    /// </summary>
    class ApiaryInfoPage : ContentPage
    {
        private SQLiteConnection db;
        private Entry apiaryName;
        private Entry apiaryNumber;
        private Picker apiaryType;
        private Entry apiaryLocation;
        private Button update;
        private Button addBeehive;
        private Button delete;
        private Button exit;
        private Apiary _apiary;

        /// <summary>
        /// When the page is initiated, it connects to the database through the database path.
        /// Apiary is the selected object from apiaries list.
        /// </summary>
        /// <param name="apiary"></param>
        /// <param name="dbPath"></param>

        public ApiaryInfoPage(Apiary apiary, string dbPath)
        {
            _apiary = apiary;
            db = new SQLiteConnection(dbPath);
            StackLayout stackLayout = new StackLayout();

            Title = GetTitle();

            apiaryName = new Entry
            {
                Text = _apiary.Name
            };
            stackLayout.Children.Add(apiaryName);

            apiaryNumber = new Entry
            {
                Text = _apiary.Number
            };
            stackLayout.Children.Add(apiaryNumber);

            apiaryType = new Picker();
            apiaryType.Title = _apiary.Type;
            apiaryType.ItemsSource = new List<string>
                (
                new string[]
                {
                    "основен",
                    "мобилен",
                    "стационарен",
                    "помощен",
                    "за майко производство",
                    "за отводки"
                }
                );
            stackLayout.Children.Add(apiaryType);

            apiaryLocation = new Entry
            {
                Text = _apiary.Location
            };
            stackLayout.Children.Add(apiaryLocation);

            update = new Button()
            {
                Text = "Запази промените"
            };
            update.Clicked += Update;
            stackLayout.Children.Add(update);

            addBeehive = new Button()
            {
                Text = "Добави нов кошер"
            };
            addBeehive.Clicked += AddBeehive;
            stackLayout.Children.Add(addBeehive);

            delete = new Button()
            {
                Text = "Изтрий пчелина"
            };
            delete.Clicked += Delete;
            stackLayout.Children.Add(delete);

            exit = new Button()
            {
                Text = "Назад"
            };
            exit.Clicked += Exit;
            stackLayout.Children.Add(exit);

            ScrollView scrollView = new ScrollView();
            scrollView.Content = stackLayout;
            Content = scrollView;
        }

        private async void Exit(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Delete(object sender, EventArgs e)
        {
            List<Beehive> beehives = db.Query<Beehive>("select * from Beehive where ApiaryID = " + _apiary.ID);

            foreach (var beehive in beehives)
            {
                db.Delete(beehive);
            }
            db.Delete(_apiary);

            await DisplayAlert(null, "Пчелин " + apiaryName + "е изтрит.", "ОК");
            await Navigation.PushAsync(new ApiariesListView(db.DatabasePath));
        }

        private async void AddBeehive(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddBeehiveContentPage(db.DatabasePath, _apiary));
        }

        private async void Update(object sender, EventArgs e)
        {
            _apiary.Name = apiaryName.Text;
            _apiary.Number = apiaryNumber.Text;
            _apiary.Location = apiaryLocation.Text;

            if (apiaryType.SelectedItem != null)
            {
                _apiary.Type = apiaryType.SelectedItem.ToString();
            }

            db.Update(_apiary);

            await DisplayAlert(null, "Вие направихте промяна в пчелин " + apiaryName.Text + ".", "OK");
            await Navigation.PushAsync(new ApiariesListView(db.DatabasePath));
        }

        private string GetTemperature()
        {
            string result = "Няма поставена метеорологична станция.";

            using (var webClient = new WebClient())
            {
                string json = webClient.DownloadString("http://petar-petrov.com/apiary/api.php");
                ObservableCollection<WeatherStationTemperature> temperatures = JsonConvert.DeserializeObject<ObservableCollection<WeatherStationTemperature>>(json);

                int startIndex = temperatures.Count - 1;
                for (int i = startIndex; i >= 0; i--)
                {
                    if (_apiary.ID == temperatures[i].apiary_id)
                    {
                        result = temperatures[i].ToString();
                        break;
                    }
                }

                webClient.CancelAsync();
            }

            return result;
        }

        private string GetHumidity()
        {
            string result = "";
            using(var webClient = new WebClient())
            {
                string json = webClient.DownloadString("http://petar-petrov.com/apiary/api.php");
                ObservableCollection<WeatherStationHumidity> humidities = JsonConvert.DeserializeObject<ObservableCollection<WeatherStationHumidity>>(json);

                int startIndex = humidities.Count - 1;
                for (int i = startIndex; i >= 0; i--)
                {
                    if(_apiary.ID == humidities[i].apiary_id)
                    {
                        result = humidities[i].ToString();
                        break;
                    }
                }

                webClient.CancelAsync();
            }

            return result;
        }

        private string GetTitle()
        {
            string result = "Няма поставена метеорологична станция.";
            string getTemperature = GetTemperature();

            if(result != getTemperature)
            {
                result = "Температура: " + getTemperature + " Влажност: " + GetHumidity();
            }

            return result;
        }
    }
}
