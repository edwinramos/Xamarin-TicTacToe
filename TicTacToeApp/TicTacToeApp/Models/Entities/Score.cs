using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeApp.Storage;

namespace TicTacToeApp.Models.Entities
{
    [DataTable("Scores")]
    public class Score : ObservableBaseObject//, IKeyObject
    {
        //public string Key { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("Player_1")]
        public string Player1 { get; set; }

        [JsonProperty("Player_2")]
        public string Player2 { get; set; }

        [JsonProperty("Score_Date")]
        public DateTime ScoreDate { get; set; }

        [JsonProperty("Match_Result")]
        public string MatchResult { get; set; }

        [JsonProperty("Winner_Name")]
        public string WinnerName { get; set; }

        [Version]
        public string Version { get; set; }
    }
}
