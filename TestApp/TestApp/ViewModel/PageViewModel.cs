using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace TestApp.ViewModel
{
    public class PageViewModel : INotifyPropertyChanged
    {
        private string _theNote;
        private string _selectedNote;

        public PageViewModel()
        {
            EraseCommand = new Command(() => {
                if (AllNotes.Count > 0)
                {
                    AllNotes.Remove(TheNote);
                }
                this.TheNote = string.Empty;
            });

            SaveCommand = new Command(() => {
                AllNotes.Add(TheNote);
                TheNote = string.Empty;
            });

            SelectedNoteChangedCommand = new Command(async () => {
                var detailVM = new DetailPageViewModel(_selectedNote);
                var detailsPage = new DetailPage();
                detailsPage.BindingContext = detailVM;
                await Application.Current.MainPage.Navigation.PushAsync(detailsPage);
            });
            AllNotes = new ObservableCollection<string>();
        }
        public ObservableCollection<string> AllNotes { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        public string SelectedNote
        {
            get => _selectedNote;
            set
            {
                _selectedNote = value;
                var args = new PropertyChangedEventArgs(nameof(SelectedNote));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public string TheNote
        {
            get => _theNote;
            set
            {
                _theNote = value;
                var args = new PropertyChangedEventArgs(nameof(TheNote));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command SaveCommand { get; }
        public Command EraseCommand { get; }

        public Command SelectedNoteChangedCommand { get; }
    }
}
