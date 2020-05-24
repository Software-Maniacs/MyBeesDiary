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
        private string _dbPath;
        private Entry apiaryName;
        private Entry apiaryNumber;
        private Picker apiaryType;
        //power
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
        private List<string> plantsInArea;
        private ICollection<AreaPlants> areaPlants;
        private Button add;
        private Button exit;

        public AddApiaryPage(string dbPath)
    {
            db = new SQLiteConnection(dbPath);
            _dbPath = dbPath;
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

            if (checkBox1.IsChecked)
            {
                plantsInArea.Add(label1.Text);
                db.CreateTable<AreaPlants>();
                AreaPlants lastPlant = db.Table<AreaPlants>().FirstOrDefault();
                int id;

                if (lastPlant == null)
                {
                    id = 1;
                }
                else
                {
                    id = lastPlant.PlantsID++;

                }

                AreaPlants plants = new AreaPlants()
                {
                    PlantsID = id,
                    PlantsList = plantsInArea
                };

                areaPlants.Add(plants);


            }
            stackLayout.Children.Add(checkBox1);
            stackLayout.Children.Add(label1);

            checkBox2 = new CheckBox();
            label2 = new Label { Text = "Бяла акация" };
            if (checkBox2.IsChecked)
            {
                plantsInArea.Add(label1.Text);
                db.CreateTable<AreaPlants>();
                AreaPlants lastPlant = db.Table<AreaPlants>().FirstOrDefault();
                int id;

                if (lastPlant == null)
                {
                    id = 1;
                }
                else
                {
                    id = lastPlant.PlantsID++;

                }

                AreaPlants plants = new AreaPlants()
                {
                    PlantsID = id,
                    PlantsList = plantsInArea
                };

                areaPlants.Add(plants);
            }
            stackLayout.Children.Add(checkBox2);
            stackLayout.Children.Add(label2);

            checkBox3 = new CheckBox();
            label3 = new Label { Text = "Бяла комуна" };
            if (checkBox3.IsChecked)
            {
                plantsInArea.Add(label1.Text);
                db.CreateTable<AreaPlants>();
                AreaPlants lastPlant = db.Table<AreaPlants>().FirstOrDefault();
                int id;

                if (lastPlant == null)
                {
                    id = 1;
                }
                else
                {
                    id = lastPlant.PlantsID++;

                }

                AreaPlants plants = new AreaPlants()
                {
                    PlantsID = id,
                    PlantsList = plantsInArea
                };

                areaPlants.Add(plants);


            }
            stackLayout.Children.Add(checkBox3);
            stackLayout.Children.Add(label3);

            checkBox4 = new CheckBox();
            label4 = new Label { Text = "Липа" };
            if (checkBox4.IsChecked)
            {
                plantsInArea.Add(label1.Text);
                db.CreateTable<AreaPlants>();
                AreaPlants lastPlant = db.Table<AreaPlants>().FirstOrDefault();
                int id;

                if (lastPlant == null)
                {
                    id = 1;
                }
                else
                {
                    id = lastPlant.PlantsID++;

                }

                AreaPlants plants = new AreaPlants()
                {
                    PlantsID = id,
                    PlantsList = plantsInArea
                };

                areaPlants.Add(plants);


            }
            stackLayout.Children.Add(checkBox4);
            stackLayout.Children.Add(label4);

            checkBox5 = new CheckBox();
            label5 = new Label { Text = "Рапица" };
            if (checkBox5.IsChecked)
            {
                plantsInArea.Add(label1.Text);
                db.CreateTable<AreaPlants>();
                AreaPlants lastPlant = db.Table<AreaPlants>().FirstOrDefault();
                int id;

                if (lastPlant == null)
                {
                    id = 1;
                }
                else
                {
                    id = lastPlant.PlantsID++;

                }

                AreaPlants plants = new AreaPlants()
                {
                    PlantsID = id,
                    PlantsList = plantsInArea
                };

                areaPlants.Add(plants);


            }
            stackLayout.Children.Add(checkBox5);
            stackLayout.Children.Add(label5);

            checkBox6 = new CheckBox();
            label6 = new Label { Text = "Слънчоглед" };
            if (checkBox6.IsChecked)
            {
                plantsInArea.Add(label1.Text);
                db.CreateTable<AreaPlants>();
                AreaPlants lastPlant = db.Table<AreaPlants>().FirstOrDefault();
                int id;

                if (lastPlant == null)
                {
                    id = 1;
                }
                else
                {
                    id = lastPlant.PlantsID++;

                }

                AreaPlants plants = new AreaPlants()
                {
                    PlantsID = id,
                    PlantsList = plantsInArea
                };

                areaPlants.Add(plants);


            }
            stackLayout.Children.Add(checkBox6);
            stackLayout.Children.Add(label6);

            checkBox7 = new CheckBox();
            label7 = new Label { Text = "Магарешки бодил" };
            if (checkBox7.IsChecked)
            {
                plantsInArea.Add(label1.Text);
                db.CreateTable<AreaPlants>();
                AreaPlants lastPlant = db.Table<AreaPlants>().FirstOrDefault();
                int id;

                if (lastPlant == null)
                {
                    id = 1;
                }
                else
                {
                    id = lastPlant.PlantsID++;

                }

                AreaPlants plants = new AreaPlants()
                {
                    PlantsID = id,
                    PlantsList = plantsInArea
                };

                areaPlants.Add(plants);


            }
            stackLayout.Children.Add(checkBox7);
            stackLayout.Children.Add(label7);

            checkBox8 = new CheckBox();
            label8 = new Label { Text = "Овощни дръвчета" };
            if (checkBox8.IsChecked)
            {
                plantsInArea.Add(label1.Text);
                db.CreateTable<AreaPlants>();
                AreaPlants lastPlant = db.Table<AreaPlants>().FirstOrDefault();
                int id;

                if (lastPlant == null)
                {
                    id = 1;
                }
                else
                {
                    id = lastPlant.PlantsID++;

                }

                AreaPlants plants = new AreaPlants()
                {
                    PlantsID = id,
                    PlantsList = plantsInArea
                };

                areaPlants.Add(plants);


            }
            stackLayout.Children.Add(checkBox8);
            stackLayout.Children.Add(label8);

            checkBox9 = new CheckBox();
            label9 = new Label { Text = "Билки" };
            if (checkBox9.IsChecked)
            {
                plantsInArea.Add(label1.Text);
                db.CreateTable<AreaPlants>();
                AreaPlants lastPlant = db.Table<AreaPlants>().FirstOrDefault();
                int id;

                if (lastPlant == null)
                {
                    id = 1;
                }
                else
                {
                    id = lastPlant.PlantsID++;

                }

                AreaPlants plants = new AreaPlants()
                {
                    PlantsID = id,
                    PlantsList = plantsInArea
                };

                areaPlants.Add(plants);


            }
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
            await Navigation.PushAsync(new ApiariesListView(_dbPath));
        }

        private async void AddApiary(object sender, EventArgs e)
        {
            db.CreateTable<Apiary>();

            Apiary lastApiary = db.Table<Apiary>().OrderByDescending(a => a.Date).FirstOrDefault();
            int id;

            if (lastApiary==null)
            {
                id = 1;
            }
            else
            {
                id = lastApiary.ID++;

            }

            Apiary apiary = new Apiary()
            {
                ID = id,
                Name = apiaryName.Text,
                Number=apiaryNumber.Text,
                Type = apiaryType.SelectedItem.ToString(),
                Production = decimal.Parse(apiaryProduction.Text),
                Location = apiaryLocation.Text,
                PlantsInArea=areaPlants
            };

            db.Insert(apiary);
            await DisplayAlert(null, "Пчелин " + apiaryNumber.Text + " е успешно добавен.", "ОК");
            await Navigation.PopAsync();
        }
    }
}