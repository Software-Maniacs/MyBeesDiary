using Microsoft.EntityFrameworkCore.Metadata.Internal;
using My_Bees_Diary.Models.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace My_Bees_Diary.Views
{
    public class ApiariesListView : ContentPage
    {
        private SQLiteConnection db;
        private string _dbPath;
        private ListView apiaryListView;
        private Button item;
        private Button edit;
        private Button remove;

        /*select a.Number, a.Name, count(a.Beehives) a.Type, a.Location from Apiary as a*/

        public ApiariesListView(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            _dbPath = dbPath;
            StackLayout stackLayout = new StackLayout();

            apiaryListView = new ListView();
            apiaryListView.ItemsSource = db.Table<Apiary>();
            apiaryListView.BindingContext = db.Table<Apiary>().Select(a => a.Number);
            apiaryListView.BindingContext = db.Table<Apiary>().Select(a => a.Name);
            // apiaryListView.BindingContext = db.Table<Apiary>().Select(a => a.Beehives.Count());
            apiaryListView.BindingContext = db.Table<Apiary>().Select(a => a.Type);
            apiaryListView.BindingContext = db.Table<Apiary>().Select(a => a.Location);


            item = new Button
            {
                Text = "Добави пчелин"
            };
            stackLayout.Children.Add(item);
            
            item.Clicked += AddPageNavigation;

            edit = new Button
            {
                Text="Редактирай"
            };
            stackLayout.Children.Add(edit);
            edit.Clicked += EditPaveNavigation;

            remove = new Button
            {
               Text= "Изтрий"
            };

            stackLayout.Children.Add(remove);
            stackLayout.Children.Add(apiaryListView);

            remove.Clicked += RemoveObject;

            ScrollView scrollView = new ScrollView();
            scrollView.Content = stackLayout;
            Content = scrollView;
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
            else
            {
                // do nothing
            }

            //select name from Apiary

            //db.Query<Apiary>("select name from Apiary where name = ");
        }

        private void EditPaveNavigation(object sender, EventArgs e)
        {
            Apiary updatedApiary = db.FindWithQuery<Apiary>("select*from Apiary",apiaryListView,e);
            db.Update(updatedApiary);

        }

        private async void AddPageNavigation(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddApiaryPage(_dbPath));
        }
        
    }

    
}