using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeApp.Models.Entities;
using Xamarin.Forms;

namespace TicTacToeApp.Views
{
    public partial class SetNamesPage : ContentPage
    {
        private Player player1;
        private Player player2;

        public SetNamesPage()
        {
            InitializeComponent();
            startButton.Clicked += StartButton_Clicked;
        }

        private async void StartButton_Clicked(object sender, EventArgs e)
        {
            player1 = new Player
            {
                Name = player1Name.Text,
                Symbol = "X",

            };

            player2 = new Player
            {
                Name = player2Name.Text,
                Symbol = "O",
            };

            await Navigation.PushAsync(new BoardPage(player1, player2));
        }
    }
}
