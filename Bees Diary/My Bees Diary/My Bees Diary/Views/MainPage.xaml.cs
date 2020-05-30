using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using My_Bees_Diary.Models.Entities;
using My_Bees_Diary.Views.NoteContentPages;
//using My_Bees_Diary.Views.Notes;

namespace My_Bees_Diary.Views
{
    public partial class MainPage : MasterDetailPage
    {
        public List<MainPageItem> mainPageItems { get; set; }
        private SQLiteConnection db;
        private string _dbPath;


        public MainPage(string dbPath)
        {
            InitializeComponent();

            db = new SQLiteConnection(dbPath);
            _dbPath = dbPath;


            mainPageItems = new List<MainPageItem>();
            mainPageItems.Add(new MainPageItem
            { Title = "Табло", IconSource = "scoreboard.png", TargetType = typeof(StartPage), args = new object[] { _dbPath } });
            mainPageItems.Add(new MainPageItem { Title = "Кошери", IconSource = "beehive.png", TargetType = typeof(GetBeehivesContentPage), args = new object[] { _dbPath } });
            mainPageItems.Add(new MainPageItem { Title = "Добави кошер", IconSource = "add.png", TargetType = typeof(AddBeehiveContentPage), args = new object[] { _dbPath } });
            mainPageItems.Add(new MainPageItem { Title = "Сравни кошер", IconSource = "compare.png", TargetType = typeof(GetBeehivesFromComparing), args = new object[] { _dbPath } });
            mainPageItems.Add(new MainPageItem { Title = "Пчелини", IconSource = "apiary.png", TargetType = typeof(ApiariesListView), args = new object[] { _dbPath } });
            mainPageItems.Add(new MainPageItem { Title = "Добави пчелин", IconSource = "add.png", TargetType = typeof(AddApiaryPage), args = new object[] { _dbPath } });
            mainPageItems.Add(new MainPageItem { Title = "Сравни пчелин", IconSource = "compare.png", TargetType = typeof(CompareTwoApiaries), args = new object[] { _dbPath } });
            mainPageItems.Add(new MainPageItem { Title = "Записки", IconSource = "notes.png", TargetType = typeof(NotePage), args = new object[] { _dbPath } });
            mainPageItems.Add(new MainPageItem { Title = "Добави записка", IconSource = "add.png", TargetType = typeof(AddNotePage), args = new object[] { _dbPath } });

            menuListView.ItemsSource = mainPageItems;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(StartPage), new object[] { _dbPath }));

            menuListView.ItemSelected += OnMenuItemSelected;
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MainPageItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page, item.args = new object[] { _dbPath }));
            IsPresented = false;

        }

        internal Task NavigateFromMenu(int id)
        {
            throw new NotImplementedException();
        }
    }
}