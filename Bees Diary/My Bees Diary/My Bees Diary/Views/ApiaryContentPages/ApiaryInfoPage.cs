using My_Bees_Diary.Models.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace My_Bees_Diary.Views.ApiaryContentPages
{
    class ApiaryInfoPage : ContentPage
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
        private Button update;
        private Button addBeehive;
        private Button moveBeehiveInAnotherApiary;
        private Button moveBeehiveHereFromExistingApiary;
        private Button delete;
        private Button exit;
        private Apiary _apiary;

        public ApiaryInfoPage(Apiary apiary, string dbPath)
        {
            _apiary = apiary;
            db = new SQLiteConnection(dbPath);
            StackLayout stackLayout = new StackLayout();

            apiaryName = new Entry
            {
                Text = _apiary.Name
            };
            stackLayout.Children.Add(apiaryName);

            apiaryNumber = new Entry
            {
                Text = _apiary.Number
            };
            stackLayout.Children.Add(apiaryNumber);

            apiaryType = new Picker();
            apiaryType.Title = _apiary.Type;
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

            apiaryProduction = new Entry
            {
                Text = _apiary.Production.ToString()
            };
            stackLayout.Children.Add(apiaryProduction);

            apiaryLocation = new Entry
            {
                Text = _apiary.Location
            };
            stackLayout.Children.Add(apiaryLocation);

            checkBox1 = new CheckBox();
            label1 = new Label { Text = "Маргарит" };

            //тук излиза NullException, защото нямаме такава колона PlantsInArea във Apiary таблицата.
            if (_apiary.PlantsInArea.Contain("Маргарит"))
            {
                checkBox1.IsChecked = true;
            }
            stackLayout.Children.Add(checkBox1);
            stackLayout.Children.Add(label1);

            checkBox2 = new CheckBox();
            label2 = new Label { Text = "Бяла акация" };
            if (_apiary.PlantsInArea.Contain("Бяла акация"))
            {
                checkBox2.IsChecked = true;
            }
            stackLayout.Children.Add(checkBox2);
            stackLayout.Children.Add(label2);

            checkBox3 = new CheckBox();
            label3 = new Label { Text = "Бяла комуна" };
            if (_apiary.PlantsInArea.Contain("Бяла комуна"))
            {
                checkBox3.IsChecked = true;
            }
            stackLayout.Children.Add(checkBox3);
            stackLayout.Children.Add(label3);

            checkBox4 = new CheckBox();
            label4 = new Label { Text = "Липа" };
            if (_apiary.PlantsInArea.Contain("Липа"))
            {
                checkBox4.IsChecked = true;
            }
            stackLayout.Children.Add(checkBox4);
            stackLayout.Children.Add(label4);

            checkBox5 = new CheckBox();
            label5 = new Label { Text = "Рапица" };
            if (_apiary.PlantsInArea.Contain("Рапица"))
            {
                checkBox5.IsChecked = true;
            }
            stackLayout.Children.Add(checkBox5);
            stackLayout.Children.Add(label5);

            checkBox6 = new CheckBox();
            label6 = new Label { Text = "Слънчоглед" };
            if (_apiary.PlantsInArea.Contain("Слънчоглед"))
            {
                checkBox6.IsChecked = true;
            }
            stackLayout.Children.Add(checkBox6);
            stackLayout.Children.Add(label6);

            checkBox7 = new CheckBox();
            label7 = new Label { Text = "Магарешки бодил" };
            if (_apiary.PlantsInArea.Contain("Магарешки бодил"))
            {
                checkBox7.IsChecked = true;
            }
            stackLayout.Children.Add(checkBox7);
            stackLayout.Children.Add(label7);

            checkBox8 = new CheckBox();
            label8 = new Label { Text = "Овощни дръвчета" };
            if (_apiary.PlantsInArea.Contain("Овощни дръвчета"))
            {
                checkBox8.IsChecked = true;
            }
            stackLayout.Children.Add(checkBox8);
            stackLayout.Children.Add(label8);

            checkBox9 = new CheckBox();
            label9 = new Label { Text = "Билки" };
            if (_apiary.PlantsInArea.Contain("Билки"))
            {
                checkBox9.IsChecked = true;
            }
            stackLayout.Children.Add(checkBox9);
            stackLayout.Children.Add(label9);

            update = new Button()
            {
                Text = "Запази промените"
            };
            update.Clicked += Update;
            stackLayout.Children.Add(update);

            addBeehive = new Button()
            {
                Text = "Добави нов кошер"
            };
            addBeehive.Clicked += AddBeehive;
            stackLayout.Children.Add(addBeehive);

            moveBeehiveHereFromExistingApiary = new Button()
            {
                Text = "Премести тук кошер от друг пчелин"
            };
            moveBeehiveHereFromExistingApiary.Clicked += MoveBeehiveFromExistingApiary;
            stackLayout.Children.Add(moveBeehiveHereFromExistingApiary);

            moveBeehiveInAnotherApiary = new Button()
            {
                Text = "Премести кошер в друг пчелин"
            };
            moveBeehiveInAnotherApiary.Clicked += MoveBeehiveInAnotherApiary;
            stackLayout.Children.Add(moveBeehiveInAnotherApiary);

            delete = new Button()
            {
                Text = "Изтрий пчелина"
            };
            delete.Clicked += Delete;
            stackLayout.Children.Add(delete);

            exit = new Button()
            {
                Text = "Назад"
            };
            exit.Clicked += Exit;
            stackLayout.Children.Add(exit);

            ScrollView scrollView = new ScrollView();
            scrollView.Content = stackLayout;
            Content = scrollView;
        }

        private async void Exit(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Delete(object sender, EventArgs e)
        {
            db.Delete<Apiary>(_apiary);

            await DisplayAlert(null, "Пчелин " + apiaryName + "е изтрит.", "ОК");
            await Navigation.PushAsync(new ApiariesListView(db.DatabasePath));
        }

        private void MoveBeehiveInAnotherApiary(object sender, EventArgs e)
        {
            //With PopUp
        }

        private void MoveBeehiveFromExistingApiary(object sender, EventArgs e)
        {
            //With PopUp
        }

        private async void AddBeehive(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddBeehiveContentPage(db.DatabasePath, _apiary));
        }

        private async void Update(object sender, EventArgs e)
        {
            _apiary.Name = apiaryName.Text;
            _apiary.Number = apiaryNumber.Text;
            _apiary.Location = apiaryLocation.Text;
            _apiary.Production = decimal.Parse(apiaryProduction.Text);

            if (apiaryType.SelectedItem != null)
            {
                _apiary.Type = apiaryType.SelectedItem.ToString();
            }

            db.Update(_apiary);

            await DisplayAlert(null, "Вие направихте промяна в пчелин " + apiaryName.Text + ".", "OK");
            await Navigation.PushAsync(new ApiariesListView(db.DatabasePath));
        }
    }
}
