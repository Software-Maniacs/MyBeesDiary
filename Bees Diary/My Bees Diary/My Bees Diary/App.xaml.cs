using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using My_Bees_Diary.Services;
using My_Bees_Diary.Views;
using SQLite;
using My_Bees_Diary.Models.Entities;

namespace My_Bees_Diary
{
    public partial class App : Application
    {
        public App(string dbPath)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartPage(dbPath));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
