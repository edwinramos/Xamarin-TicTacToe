using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TicTacToeApp.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            this.Padding = Device.OnPlatform(
                new Thickness(10, 20, 10, 10),//IOS
                new Thickness(10),//Android
                new Thickness(10));//WindowsPhone

            playButton.Clicked += PlayButton_Clicked;
        }

        private async void PlayButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BoardPage());
        }
    }
}
