using Microsoft.EntityFrameworkCore.Metadata.Internal;
using My_Bees_Diary.Models.Entities;
//using Resources.Controls;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace My_Bees_Diary.Views
{
	public class AddApiaryPage : ContentPage
{
        private SQLiteConnection db;
        private Entry apiaryName;
        private Entry apiaryNumber;
        private Picker apiaryType;
        private Entry apiaryProduction;
        private Entry apiaryLocation;
        private CheckBox checkBox1;
        private Label label1;
        private CheckBox checkBox2;
        private Label label2;
        private CheckBox checkBox3;
        private Label label3;
        private CheckBox checkBox4;
        private Label label4;
        private CheckBox checkBox5;
        private Label label5;
        private CheckBox checkBox6;
        private Label label6;
        private CheckBox checkBox7;
        private Label label7;
        private CheckBox checkBox8;
        private Label label8;
        private CheckBox checkBox9;
        private Label label9;
        private List<Plant> plantsInArea;
        private Button add;
        private Button exit;
        private Dictionary<CheckBox, Label> checkBoxes;

        public AddApiaryPage(string dbPath)
    {
            db = new SQLiteConnection(dbPath);
            plantsInArea = new List<Plant>();

            StackLayout stackLayout = new StackLayout();

            apiaryName=new Entry
            {
                Placeholder = "Въведете име на пчелина",
                Keyboard = Keyboard.Text

            };
            stackLayout.Children.Add(apiaryName);

            apiaryNumber=new Entry
            {
                Placeholder = "Въведете номер на пчелина",
                Keyboard = Keyboard.Text

            };
            stackLayout.Children.Add(apiaryNumber);

            apiaryType = new Picker();
            apiaryType.Title = "Изберете вида на пчелина";
            apiaryType.ItemsSource = new List<string>
                (
                new string[]
                {
                    "основен",
                    "мобилен",
                    "стационарен",
                    "помощен",
                    "за майко производство",
                    "за отводки"
                }
                );
            stackLayout.Children.Add(apiaryType);

            apiaryProduction=new Entry
            {
                Placeholder = "Въведете произведеното количество продукция на пчелина",
                Keyboard = Keyboard.Text

            };
            stackLayout.Children.Add(apiaryProduction);

            apiaryLocation=new Entry
            {
                Placeholder = "Въведете местоположението на пчелина",
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(apiaryLocation);

            checkBox1 = new CheckBox();
            label1 = new Label { Text="Маргарит" };
            stackLayout.Children.Add(checkBox1);
            stackLayout.Children.Add(label1);

            checkBox2 = new CheckBox();
            label2 = new Label { Text = "Бяла акация" };
            stackLayout.Children.Add(checkBox2);
            stackLayout.Children.Add(label2);

            checkBox3 = new CheckBox();
            label3 = new Label { Text = "Бяла комуна" };
            stackLayout.Children.Add(checkBox3);
            stackLayout.Children.Add(label3);

            checkBox4 = new CheckBox();
            label4 = new Label { Text = "Липа" };
            stackLayout.Children.Add(checkBox4);
            stackLayout.Children.Add(label4);
            
            checkBox5 = new CheckBox();
            label5 = new Label { Text = "Рапица" };
            stackLayout.Children.Add(checkBox5);
            stackLayout.Children.Add(label5);
            
            checkBox6 = new CheckBox();
            label6 = new Label { Text = "Слънчоглед" };
            stackLayout.Children.Add(checkBox6);
            stackLayout.Children.Add(label6);
            
            checkBox7 = new CheckBox();
            label7 = new Label { Text = "Магарешки бодил" };
            stackLayout.Children.Add(checkBox7);
            stackLayout.Children.Add(label7);


            checkBox8 = new CheckBox();
            label8 = new Label { Text = "Овощни дръвчета" };
            stackLayout.Children.Add(checkBox8);
            stackLayout.Children.Add(label8);

            checkBox9 = new CheckBox();
            label9 = new Label { Text = "Билки" };
            stackLayout.Children.Add(checkBox9);
            stackLayout.Children.Add(label9);

            add = new Button();
            add.Text = "Добави пчелин";
            add.Clicked += AddApiary;
            stackLayout.Children.Add(add);

            exit = new Button();
            exit.Text = "Назад";
            exit.Clicked += ExitPage;
            stackLayout.Children.Add(exit);

            ScrollView scrollView = new ScrollView();
            scrollView.Content = stackLayout;
            Content = scrollView;
        }

        private async void ExitPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ApiariesListView(db.DatabasePath));
        }

        private async void AddApiary(object sender, EventArgs e)
        {
            //Добавяме checkBox-овете и съответните им label-и в един Dictionary, 
            //за да можем да проверим всеки checkbox дали е маркиран и, ако е, да
            //добавим името на цветето, написано отгоре, във PlantsInArea.
            checkBoxes = new Dictionary<CheckBox, Label>();
            checkBoxes.Add(checkBox1, label1);
            checkBoxes.Add(checkBox2, label2);
            checkBoxes.Add(checkBox3, label3);
            checkBoxes.Add(checkBox4, label4);
            checkBoxes.Add(checkBox5, label5);
            checkBoxes.Add(checkBox6, label6);
            checkBoxes.Add(checkBox7, label7);
            checkBoxes.Add(checkBox8, label8);
            checkBoxes.Add(checkBox9, label9);
            db.CreateTable<Apiary>();

            Apiary lastApiary = db.Table<Apiary>().OrderByDescending(a => a.Date).FirstOrDefault();
            int id;

            if (lastApiary == null)
            {
                id = 1;
            }
            else
            {
                id = lastApiary.ID++;
            }

            AddCheckedPlantsToPlantsArea(checkBoxes);
            Apiary apiary = new Apiary()
            {
                ID = id,
                Name = apiaryName.Text,
                Number = apiaryNumber.Text,
                Type = apiaryType.SelectedItem.ToString(),
                Production = decimal.Parse(apiaryProduction.Text),
                Location = apiaryLocation.Text,
                PlantsInArea = new AreaPlants
                {
                    PlantsID = id,
                    PlantsList = plantsInArea
                },
                Beehives = new List<Beehive>(),
                Date = DateTime.Now
            };

            db.Insert(apiary);
            await DisplayAlert(null, "Пчелин " + apiaryNumber.Text + " е успешно добавен.", "ОК");
            await Navigation.PopAsync();
        }

        private void AddPlantInPlantsArea(string plantName)
        {
            plantsInArea.Add(new Plant
            {
                PlantName = plantName
            });
        }
        private void AddCheckedPlantsToPlantsArea(Dictionary<CheckBox, Label> checkBoxes)
        {
           foreach(var checkBox in checkBoxes)
            {
                if (checkBox.Key.IsChecked)
                {
                    AddPlantInPlantsArea(checkBox.Value.Text);
                }
            }
        }
    }
}