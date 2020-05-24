using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using My_Bees_Diary.Services;
using My_Bees_Diary.Views;
using SQLite;

namespace My_Bees_Diary
{
    public partial class App : Application
    {
        private SQLiteConnection db;

        public App(string dbPath)
        {
            db = new SQLiteConnection(dbPath);

            InitializeComponent();

             MainPage = new NavigationPage(new Page1(dbPath));
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
