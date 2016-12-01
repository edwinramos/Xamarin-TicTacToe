using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeApp.Models.Entities;
using TicTacToeApp.Models.Services;
using Xamarin.Forms;

namespace TicTacToeApp.Views
{
    public partial class BoardPage : ContentPage
    {
        private Player player1;
        private Player player2;
        private bool turn = true;
        public Score score;
        private AzureClient _client;

        public BoardPage(Player p1, Player p2)
        {
            this.player1 = p1;
            this.player2 = p2;
            _client = new AzureClient();
            Initializer();
        }

        private void Initializer()
        {
            this.InitializeComponent();


            playerLabel.Text = player1.Name;

            restartButton.Clicked += RestartButton_Clicked;

            button1.Clicked += Button1_Clicked;
            button2.Clicked += Button2_Clicked;
            button3.Clicked += Button3_Clicked;
            button4.Clicked += Button4_Clicked;
            button5.Clicked += Button5_Clicked;
            button6.Clicked += Button6_Clicked;
            button7.Clicked += Button7_Clicked;
            button8.Clicked += Button8_Clicked;
            button9.Clicked += Button9_Clicked;
        }

        private void RestartButton_Clicked(object sender, EventArgs e)
        {
            Initializer();
        }

        private void Button9_Clicked(object sender, EventArgs e)
        {
            button9.IsEnabled = false;
            TurnManager(button9);
            Check(button7, button8, button9);
            Check(button3, button6, button9);
            Check(button1, button5, button9);
        }

        private void Button8_Clicked(object sender, EventArgs e)
        {
            button8.IsEnabled = false;
            TurnManager(button8);
            Check(button7, button8, button9);
            Check(button2, button5, button8);
        }

        private void Button7_Clicked(object sender, EventArgs e)
        {
            button7.IsEnabled = false;
            TurnManager(button7);
            Check(button7, button8, button9);
            Check(button1, button4, button7);
            Check(button3, button5, button7);
        }

        private void Button6_Clicked(object sender, EventArgs e)
        {
            button6.IsEnabled = false;
            TurnManager(button6);
            Check(button4, button5, button6);
            Check(button3, button6, button9);
        }

        private void Button5_Clicked(object sender, EventArgs e)
        {
            button5.IsEnabled = false;
            TurnManager(button5);
            Check(button4, button5, button6);
            Check(button1, button5, button9);
            Check(button2, button5, button8);
            Check(button3, button5, button7);
        }

        private void Button4_Clicked(object sender, EventArgs e)
        {
            button4.IsEnabled = false;
            TurnManager(button4);
            Check(button4, button5, button6);
            Check(button1, button4, button7);
        }

        private void Button3_Clicked(object sender, EventArgs e)
        {
            button3.IsEnabled = false;
            TurnManager(button3);
            Check(button1, button2, button3);
            Check(button3, button5, button7);
            Check(button3, button6, button9);
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            button2.IsEnabled = false;
            TurnManager(button2);
            Check(button1, button2, button3);
            Check(button2, button5, button8);
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            button1.IsEnabled = false;
            TurnManager(button1);
            Check(button1, button2, button3);
            Check(button1, button4, button7);
            Check(button1, button5, button9);
        }

        private void DisabelGame()
        {
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            button4.IsEnabled = false;
            button5.IsEnabled = false;
            button6.IsEnabled = false;
            button7.IsEnabled = false;
            button8.IsEnabled = false;
            button9.IsEnabled = false;
        }

        private void Check(Button b1, Button b2, Button b3)
        {
            if (b1.Text == b2.Text && b1.Text == b3.Text)
            {
                b1.BackgroundColor = Color.Green;
                b1.TextColor = Color.Black;

                b2.BackgroundColor = Color.Green;
                b2.TextColor = Color.Black;

                b3.BackgroundColor = Color.Green;
                b3.TextColor = Color.Black;

                ResultManager();
                DisabelGame();

                Random rdn = new Random(DateTime.Now.Millisecond);
                score = new Score()
                {
                    Id = rdn.Next(12384748, 32384748).ToString(),
                    Player1 = player1.Name,
                    Player2 = player1.Name,
                    ScoreDate = DateTime.Now.Date,
                    MatchResult = playerLabel.Text,
                    WinnerName = "LOLA"
                };
                _client.AddScore(score);
                DisplayAlert("Congratulations!", score.MatchResult, "Return to Game");
            }
            //if (!button1.IsEnabled && !button2.IsEnabled && !button3.IsEnabled && !button4.IsEnabled && !button5.IsEnabled && !button6.IsEnabled && !button7.IsEnabled && !button8.IsEnabled && !button9.IsEnabled)
            //{
            //    playerLabel.Text = "Tied!";
            //    score = new Score()
            //    {
            //        Player1 = player1.Name,
            //        Player2 = player1.Name,
            //        ScoreDate = DateTime.Now.Date,
            //        MatchResult = playerLabel.Text
            //    };

            //    _client.AddScore(score);
            //    return;
            //}
            
        }

        private void ResultManager()
        {


            if (!this.turn)
            {
                playerLabel.Text = player1.Name + " Wins!";
            }
            else
            {
                playerLabel.Text = player2.Name + " Wins!";
            }
        }

        private void TurnManager(Button button)
        {
            if (this.turn)
            {
                button.Text = player1.Symbol;
                playerLabel.Text = player2.Name;
            }
            else
            {
                button.Text = player2.Symbol;
                playerLabel.Text = player1.Name;
            }
            this.turn = !this.turn;


        }
    }
}
