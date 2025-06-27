using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Runtime;
using System.Collections.Generic;

namespace CardGamesApp
{
    public partial class BlackjackGameWindow : Window
    {
        public BlackjackGameWindow()
        {
            InitializeComponent();
        }
        private string _player = string.Empty;
        private List<GameResult> _history = new List<GameResult>();
        private int _playerScore = 0;
        private Random _rand = new();

        public BlackjackGameWindow(string player, List<GameResult> history) : this()
        {
            _player = player;
            _history = history;
        }

        private void OnDrawClicked(object sender, RoutedEventArgs e)
        {
            int card = _rand.Next(2, 12);
            _playerScore += card;
            InfoText.Text = $"Dobrales: {card}. Suma: {_playerScore}";

            if (_playerScore > 21)
            {
                ResultText.Text = "Przegrales, ponad 21!";
                _history.Add(new GameResult(_player, "Blackjack", "Przegral"));
            }
        }

        private void OnFinishClicked(object sender, RoutedEventArgs e)
        {
            if (_playerScore <= 21)
            {
                ResultText.Text = $"Zakonczyles z {_playerScore}, Wygrales!";
                _history.Add(new GameResult(_player, "Blackjack", "Wygral"));
            }
        }

        private void OnCloseClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
