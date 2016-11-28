using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TicTacToeApp.Models.Entities;
using TicTacToeApp.Models.Services;
using Xamarin.Forms;

namespace TicTacToeApp.ViewModels
{
    public class ScoreVM: ObservableBaseObject
    {
        public ObservableCollection<Score> ScoreList { get; set; }
        public Command RefreshCommand { get; set; }
        public Command LoadScoreCommand { get; set; }
        public Command CleanLocalDataCommand { get; set; }
        public AzureClient _client;

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; }
        }
        
        public ScoreVM()
        {
            RefreshCommand = new Command(() => Refresh());
            LoadScoreCommand = new Command(() => Load());
            CleanLocalDataCommand = new Command(() => CleanLocalData());
            ScoreList = new ObservableCollection<Score>();
            _client = new AzureClient();
        }

        async Task CleanLocalData()
        {
            await _client.CleanData();
        }

        private void Refresh()
        {
            throw new NotImplementedException();
        }

        async Task Load()
        {
            var result = await _client.GetScores();

            ScoreList.Clear();

            foreach (var item in result)
            {
                ScoreList.Add(item);
            }
            IsBusy = false;
        }
    }
}
