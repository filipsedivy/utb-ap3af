using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DamePizzu.Model;
using Xamarin.Forms;

namespace DamePizzu.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            foods = GetFoods();
        }

        ObservableCollection<Food> foods;
        public ObservableCollection<Food> Foods
        {
            get { return foods; }
            set {
                foods = value;
                OnPropertyChanged(nameof(Foods));
            }
        }

        private Food selectedFood;
        public Food SelectedFood
        {
            get { return selectedFood; }
            set {
                selectedFood = value;
                OnPropertyChanged(nameof(SelectedFood));
            }
        }

        public ICommand SelectionCommand => new Command(DisplayFood);

        private void DisplayFood()
        {
            if (selectedFood != null)
            {
                var viewModel = new DetailViewModel { SelectedFood = selectedFood, Foods = foods, Position = foods.IndexOf(selectedFood) };
                var detailPage = new DetailPage { BindingContext = viewModel };

                var navigation = Application.Current.MainPage.Navigation;
                _ = navigation.PushAsync(detailPage, true);
            }
        }

        private ObservableCollection<Food> GetFoods()
        {
            return new ObservableCollection<Food>
            {
                new Food {
                    Name = "Šunková",
                    Price = 140,
                    Image = "https://utb.filipsedivy.cz/ap3af/pizza/photos/sunkova.png",
                    Description = "sugo, mozzarella, šunka, kukuřice, cibule, niva"
                },

                new Food {
                    Name = "Sýrová",
                    Price = 120,
                    Image = "https://utb.filipsedivy.cz/ap3af/pizza/photos/syr-mix.png",
                    Description = "sugo, mozzarella, kukuřice, špenát, brokolice, fazolky,cibule"
                },

                new Food {
                    Name = "Hawai",
                    Price = 135,
                    Image = "https://utb.filipsedivy.cz/ap3af/pizza/photos/hawai.png",
                    Description = "sugo, mozzarella, šunka, ananas"
                },

                new Food {
                    Name = "Mexická",
                    Price = 115,
                    Image = "https://utb.filipsedivy.cz/ap3af/pizza/photos/mexicka.png",
                    Description = "sugo, mozzarella, šunka, špenát, niva, olivy, česnek"
                },

                new Food {
                    Name = "BBQ",
                    Price = 115,
                    Image = "https://utb.filipsedivy.cz/ap3af/pizza/photos/bbq.png",
                    Description = "sugo, mozzarella, šunka, slanina, pikantní salám, kuřecí maso"
                },

                new Food {
                    Name = "Margherita",
                    Price = 115,
                    Image = "https://utb.filipsedivy.cz/ap3af/pizza/photos/margherita.png",
                    Description = "sugo, mozzarella, šunka, špenát, niva, olivy, česnek"
                },
            };
        }
    }
}
