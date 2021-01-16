using MvvmWithCSharp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmWithCSharp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailedView : ContentPage
    {
        private Label _title;
        private Label _note;
        private Label _timeStamp;
        private Button _backButton;
        public DetailedView()
        {
            _title = new Label
            {
                Text = "Details",
                Margin = new Thickness(10),
                HorizontalTextAlignment=TextAlignment.Center
            };

            _note = new Label { 
                Margin = new Thickness(10)
            };
            _note.SetBinding(Label.TextProperty, "Note");

            _timeStamp = new Label { 
                Margin=new Thickness(10)
            };
            _timeStamp.SetBinding(Label.TextProperty, "TimeStamp");

            _backButton = new Button { 
                Text="Back",
                Margin=new Thickness(10)
            };
            _backButton.SetBinding(Button.CommandProperty, "BackCommand");

            var gridView = new Grid {
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

            gridView.Children.Add(_title, 0, 0);
            Grid.SetColumnSpan(_title,2);

            gridView.Children.Add(_note, 0, 1);
            Grid.SetColumnSpan(_title, 2);

            gridView.Children.Add(_timeStamp, 0, 2);
            Grid.SetColumnSpan(_timeStamp, 2);

            gridView.Children.Add(_backButton, 0, 3);
            Grid.SetColumnSpan(_backButton, 2);

            Content = gridView;
        }
    }
}