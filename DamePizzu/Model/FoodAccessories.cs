using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace DamePizzu.Model
{
    public class FoodAccessories : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; } = 0;

        public ICommand MinusQuantityCommand => new Command(DoMinusCommand);

        public void DoMinusCommand()
        {
            if (Quantity > 0)
            {
                Quantity--;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public ICommand PlusQuantityCommand => new Command(DoPlusCommand);

        public void DoPlusCommand()
        {
            Quantity++;
            OnPropertyChanged(nameof(Quantity));
        }
    }
}
