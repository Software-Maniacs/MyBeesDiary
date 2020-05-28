using Microsoft.Data.Sqlite;
using My_Bees_Diary.Models.Entities;
using My_Bees_Diary.Services.Repositories;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace My_Bees_Diary.Views
{
	public class CompareTwoApiaries : ContentPage
{
        private SQLiteConnection db;
        private Picker firstApiaryPicker;
        private Picker secondApiaryPicker;
        private Button done;
        private ListView listView;

        public CompareTwoApiaries(string dbPath)
        {
            db = new SQLiteConnection(dbPath);

            StackLayout stackLayout = new StackLayout();

            firstApiaryPicker = new Picker()
            {
                Title = "Изберете номера на първия пчелин"
            };

            IEnumerable<string> allApiariesNumbers = db.Table<Apiary>().Select(a => a.Number);
            firstApiaryPicker.ItemsSource = allApiariesNumbers.ToList();
            stackLayout.Children.Add(firstApiaryPicker);

           secondApiaryPicker = new Picker()
            {
                Title = "Изберете номера на втория пчелин"
            };

            IEnumerable<string> allApiariesNumbers2 = db.Table<Apiary>().Select(a => a.Number);
            secondApiaryPicker.ItemsSource = allApiariesNumbers2.ToList();
            stackLayout.Children.Add(secondApiaryPicker);

            done = new Button
            {
               Text="Готово"
            };
            done.Clicked += DoneButton_Clicked;
            stackLayout.Children.Add(done);

            Content = stackLayout;


        }

        private async void DoneButton_Clicked(object sender, EventArgs e)
        {
            string firstApiaryNumber = firstApiaryPicker.SelectedItem.ToString();
            string secondApiaryNumber = secondApiaryPicker.SelectedItem.ToString();

            if (firstApiaryNumber.Equals(secondApiaryNumber))
            {
                var message = DisplayAlert("Грешка", "Избрали сте един и същ пчелин за сравнение!", "Назад");
                if (message.Equals("Назад"))
                {
                    await Navigation.PushAsync(new CompareTwoApiaries(db.DatabasePath));
                }

            }
            else
            {
                Apiary firstSelectedApiary = (Apiary)db.Table<Apiary>().Select(a => a.Number.Equals(firstApiaryNumber));
                Apiary secondSelectedApiary = (Apiary)db.Table<Apiary>().Select(a => a.Number.Equals(secondApiaryNumber));

                listView = new ListView()
                {
                    ItemsSource = firstSelectedApiary.ToString(),

                    VerticalOptions = LayoutOptions.FillAndExpand
                };

            Content = new Grid
            {
                RowDefinitions = {
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = new GridLength (1, GridUnitType.Star) }
            },
                Children = {
                listView
            }
            };
        }

        }
    }
}