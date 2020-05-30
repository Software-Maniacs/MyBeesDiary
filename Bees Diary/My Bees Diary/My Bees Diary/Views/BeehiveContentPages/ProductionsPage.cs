using My_Bees_Diary.Models.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace My_Bees_Diary.Views.BeehiveContentPages
{
    /// <summary>
    /// In this page the user can add his/her production
    /// </summary>
	public class ProductionsPage : ContentPage
{
        private Label _honeyLabel;
        private Label _waxLabel;
        private Label _propolisLabel;
        private Label _pollenLabel;
        private Label _royalJellyLabel;
        private Label _poisonLabel;
        private Entry _honeyEntry;
        private Entry _waxEntry;
        private Entry _propolisEntry;
        private Entry _pollenEntry;
        private Entry _royalJellyEntry;
        private Entry _poisonEntry;
        private Button _save;
        private Button _exit;
        private SQLiteConnection db;
        private Beehive _beehive;

        /// <summary>
        /// When the page is initiated, it connects to the database through the database path.
        /// Beehive is the selected object from beehives list.
        /// </summary>
        /// <param name="beehive"></param>
        /// <param name="dbPath"></param>

        public ProductionsPage(string dbPath, Beehive beehive)
    {
            _beehive = beehive;
            db = new SQLiteConnection(dbPath);
            StackLayout stackLayout = new StackLayout();

            _honeyLabel = new Label()
            {
                Text = "Мед"
            };
            stackLayout.Children.Add(_honeyLabel);

            _honeyEntry = new Entry()
            {
                Text = beehive.Honey.ToString()
            };
            stackLayout.Children.Add(_honeyEntry);

            _waxLabel = new Label()
            {
                Text = "Восък"
            };
            stackLayout.Children.Add(_waxLabel);

            _waxEntry = new Entry()
            {
                Text = beehive.Wax.ToString()
            };
            stackLayout.Children.Add(_waxEntry);

            _propolisLabel = new Label()
            {
                Text = "Прополис"
            };
            stackLayout.Children.Add(_propolisLabel);

            _propolisEntry = new Entry()
            {
                Text = beehive.Propolis.ToString()
            };
            stackLayout.Children.Add(_propolisEntry);

            _pollenLabel = new Label()
            {
                Text = "Цветен прашец"
            };
            stackLayout.Children.Add(_pollenLabel);

            _pollenEntry = new Entry()
            {
                Text = beehive.Pollen.ToString()
            };
            stackLayout.Children.Add(_pollenEntry);

            _royalJellyLabel = new Label()
            {
                Text = "Млечице"
            };
            stackLayout.Children.Add(_royalJellyLabel);

            _royalJellyEntry = new Entry()
            {
                Text = _beehive.RoyalJelly.ToString()
            };
            stackLayout.Children.Add(_royalJellyEntry);

            _poisonLabel = new Label()
            {
                Text = "Отрова"
            };
            stackLayout.Children.Add(_poisonLabel);

            _poisonEntry = new Entry()
            {
                Text = beehive.Poison.ToString()
            };
            stackLayout.Children.Add(_poisonEntry);

            _save = new Button()
            {
                Text = "Запази промените"
            };
            _save.Clicked += Save;
            stackLayout.Children.Add(_save);

            _exit = new Button()
            {
                Text = "Назад"
            };
            _exit.Clicked += Exit;
            stackLayout.Children.Add(_exit);

            ScrollView scrollView = new ScrollView();
            scrollView.Content = stackLayout;

            Content = scrollView;
    }

        private async void Exit(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Save(object sender, EventArgs e)
        {
            decimal honey = decimal.Parse(_honeyEntry.Text);
            decimal wax = decimal.Parse(_waxEntry.Text);
            decimal propolis = decimal.Parse(_propolisEntry.Text);
            decimal pollen = decimal.Parse(_pollenEntry.Text);
            decimal royalJelly = decimal.Parse(_royalJellyEntry.Text);
            decimal poison = decimal.Parse(_poisonEntry.Text);


            Apiary apiary = db.Query<Apiary>("select * from Apiary where id = " + _beehive.ApiaryID).First();

            apiary.Honey += honey;
            apiary.Wax += wax;
            apiary.Propolis += propolis;
            apiary.Pollen += pollen;
            apiary.RoyalJelly += royalJelly;
            apiary.Poison += poison;

            db.Update(apiary);

            _beehive.Honey += honey;
            _beehive.Wax += wax;
            _beehive.Propolis += propolis;
            _beehive.Pollen += pollen;
            _beehive.RoyalJelly += royalJelly;
            _beehive.Poison += poison;

            db.Update(_beehive);
            await DisplayAlert(null, "Промените са запазени.", "ОК");
            await Navigation.PopAsync();
        }
    }
}