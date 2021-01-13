using MvvmWithCSharp.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MvvmWithCSharp
{
    public partial class MainPage : ContentPage
    {
        Image xamagonImage;
        Editor noteEditor;
        Button saveButton, deleteButton;
        CollectionView collectionView;
        public MainPage()
        {
            BackgroundColor = Color.Blue;
            BindingContext = new PageViewModel();
            xamagonImage = new Image { 
                Source= "xamagon.png",
            };

            noteEditor = new Editor {
                BackgroundColor = Color.White,
                Margin = new Thickness(10),
                Placeholder="Enter note here..."
            };
            noteEditor.SetBinding(Editor.TextProperty, "NoteText");

            saveButton = new Button {
                Text = "Save",
                BackgroundColor = Color.Green,
                TextColor = Color.White,
                Margin = new Thickness(10)
            };
            saveButton.SetBinding(Button.CommandProperty, "SaveCommand");
            deleteButton = new Button { 
                Text="Delete",
                BackgroundColor=Color.Red,
                TextColor=Color.White,
                Margin = new Thickness(10)
            };
            deleteButton.SetBinding(Button.CommandProperty, "DeleteCommand");

            collectionView = new CollectionView {
                ItemTemplate = new NoteTemplate()
        };
            collectionView.SetBinding(CollectionView.ItemsSourceProperty, "Notes");

            var grid = new Grid {
                Margin = new Thickness(20, 40),
                ColumnDefinitions = {
                    new ColumnDefinition {Width = new GridLength(1,GridUnitType.Star ) },
                    new ColumnDefinition { Width = new GridLength(1,GridUnitType.Star)}
                },
                RowDefinitions = {
                   new RowDefinition { Height = new GridLength(1.0,GridUnitType.Star)},
                   new RowDefinition { Height = new GridLength(2.5,GridUnitType.Star)},
                   new RowDefinition { Height = new GridLength(1.0,GridUnitType.Star)},
                   new RowDefinition { Height = new GridLength(2.0,GridUnitType.Star)}
                }
            };

            grid.Children.Add(xamagonImage, 0, 0);
            Grid.SetColumnSpan(xamagonImage, 2);

            grid.Children.Add(noteEditor, 0, 1);
            Grid.SetColumnSpan(noteEditor, 2);

            grid.Children.Add(saveButton, 0, 2);
            grid.Children.Add(deleteButton, 1, 2);

            grid.Children.Add(collectionView, 0, 3);
            Grid.SetColumnSpan(collectionView, 2);
            Content = grid;
        }
    }
}
