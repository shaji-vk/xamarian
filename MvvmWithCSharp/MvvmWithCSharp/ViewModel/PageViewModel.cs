using MvvmWithCSharp.Model;
using MvvmWithCSharp.Views;
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
        private NoteModel _noteModel;
        public PageViewModel()
        {
            SaveCommand = new Command(() => {
                Notes.Add(new NoteModel { Note = _noteText, TimeStamp = DateTime.Now });
                NoteText = null;
            });
            DeleteCommand = new Command(() => {
                NoteModel noteModel = null;
                if (NoteText==null || NoteText?.Equals("ALL", StringComparison.InvariantCultureIgnoreCase) == true)
                {
                    Notes.Clear();
                    return;
                }
                foreach(NoteModel noteModel1 in Notes)
                    if(string.Equals(noteModel1.Note,_noteText,StringComparison.CurrentCultureIgnoreCase))
                    {
                        noteModel = noteModel1;
                        break;
                    }

                if (noteModel != null) 
                { 
                    Notes.Remove(noteModel); 
                }
            });

            SelectedNoteChanged = new Command(async () => {
                if (_noteModel == null) return;

                DetailedViewModel detailedViewModel = new DetailedViewModel { 
                    Note = _noteModel.Note,
                    TimeStamp = _noteModel.TimeStamp
                };
                DetailedView detailedView = new DetailedView();
                detailedView.BindingContext = detailedViewModel;
                await Application.Current.MainPage.Navigation.PushAsync(detailedView);
                SelectedNote = null;
            });
            Notes = new ObservableCollection<NoteModel>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public NoteModel SelectedNote
        {
            get => _noteModel;
            set
            {
                _noteModel = value;
                PropertyChangedEventArgs propertyChangedEventArgs = new PropertyChangedEventArgs(nameof(SelectedNote));
                PropertyChanged?.Invoke(this, propertyChangedEventArgs);
            }
        }
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
        public Command SelectedNoteChanged { get; }
    }
}
