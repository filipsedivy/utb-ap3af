using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using DamePizzu.Model;

namespace DamePizzu.ViewModel
{
    public class DetailViewModel : BaseViewModel
    {
        public DetailViewModel()
        {
        }

        ObservableCollection<Food> foods;
        public ObservableCollection<Food> Foods
        {
            get { return foods; }
            set
            {
                foods = value;
                OnPropertyChanged(nameof(Foods));
            }
        }

        private Food selectedFood;
        public Food SelectedFood
        {
            get { return selectedFood; }
            set
            {
                selectedFood = value;
                OnPropertyChanged(nameof(SelectedFood));
            }
        }

        private int position;
        public int Position
        {
            get
            {
                if (position != foods.IndexOf(selectedFood))
                    return foods.IndexOf(selectedFood);

                return position;
            }
            set
            {
                position = value;
                selectedFood = foods[position];

                OnPropertyChanged(nameof(Foods));
                OnPropertyChanged(nameof(SelectedFood));
            }
        }

        public ICommand OrderCommand => new Command(DisplayOrder);

        private void DisplayOrder()
        {
            if (selectedFood != null)
            {
                var viewModel = new OrderViewModel { SelectedFood = selectedFood };
                var orderPage = new OrderPage { BindingContext = viewModel };

                var navigation = Application.Current.MainPage.Navigation;
                _ = navigation.PushAsync(orderPage, true);
            }
        }

        public ICommand ChangePositionCommand => new Command(ChangePosition);

        private void ChangePosition(object obj)
        {
            string direction = (string)obj;

            if (direction == "L")
            {
                if (position == 0)
                {
                    Position = foods.Count - 1;
                    return;
                }

                Position -= 1;
            }
            else if (direction == "R")
            {
                if (position == foods.Count - 1)
                {
                    Position = 0;
                    return;
                }

                Position += 1;
            }

        }

    }
}
