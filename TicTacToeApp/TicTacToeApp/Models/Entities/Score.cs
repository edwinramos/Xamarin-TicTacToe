using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeApp.Models.Entities
{
    public class Score
    {
        public int ScoreID { get; set; }
        public string Winner { get; set; }
        public string GameOverResult { get; set; }
    }
}
