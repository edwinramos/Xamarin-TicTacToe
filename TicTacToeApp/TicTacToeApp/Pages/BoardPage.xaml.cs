using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeApp.Models;
using Xamarin.Forms;

namespace TicTacToeApp.Pages
{
    public partial class BoardPage : ContentPage
    {
        private Player player1;
        private Player player2;
        private bool turn = true;

        public BoardPage()
        {           
            Initializer();
        }

        private void Initializer()
        {
            this.InitializeComponent();
            player1 = new Player
            {
                Name = "Player 1",
                Symbol = "X",
                Score = 0
            };
            player2 = new Player
            {
                Name = "Player 2",
                Symbol = "O",
                Score = 0
            }; ;

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
            TurnManager(button9);
            Check(button7, button8, button9);
            Check(button3, button6, button9);
            Check(button1, button5, button9);
            button9.IsEnabled = false;
        }

        private void Button8_Clicked(object sender, EventArgs e)
        {
            TurnManager(button8);
            Check(button7, button8, button9);
            Check(button2, button5, button8);
            button8.IsEnabled = false;
        }

        private void Button7_Clicked(object sender, EventArgs e)
        {
            TurnManager(button7);
            Check(button7, button8, button9);
            Check(button1, button4, button7);
            Check(button3, button5, button7);
            button7.IsEnabled = false;
        }

        private void Button6_Clicked(object sender, EventArgs e)
        {
            TurnManager(button6);
            Check(button4, button5, button6);
            Check(button3, button6, button9);
            button6.IsEnabled = false;
        }

        private void Button5_Clicked(object sender, EventArgs e)
        {
            TurnManager(button5);
            Check(button4, button5, button6);
            Check(button1, button5, button9);
            Check(button2, button5, button8);
            Check(button3, button5, button7);
            button5.IsEnabled = false;
        }

        private void Button4_Clicked(object sender, EventArgs e)
        {
            TurnManager(button4);
            Check(button4, button5, button6);
            Check(button1, button4, button7);
            button4.IsEnabled = false;
        }

        private void Button3_Clicked(object sender, EventArgs e)
        {
            TurnManager(button3);
            Check(button1, button2, button3);
            Check(button3, button5, button7);
            Check(button3, button6, button9);
            button3.IsEnabled = false;
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {

            TurnManager(button2);
            Check(button1, button2, button3);
            Check(button2, button5, button8);
            button2.IsEnabled = false;
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {

            TurnManager(button1);
            Check(button1, button2, button3);
            Check(button1, button4, button7);
            Check(button1, button5, button9);
            button1.IsEnabled = false;
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

                if (!this.turn)
                {
                    playerLabel.Text = player1.Name + " Wins!";
                }
                else
                {
                    playerLabel.Text = player2.Name + " Wins!";
                }
                DisabelGame();
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
