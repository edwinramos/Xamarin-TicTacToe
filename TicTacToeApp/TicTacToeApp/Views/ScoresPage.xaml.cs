using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeApp.ViewModels;
using Xamarin.Forms;

namespace TicTacToeApp.Views
{
    public partial class ScoresPage : ContentPage
    {
        public ScoresPage()
        {
            InitializeComponent();
            BindingContext = new ScoreVM();
        }
    }
}
