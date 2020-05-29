using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using My_Bees_Diary.Services;
using My_Bees_Diary.Views;
using SQLite;
using My_Bees_Diary.Models.Entities;
using My_Bees_Diary.Views.NoteContentPages;
using My_Bees_Diary.Views.ApiaryContentPages;

namespace My_Bees_Diary
{
    public partial class App : Application
    {
        Apiary apiary;
        public App(string dbPath)
        {
            InitializeComponent();

            MainPage = new MainPage(dbPath);
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
