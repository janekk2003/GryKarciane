using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;

namespace CardGamesApp
{
    public partial class WarGameWindow : Window
    {
        private string _player;
        private List<GameResult> _history;

        public WarGameWindow(string player, List<GameResult> history)
        {
            InitializeComponent();
            _player = player;
            _history = new List<GameResult>();
            StatusText.Text = $"Witaj {_player}, zagrajmy w Wojne!";
        }

        private void OnPlayRoundClicked(object sender, RoutedEventArgs e)
        {
            var rnd = new Random();
            int playerCard = rnd.Next(2, 15); // 2–14 (A)
            int computerCard = rnd.Next(2, 15);

            string result;
            if (playerCard > computerCard)
                result = "Wygrales runde!";
            else if (playerCard < computerCard)
                result = "Przegrales runde!";
            else
                result = "Remis.";

            StatusText.Text = $"{_player}: {playerCard} vs Komputer: {computerCard} — {result}";
        }

        private void OnCloseClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
