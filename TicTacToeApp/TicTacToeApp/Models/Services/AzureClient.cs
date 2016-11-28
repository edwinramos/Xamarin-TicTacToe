using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeApp.Models.Entities;

namespace TicTacToeApp.Models.Services
{
    public class AzureClient
    {
        private IMobileServiceClient _client;
        private IMobileServiceSyncTable<Score> _table;
        const string dbPath = "TicTacToeDB";
        private const string serviceUri = "http://tictactoexamarin.azurewebsites.net/";

        public AzureClient()
        {
            _client = new MobileServiceClient(serviceUri);
            var store = new MobileServiceSQLiteStore(dbPath);
            store.DefineTable<Score>();
            _client.SyncContext.InitializeAsync(store);
            _table = _client.GetSyncTable<Score>();
        }

        public async Task<IEnumerable<Score>> GetScores()
        {
            var empty = new Score[0];
            try
            {
                if (Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
                    await SyncAsync();

                return await _table.ToEnumerableAsync();
            }
            catch (Exception ex)
            {
                return empty;
            }
        }

        public async void AddScore(Score score)
        {
            await _table.InsertAsync(score);
        }

        public async Task SyncAsync()
        {
            IReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;
            try
            {
                await _client.SyncContext.PushAsync();

                await _table.PullAsync("allScores", _table.CreateQuery());
            }
            catch (MobileServicePushFailedException pushEx)
            {
                if (pushEx.PushResult != null)
                    syncErrors = pushEx.PushResult.Errors;
            }
        }

        public async Task CleanData()
        {
            await _table.PurgeAsync("allScores", _table.CreateQuery(), new System.Threading.CancellationToken());
        }
    }
}
