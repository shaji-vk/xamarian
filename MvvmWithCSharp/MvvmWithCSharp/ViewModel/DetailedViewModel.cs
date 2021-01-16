using MvvmWithCSharp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace MvvmWithCSharp.ViewModel
{
    public class DetailedViewModel:INotifyPropertyChanged
    {
        private string _note;
        private DateTime _timeStamp;
        public DetailedViewModel()
        {
            BackCommand = new Command(async () => {
                await Application.Current.MainPage.Navigation.PopAsync();
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Note
        {
            get => _note;
            set
            {
                _note = value;
                PropertyChangedEventArgs propertyChangedEventArgs = new PropertyChangedEventArgs(nameof(Note));

                PropertyChanged?.Invoke(this, propertyChangedEventArgs);
            }
        }
        public DateTime TimeStamp
        {
            get => _timeStamp;
            set
            {
                _timeStamp = value;

                PropertyChangedEventArgs propertyChangedEventArgs = new PropertyChangedEventArgs(nameof(TimeStamp));

                PropertyChanged?.Invoke(this, propertyChangedEventArgs);
            }
        }

        public Command BackCommand { get; }
    }
}
