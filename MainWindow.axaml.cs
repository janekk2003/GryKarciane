using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;

namespace CardGamesApp
{
    public partial class MainWindow : Window
    {
        private string _currentPlayer = null;
        private static List<GameResult> _history = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoginClicked(object sender, RoutedEventArgs e)
        {
            _currentPlayer = LoginTextBox.Text;
            WelcomeText.Text = $"Zalogowano jako {_currentPlayer}";
        }

        private void OnWarGameClicked(object sender, RoutedEventArgs e)
        {
            if (!EnsureLoggedIn()) return;
            new WarGameWindow(_currentPlayer, _history).ShowDialog(this);
        }

        private void OnMemoClicked(object sender, RoutedEventArgs e)
        {
            if (!EnsureLoggedIn()) return;
            new MemoGameWindow(_currentPlayer, _history).ShowDialog(this);
        }

        private void OnBlackjackClicked(object sender, RoutedEventArgs e)
        {
            if (!EnsureLoggedIn()) return;
            new BlackjackGameWindow(_currentPlayer, _history).ShowDialog(this);
        }

        private void OnHistoryClicked(object sender, RoutedEventArgs e)
        {
            new HistoryWindow(_history).ShowDialog(this);
        }

        private bool EnsureLoggedIn()
        {
            if (string.IsNullOrWhiteSpace(_currentPlayer))
            {
                WelcomeText.Text = "Najpierw sie zaloguj!";
                return false;
            }
            return true;
        }
    }
}
