using Microsoft.Data.Sqlite;
using My_Bees_Diary.Models.Entities;
using My_Bees_Diary.Services.Repositories;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace My_Bees_Diary.Views
{
	public class CompareTwoApiaries : ContentPage
{
        private SQLiteConnection db;
        private Picker firstApiaryPicker;
        private Picker secondApiaryPicker;
        private Button done;
        private StackLayout compareStack;

        public CompareTwoApiaries(string dbPath)
        {
            db = new SQLiteConnection(dbPath);

            StackLayout stackLayout = new StackLayout();

            firstApiaryPicker = new Picker()
            {
                Title = "Изберете номера на първия пчелин"
            };

            IEnumerable<string> allApiariesNumbers = db.Table<Apiary>().Select(a => a.Number);
            firstApiaryPicker.ItemsSource = allApiariesNumbers.ToList();
            stackLayout.Children.Add(firstApiaryPicker);

           secondApiaryPicker = new Picker()
            {
                Title = "Изберете номера на втория пчелин"
            };

            IEnumerable<string> allApiariesNumbers2 = db.Table<Apiary>().Select(a => a.Number);
            secondApiaryPicker.ItemsSource = allApiariesNumbers2.ToList();
            stackLayout.Children.Add(secondApiaryPicker);

            done = new Button
            {
               Text="Готово"
            };
            done.Clicked += DoneButton_Clicked;
            stackLayout.Children.Add(done);

            Content = stackLayout;


        }

        private async void DoneButton_Clicked(object sender, EventArgs e)
        {
            string firstApiaryNumber = firstApiaryPicker.SelectedItem.ToString();
            string secondApiaryNumber = secondApiaryPicker.SelectedItem.ToString();

            if (firstApiaryNumber.Equals(secondApiaryNumber))
            {
                var message = DisplayAlert("Грешка", "Избрали сте един и същ пчелин за сравнение!", "Назад");
                if (message.Equals("Назад"))
                {
                    await Navigation.PushAsync(new CompareTwoApiaries(db.DatabasePath));
                }

            }
            else
            {
                Apiary firstSelectedApiary = GetApiaryWithSameNumber(firstApiaryNumber);
                Apiary secondSelectedApiary = GetApiaryWithSameNumber(secondApiaryNumber);
                compareStack = new StackLayout { Spacing = 2 };
                
                Label header1 = new Label
                {
                    FontSize = 30,
                    Text = "Данни за пчелин 1:"
                };
                compareStack.Children.Add(header1);
                
                Label name1 = new Label
                {
                    FontSize = 15,
                    Text = $"Име: {firstSelectedApiary.Name}"
                };
                compareStack.Children.Add(name1);
               
                Label number1 = new Label
                {
                    FontSize = 15,
                    Text = $"Номер: {firstSelectedApiary.Number}"
                };
                compareStack.Children.Add(number1);

                Label type1 = new Label
                {
                    FontSize = 15,
                    Text = $"Тип: {firstSelectedApiary.Type}"
                };
                compareStack.Children.Add(type1);

                Label date1 = new Label
                {
                    FontSize = 15,
                    Text = $"Дата: {firstSelectedApiary.Date:dd/MM/yyyy HH:mm:ss}"
                };
                compareStack.Children.Add(date1);

                Label production1 = new Label
                {
                    FontSize = 15,
                    Text = $"Продукция: {firstSelectedApiary.Production}"
                };
                compareStack.Children.Add(production1);

                Label location1 = new Label
                {
                    FontSize = 15,
                    Text = $"Местоположение: {firstSelectedApiary.Location}"
                };
                compareStack.Children.Add(location1);
                if (firstSelectedApiary.Beehives == null)
                {
                    compareStack.Children.Add(new Label
                    {
                        FontSize = 15,
                        Text = $"Кошери: Няма въведени кошери."
                    });
                }
                else
                {
                    compareStack.Children.Add(new Label
                    {
                        FontSize = 15,
                        Text = "Кошери:"
                    });
                    foreach (var beehive in firstSelectedApiary.Beehives)
                    {
                        compareStack.Children.Add(new Label
                        {
                            Text = beehive.ToString(),
                            FontSize = 10
                        });
                    }
                }
                
                if (firstSelectedApiary.PlantsInArea == null)
                {
                    compareStack.Children.Add(new Label
                    {
                        FontSize = 15,
                        Text = $"Цветя в пчелина: Няма въведени цветя."
                    });
                }
                else
                {
                    compareStack.Children.Add(new Label
                    {
                        FontSize = 15,
                        Text = "Цветя в пчелина:"
                    });
                    foreach (var plant in firstSelectedApiary.PlantsInArea)
                    {
                        compareStack.Children.Add(new Label
                        {
                            Text = plant.ToString(),
                            FontSize = 10
                        });
                    }
                }

                Label header2 = new Label
                {
                    FontSize = 30,
                    Text = "Данни за пчелин 2:"
                };
                compareStack.Children.Add(header2);

                Label name2 = new Label
                {
                    FontSize = 15,
                    Text = $"Име: {secondSelectedApiary.Name}"
                };
                compareStack.Children.Add(name2);

                Label number2 = new Label
                {
                    FontSize = 15,
                    Text = $"Номер: {secondSelectedApiary.Number}"
                };
                compareStack.Children.Add(number2);

                Label type2 = new Label
                {
                    FontSize = 15,
                    Text = $"Тип: {secondSelectedApiary.Type}"
                };
                compareStack.Children.Add(type2);

                Label date2 = new Label
                {
                    FontSize = 15,
                    Text = $"Дата: {secondSelectedApiary.Date:dd/MM/yyyy HH:mm:ss}"
                };
                compareStack.Children.Add(date2);

                Label production2 = new Label
                {
                    FontSize = 15,
                    Text = $"Продукция: {secondSelectedApiary.Production}"
                };
                compareStack.Children.Add(production2);

                Label location2 = new Label
                {
                    FontSize = 15,
                    Text = $"Местоположение: {secondSelectedApiary.Location}"
                };
                compareStack.Children.Add(location2);
                if (secondSelectedApiary.Beehives == null)
                {
                    compareStack.Children.Add(new Label
                    {
                        FontSize = 15,
                        Text = $"Кошери: Няма въведени кошери."
                    });
                }
                else
                {
                    compareStack.Children.Add(new Label
                    {
                        FontSize = 15,
                        Text = "Кошери:"
                    });
                    foreach (var beehive in secondSelectedApiary.Beehives)
                    {
                        compareStack.Children.Add(new Label
                        {
                            Text = beehive.ToString(),
                            FontSize = 10
                        });
                    }
                }

                if (secondSelectedApiary.PlantsInArea == null)
                {
                    compareStack.Children.Add(new Label
                    {
                        FontSize = 15,
                        Text = $"Цветя в пчелина: Няма въведени цветя."
                    });
                }
                else
                {
                    compareStack.Children.Add(new Label
                    {
                        FontSize = 15,
                        Text = "Цветя в пчелина:"
                    });
                    foreach (var plant in secondSelectedApiary.PlantsInArea)
                    {
                        compareStack.Children.Add(new Label
                        {
                            Text = plant.ToString(),
                            FontSize = 10
                        });
                    }
                };
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
        }
        private Apiary GetApiaryWithSameNumber(string number)
        {
            foreach (var apiary in db.Table<Apiary>())
            {
                if (apiary.Number == number)
                {
                    return apiary;
                }
            }
            return null;
        }
        private async void ExitIsClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}