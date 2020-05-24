using My_Bees_Diary.Models.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace My_Bees_Diary.Views
{
	public class TableCompareBeehives : ContentPage
{
        private SQLiteConnection db;
    public TableCompareBeehives(string databasePath, Beehive beehive1, Beehive beehive2)
    {
            db = new SQLiteConnection(databasePath);
            StackLayout stackLayout = new StackLayout();

            Grid grid = new Grid()
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition(){Width = GridLength.Star},
                    new ColumnDefinition(){Width = GridLength.Star},
                    new ColumnDefinition(){Width = GridLength.Star}
                },
                Padding = 0,
                VerticalOptions = LayoutOptions.Center
            };

            grid.Children.Add(new Label()
            {
                Text = "Характеристика",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 0, 0);

            grid.Children.Add(new Label()
            {
                Text = beehive1.Name,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 1, 0);

            grid.Children.Add(new Label()
            {
                Text = beehive2.Name,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 2, 0);

            grid.Children.Add(new Label()
            {
                Text = "Номер",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 0, 1);

            grid.Children.Add(new Label()
            {
                Text = beehive1.Number,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 1, 1);

            grid.Children.Add(new Label()
            {
                Text = beehive2.Number,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 2, 1);

            grid.Children.Add(new Label()
            {
                Text = "Тип кошер",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 0, 2);

            grid.Children.Add(new Label()
            {
                Text = beehive1.TypeBeehive,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 1, 2);

            grid.Children.Add(new Label()
            {
                Text = beehive2.TypeBeehive,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 2, 2);

            grid.Children.Add(new Label()
            {
                Text = "Тип пчели",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 0, 3);

            grid.Children.Add(new Label()
            {
                Text = beehive1.TypeBees,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 1, 3);

            grid.Children.Add(new Label()
            {
                Text = beehive2.TypeBees,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 2, 3);

            grid.Children.Add(new Label()
            {
                Text = "Магазини",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 0, 4);

            grid.Children.Add(new Label()
            {
                Text = beehive1.Stores.ToString(),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 1, 4);

            grid.Children.Add(new Label()
            {
                Text = beehive2.Stores.ToString(),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 2, 4);

            grid.Children.Add(new Label()
            {
                Text = "Продукция",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 0, 5);

            grid.Children.Add(new Label()
            {
                Text = beehive1.Production.ToString(),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 1, 5);

            grid.Children.Add(new Label()
            {
                Text = beehive2.Production.ToString(),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 2, 5);

            grid.Children.Add(new Label()
            {
                Text = "Сила",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 0, 6);

            grid.Children.Add(new Label()
            {
                Text = beehive1.Power.ToString(),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 1, 6);

            grid.Children.Add(new Label()
            {
                Text = beehive2.Power.ToString(),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 2, 6);

            grid.Children.Add(new Label()
            {
                Text = "Хранения",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 0, 7);

            grid.Children.Add(new Label()
            {
                Text = beehive1.Feedings.ToString(),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 1, 7);

            grid.Children.Add(new Label()
            {
                Text = beehive2.Feedings.ToString(),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 2, 7);

            grid.Children.Add(new Label()
            {
                Text = "Прегледи",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 0, 8);

            grid.Children.Add(new Label()
            {
                Text = beehive1.Reviews.ToString(),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 1, 8);

            grid.Children.Add(new Label()
            {
                Text = beehive2.Reviews.ToString(),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 2, 8);

            grid.Children.Add(new Label()
            {
                Text = "Третирания",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 0, 9);

            grid.Children.Add(new Label()
            {
                Text = beehive1.Treatments.ToString(),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 1, 9);

            grid.Children.Add(new Label()
            {
                Text = beehive2.Treatments.ToString(),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 2, 9);

            stackLayout.Children.Add(grid);
            Content = stackLayout;
        }
}
}