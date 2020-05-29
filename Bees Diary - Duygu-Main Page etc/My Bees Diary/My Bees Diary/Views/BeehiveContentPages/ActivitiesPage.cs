using My_Bees_Diary.Models.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace My_Bees_Diary.Views
{
	public class ActivitiesPage : ContentPage
{
        private SQLiteConnection db;
        private Beehive beehive;
        private Label _feedingLabel;
        private Entry _feedingEntry;
        private Label _reviewsLabel;
        private Entry _reviewsEntry;
        private Label _treatmentsLabel;
        private Entry _treatmentsEntry;
        private Button _up;
        private Button _save;
        private Button _exit;

    public ActivitiesPage(string dbPath, Beehive beehive)
    {
            db = new SQLiteConnection(dbPath);
            this.beehive = beehive;

            StackLayout stackLayout = new StackLayout();

            _feedingLabel = new Label()
            {
                Text = "Хранения"
            };
            stackLayout.Children.Add(_feedingLabel);

            _feedingEntry = new Entry()
            {
                Text = beehive.Feedings.ToString(),
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(_feedingEntry);

            _reviewsLabel = new Label()
            {
                Text = "Прегледи"
            };
            stackLayout.Children.Add(_reviewsLabel);

            _reviewsEntry = new Entry()
            {
                Text = beehive.Reviews.ToString(),
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(_reviewsEntry);

            _treatmentsLabel = new Label()
            {
                Text = "Третирания"
            };
            stackLayout.Children.Add(_treatmentsLabel);

            _treatmentsEntry = new Entry()
            {
                Text = beehive.Feedings.ToString(),
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(_treatmentsEntry);

            _up = new Button()
            {
                Text = "Увеличи стойността на всички с едно"
            };
            _up.Clicked += Up;
            stackLayout.Children.Add(_up);

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

            Content = stackLayout;
        }

        private async void Exit(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Save(object sender, EventArgs e)
        {
            beehive.Feedings = int.Parse(_feedingEntry.Text);
            beehive.Treatments = int.Parse(_treatmentsEntry.Text);
            beehive.Reviews = int.Parse(_reviewsEntry.Text);

            db.Update(beehive);
            await DisplayAlert(null, "Промените са запазени.", "ОК");
            await Navigation.PopAsync();
        }

        private void Up(object sender, EventArgs e)
        {
            _feedingEntry.Text = (int.Parse(_feedingEntry.Text) + 1).ToString();
            _reviewsEntry.Text = (int.Parse(_reviewsEntry.Text) + 1).ToString();
            _treatmentsEntry.Text = (int.Parse(_treatmentsEntry.Text) + 1).ToString();
        }
    }
}