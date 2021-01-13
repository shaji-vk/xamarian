using MvvmWithCSharp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace MvvmWithCSharp.ViewModel
{
    public class PageViewModel:INotifyPropertyChanged
    {
        private string _noteText;

        public PageViewModel()
        {
            SaveCommand = new Command(() => {
                Notes.Add(new NoteModel { Note = _noteText, TimeStamp = DateTime.Now });
            });
            DeleteCommand = new Command(() => {
                NoteModel noteModel = null;
                foreach(NoteModel noteModel1 in Notes)
                    if(string.Equals(noteModel1.Note,_noteText,StringComparison.CurrentCultureIgnoreCase))
                    {
                        noteModel = noteModel1;
                        break;
                    }

                if(noteModel != null) Notes.Remove(noteModel);
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string NoteText
        {
            get => _noteText;
            set
            {
                _noteText = value;
                PropertyChangedEventArgs propertyChangedEventArgs = new PropertyChangedEventArgs(nameof(NoteText));
                PropertyChanged?.Invoke(this, propertyChangedEventArgs);
            }
        }
        public ObservableCollection<NoteModel> Notes { get; }
        public Command SaveCommand { get; }
        public Command DeleteCommand { get; }
    }
}
