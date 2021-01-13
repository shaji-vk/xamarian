using MvvmWithCSharp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MvvmWithCSharp.ViewModel
{
    public class NoteTemplate:DataTemplate
    {
        public NoteTemplate() : base(LoadTemplate)
        {
            
        }
        static StackLayout LoadTemplate()
        {
            var textLabel = new Label();
            textLabel.SetBinding(Label.TextProperty, nameof(NoteModel.Note));

            var frame = new Frame { 
                VerticalOptions = LayoutOptions.Center,
                Content=textLabel
            };

            return new StackLayout { 
                Children = {frame},
                Padding = new Thickness(10)
            };

        }
    }
}
