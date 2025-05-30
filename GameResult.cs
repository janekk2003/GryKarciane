using System;

namespace CardGamesApp
{
    public class GameResult
    {
        public string Player { get; set; }
        public string Game { get; set; }
        public string Result { get; set; }
        public DateTime Date { get; set; }

        public GameResult(string player, string game, string result)
        {
            Player = player;
            Game = game;
            Result = result;
            Date = DateTime.Now;
        }
    }
}
