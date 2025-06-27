using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia;
using System.Collections.Generic;

namespace CardGamesApp
{
    public partial class MemoGameWindow : Window
    {
        public MemoGameWindow()
        {
            InitializeComponent();
        }
        private string _player = string.Empty;
        private List<GameResult> _history = new List<GameResult>();
        private int _correctPosition;

        public MemoGameWindow(string player, List<GameResult> history) : this()
        {
            _player = player;
            _history = history;

            var rnd = new Random();
            _correctPosition = rnd.Next(1, 4);
            QuestionText.Text = $"Zapamietaj pozycje A: {_correctPosition}";
        }

        private void OnPlayerReadyClicked(object sender, RoutedEventArgs e)
        {
            var dialog = new Window
            {
                Width = 300,
                Height = 200,
                Title = "Wybierz pozycje A"
            };

            var panel = new StackPanel { Spacing = 10 };
            for (int i = 1; i <= 3; i++)
            {
                var btn = new Button { Content = $"Pozycja {i}" };
                int choice = i;
                btn.Click += (_, _) =>
                {
                    string result;
                    if (choice == _correctPosition)
                        result = "Poprawnie!";
                    else
                        result = $"Zla pozycja. Prawidlowa: {_correctPosition}";

                    ResultText.Text = result;
                    _history.Add(new GameResult(_player, "Memo", result.Contains("Poprawnie") ? "Wygral" : "Przegral"));
                    dialog.Close();
                };
                panel.Children.Add(btn);
            }

            dialog.Content = panel;
            dialog.ShowDialog(this);
        }

        private void OnCloseClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
