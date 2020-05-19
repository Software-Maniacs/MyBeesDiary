using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using My_Bees_Diary.Services;
using My_Bees_Diary.Views;
using My_Bees_Diary.Services.Repositories;

namespace My_Bees_Diary
{
    public partial class App : Application
    {
        public App(string dbPath)
        {
            InitializeComponent();

            MainPage = new MainPage();
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
