using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Editor
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Button pickImage;

            StackLayout panel = new StackLayout
            {
                Spacing = 1
            };
            panel.Children.Add(new Label
            {
                Text = "Select an image",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand

            });

            panel.Children.Add(pickImage = new Button
            {
                Text = "Click to select image",
                VerticalOptions = LayoutOptions.End,


            });

            pickImage.Clicked += async (sender, e) =>
            {
                pickImage.IsEnabled = true;
                Stream stream = await DependencyService.Get<IPicturePicker>().GetImageStreamAsync();
                if (stream != null)
                {
                    Content = new Image { Source = ImageSource.FromStream(() => stream) };
                }

            };
            this.Content = panel;



        }




    }
}
