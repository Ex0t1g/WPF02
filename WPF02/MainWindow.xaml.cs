using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPF02;


public partial class MainWindow : Window
{
    private static readonly IReadOnlyList<Brush> brushes = new[] {
        Brushes.Red, Brushes.Blue, Brushes.Green, Brushes.Yellow,
    };

    private static readonly IReadOnlyList<Months> months = new Months[] {
        new Months ("Январь", 1000),
        new Months ("Февраль", 2000),
        new Months ("Март", 3000),
    };

    public MainWindow()
    {
        InitializeComponent();

        RebuildGrid();
    }

    private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        RebuildGrid();
    }

    private void RebuildGrid()
    {
        grid.ColumnDefinitions.Clear();
        grid.Children.Clear();

        int maxValue = months.Select(month => month.Value).Max();
        for (int i = 0; i < months.Count; i++)
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });

            Months month = months[i];

            Rectangle rectangle = new Rectangle();
            rectangle.Fill = brushes[i % brushes.Count];
            rectangle.Width = 40;
            rectangle.Height = month.Value * topRow.ActualHeight / maxValue;
            rectangle.VerticalAlignment = VerticalAlignment.Bottom;
            Grid.SetRow(rectangle, 0);
            Grid.SetColumn(rectangle, i);
            grid.Children.Add(rectangle);

            TextBlock text = new TextBlock();
            text.Text = month.Name;
            text.Margin = new Thickness(5, 0, 5, 0);
            Grid.SetRow(text, 1);
            Grid.SetColumn(text, i);
            grid.Children.Add(text);
        }
    }
}