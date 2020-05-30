using My_Bees_Diary.Models.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace My_Bees_Diary.Views
{
    /// <summary>
    /// This page is the navigation page from GetBeehivesFromComparing.
    /// Selected beehives beehives are shown in table format.
    /// </summary>
    public class TableCompareBeehives : ContentPage
    {
        private SQLiteConnection db;
        /// <summary>
        /// /// When the page is initiated, it connects to the database through the database path.
        /// The paramtar 'beehive1' is the first selected object to compare.
        /// The paramtar 'beehive2' is the second selected object to compare.
        /// </summary>
        /// <param name="databasePath"></param>
        /// <param name="beehive1"></param>
        /// <param name="beehive2"></param>
        public TableCompareBeehives(string databasePath, Beehive beehive1, Beehive beehive2)
        {
            db = new SQLiteConnection(databasePath);
            StackLayout stackLayout = new StackLayout();
            stackLayout.BackgroundColor = Color.AliceBlue;
           
            StackLayout compareStack = new StackLayout();

            Label header1 = new Label
            {
                FontSize = 30,
                Text = "Данни за кошер 1:"
            };
            compareStack.Children.Add(header1);

            Label apiary = new Label
            {
                FontSize = 15,
                Text = $"Пчелин: {db.Query<Apiary>("select * from Apiary where id = " + beehive1.ApiaryID).First().ToString()}"
            };
            stackLayout.Children.Add(apiary);

            Label name1 = new Label
            {
                FontSize = 15,
                Text = $"Име: {beehive1.Name}"
            };
            compareStack.Children.Add(name1);

            Label number1 = new Label
            {
                FontSize = 15,
                Text = $"Номер: {beehive1.Number}"
            };
            compareStack.Children.Add(number1);

            Label type1 = new Label
            {
                FontSize = 15,
                Text = $"Тип кошер: {beehive1.TypeBeehive}"
            };
            compareStack.Children.Add(type1);

            Label type2 = new Label
            {
                FontSize = 15,
                Text = $"Тип пчели: {beehive1.TypeBees}"
            };
            compareStack.Children.Add(type2);

            Label stores = new Label
            {
                FontSize = 15,
                Text = $"Магазини: {beehive1.Stores}"
            };
            compareStack.Children.Add(stores);

            Label production1 = new Label
            {
                FontSize = 15,
                Text = $"Продукция: {beehive1.Production}"
            };
            compareStack.Children.Add(production1);

            Label honey = new Label
            {
                FontSize = 15,
                Text = $"Мед: {beehive1.Honey}"
            };
            compareStack.Children.Add(honey);

            Label wax = new Label
            {
                FontSize = 15,
                Text = $"Восък: {beehive1.Wax}"
            };
            compareStack.Children.Add(wax);

            Label propolis = new Label
            {
                FontSize = 15,
                Text = $"Прополис: {beehive1.Propolis}"
            };
            compareStack.Children.Add(propolis);

            Label pollen = new Label
            {
                FontSize = 15,
                Text = $"Цветен прашец: {beehive1.Pollen}"
            };
            compareStack.Children.Add(pollen);

            Label royalJelly = new Label
            {
                FontSize = 15,
                Text = $"Пчелно млечице: {beehive1.RoyalJelly}"
            };
            compareStack.Children.Add(royalJelly);

            Label poison = new Label
            {
                FontSize = 15,
                Text = $"Отрова: {beehive1.Poison}"
            };
            compareStack.Children.Add(poison);

            Label feedings = new Label
            {
                FontSize = 15,
                Text = $"Хранения: {beehive1.Feedings}"
            };
            compareStack.Children.Add(feedings);

            Label review = new Label
            {
                FontSize = 15,
                Text = $"Прегледи: {beehive1.Reviews}"
            };
            compareStack.Children.Add(review);

            Label treatments = new Label
            {
                FontSize = 15,
                Text = $"Третирания: {beehive1.Treatments}"
            };
            compareStack.Children.Add(treatments);

            Label header2 = new Label
            {
                FontSize = 30,
                Text = "Данни за кошер 2:"
            };
            compareStack.Children.Add(header2);

            Label apiary2 = new Label
            {
                FontSize = 15,
                Text = $"Пчелин: {db.Query<Apiary>("select * from Apiary where id = " + beehive2.ApiaryID).First().ToString()}"
            };
            compareStack.Children.Add(apiary2);

            Label name2 = new Label
            {
                FontSize = 15,
                Text = $"Име: {beehive2.Name}"
            };
            compareStack.Children.Add(name2);

            Label number2 = new Label
            {
                FontSize = 15,
                Text = $"Номер: {beehive2.Number}"
            };
            compareStack.Children.Add(number1);

            Label typeBeehive1 = new Label
            {
                FontSize = 15,
                Text = $"Тип кошер: {beehive2.TypeBeehive}"
            };
            compareStack.Children.Add(typeBeehive1);

            Label typeBee2 = new Label
            {
                FontSize = 15,
                Text = $"Тип пчели: {beehive2.TypeBees}"
            };
            compareStack.Children.Add(typeBee2);

            Label stores2 = new Label
            {
                FontSize = 15,
                Text = $"Магазини: {beehive2.Stores}"
            };
            compareStack.Children.Add(stores2);

            Label production2 = new Label
            {
                FontSize = 15,
                Text = $"Продукция: {beehive2.Production}"
            };
            compareStack.Children.Add(production2);

            Label honey2 = new Label
            {
                FontSize = 15,
                Text = $"Мед: {beehive2.Honey}"
            };
            compareStack.Children.Add(honey2);

            Label wax2 = new Label
            {
                FontSize = 15,
                Text = $"Восък: {beehive2.Wax}"
            };
            compareStack.Children.Add(wax2);

            Label propolis2 = new Label
            {
                FontSize = 15,
                Text = $"Прополис: {beehive2.Propolis}"
            };
            compareStack.Children.Add(propolis2);

            Label pollen2 = new Label
            {
                FontSize = 15,
                Text = $"Цветен прашец: {beehive2.Pollen}"
            };
            compareStack.Children.Add(pollen2);

            Label royalJelly2 = new Label
            {
                FontSize = 15,
                Text = $"Пчелно млечице: {beehive2.RoyalJelly}"
            };
            compareStack.Children.Add(royalJelly2);

            Label poison2 = new Label
            {
                FontSize = 15,
                Text = $"Отрова: {beehive2.Poison}"
            };
            compareStack.Children.Add(poison2);

            Label feedings2 = new Label
            {
                FontSize = 15,
                Text = $"Хранения: {beehive2.Feedings}"
            };
            compareStack.Children.Add(feedings2);

            Label review2 = new Label
            {
                FontSize = 15,
                Text = $"Прегледи: {beehive2.Reviews}"
            };
            compareStack.Children.Add(review2);

            Label treatments2 = new Label
            {
                FontSize = 15,
                Text = $"Третирания: {beehive2.Treatments}"
            };
            compareStack.Children.Add(treatments2);

            Button button = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                Text = "Назад"
            };
            button.Clicked += ExitIsClicked;
            compareStack.Children.Add(button);
            Content = new ScrollView
            {
                Content = compareStack
            };
        }

        private async void ExitIsClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}