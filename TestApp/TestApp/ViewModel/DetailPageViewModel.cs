using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace TestApp.ViewModel
{
    public class DetailPageViewModel : INotifyPropertyChanged
    {
        public DetailPageViewModel(string textNote)
        {
            TextNote = textNote;
            BackCommand = new Command(async () => 
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            });
        }
        private string _TextNote;
        public string TextNote
        {
            get => _TextNote;
            set
            {
                _TextNote = value;
                var args = new PropertyChangedEventArgs(nameof(TextNote));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Command BackCommand { get; }
    }
}
