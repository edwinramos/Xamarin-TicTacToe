using System;
using System.Collections.ObjectModel;

using TicTacToeApp.Models.Entities;
using Xamarin.Forms;

namespace TicTacToeApp.ViewModels
{
    public class ScoreVM
    {
        public ObservableCollection<Score> ScoreList { get; set; }
        public Command LoadScoreCommand { get; set; }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; }
        }
        
        public ScoreVM()
        {
            LoadScoreCommand = new Command(() => Load());
        }

        public void Load()
        {
            /*Connecto to Azure and Load here*/
            IsBusy = false;
        }
    }
}
