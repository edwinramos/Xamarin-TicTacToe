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
        const string dbPath = "TicTacToe.db";
        private const string serviceUri = @"http://tictactoexamarin.azurewebsites.net";

        public AzureClient()
        {
            this._client = new MobileServiceClient(serviceUri);
            var store = new MobileServiceSQLiteStore(dbPath);
            store.DefineTable<Score>();
            this._client.SyncContext.InitializeAsync(store);
            this._table = _client.GetSyncTable<Score>();
        }

        public async Task<IEnumerable<Score>> GetScores()
        {
            var empty = new Score[0];
            try
            {
                if (Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
                    await SyncAsync();

                return await this._table.ToEnumerableAsync();
            }
            catch (Exception ex)
            {
                return empty;
            }
        }

        public async void AddScore(Score score)
        {
            await this._table.InsertAsync(score);
            await this._table.MobileServiceClient.SyncContext.PushAsync();
        }

        public async Task SyncAsync()
        {
            IReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;
            try
            {
                await this._client.SyncContext.PushAsync();

                await this._table.PullAsync("allScores", _table.CreateQuery());
            }
            catch (MobileServicePushFailedException pushEx)
            {
                if (pushEx.PushResult != null)
                    syncErrors = pushEx.PushResult.Errors;
            }
        }

        public async Task CleanData()
        {
            await this._table.PurgeAsync("allScores", _table.CreateQuery(), new System.Threading.CancellationToken());
        }
    }
}
