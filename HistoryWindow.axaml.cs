using Avalonia.Controls;
using System.Collections.Generic;
using System;

namespace CardGamesApp
{
    public partial class HistoryWindow : Window
    {
        public HistoryWindow()
        {
            InitializeComponent();
        }
        public HistoryWindow(List<GameResult> history)
        {
            InitializeComponent();
            Console.WriteLine($"Liczba rekordów historii: {history.Count}");
            HistoryGrid.ItemsSource = history;
            HistoryGrid.UpdateLayout();
            //this.Content = HistoryGrid;
        }
    }
}
