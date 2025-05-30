using Avalonia.Controls;
using System.Collections.Generic;

namespace CardGamesApp
{
    public partial class HistoryWindow : Window
    {
        public HistoryWindow(List<GameResult> history)
        {
            InitializeComponent();
            HistoryGrid.ItemsSource = history;
        }
    }
}
