using Microsoft.EntityFrameworkCore.Metadata.Internal;
using My_Bees_Diary.Models.Entities;
using My_Bees_Diary.Views.ApiaryContentPages;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace My_Bees_Diary.Views
{
    /// <summary>
    /// In this page we have list view of the all added apiaries. The user can make changes to each beehive by clicking on it.
    /// </summary>
    public class ApiariesListView : ContentPage
    {
        private SQLiteConnection db;
        private ListView apiaryListView;

        /// <remarks>
        /// When the page is initiated, it connects to the database through the database path.
        /// </remarks>
        /// <param name="dbPath">Path of the database.</param>

        public ApiariesListView(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            StackLayout stackLayout = new StackLayout();
            stackLayout.BackgroundColor = Color.AliceBlue;

            Label label = new Label()
            {
                Text = Title = "Моите пчелини"
            };

            apiaryListView = new ListView()
            {
                ItemsSource = db.Table<Apiary>().OrderBy(a => a.ID).ToList()
            };
            apiaryListView.ItemSelected += GetInfo;
            stackLayout.Children.Add(apiaryListView);

            ScrollView scrollView = new ScrollView();
            scrollView.Content = stackLayout;
            Content = scrollView;
        }

        private async void GetInfo(object sender, SelectedItemChangedEventArgs e)
        {
            int id = int.Parse(apiaryListView.SelectedItem.ToString().Split().ToArray()[0]);
            Apiary apiary = db.Query<Apiary>("select * from Apiary where id = " + id).First();
            await Navigation.PushAsync(new ApiaryInfoPage(apiary, db.DatabasePath));
        }

        private async void RemoveObject(object sender, EventArgs e)
        {
            Apiary removedApiary = (Apiary)(apiaryListView.SelectedItem);
 
            var question = await DisplayAlert(null, "Наистина ли искате да премахнете пчелин " + removedApiary.Name, "ДА", "НЕ");
            if (question.Equals("ДА"))
            {
                db.Delete(removedApiary);
                await DisplayAlert(null, "Пчелин " + removedApiary.Name + " е премахнат успешно", "ОК");
            }
        }
        
    }

    
}