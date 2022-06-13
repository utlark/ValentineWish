using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ValentineWish_Windows;

public partial class MainWindow
{
    private static readonly Random Random = new();

    private readonly int[][] _heart =
    {
        new[] {-1},
        new[] {-1},
        new[] {-1},
        new[] {5, 6, 7, 12, 13, 14},
        new[] {4, 5, 6, 7, 8, 11, 12, 13, 14, 15},
        new[] {3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16},
        new[] {2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17},
        new[] {2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17},
        new[] {2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17},
        new[] {3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16},
        new[] {4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15},
        new[] {5, 6, 7, 8, 9, 10, 11, 12, 13, 14},
        new[] {6, 7, 8, 9, 10, 11, 12, 13},
        new[] {7, 8, 9, 10, 11, 12},
        new[] {8, 9, 10, 11},
        new[] {9, 10},
        new[] {-1},
        new[] {-1},
        new[] {-1},
        new[] {-1}
    };

    private readonly List<Tuple<int, int>> _rendered = new();

    private readonly Tuple<int, char>[][] _text =
    {
        new[]
        {
            new Tuple<int, char>(0, 'F'),
            new Tuple<int, char>(1, 'r'),
            new Tuple<int, char>(2, 'o'),
            new Tuple<int, char>(3, 'm'),
            new Tuple<int, char>(4, ':'),
            new Tuple<int, char>(5, 'D'),
            new Tuple<int, char>(6, 'a'),
            new Tuple<int, char>(7, 's'),
            new Tuple<int, char>(8, 'h')
        },

        new[] {new Tuple<int, char>(-1, '0')},
        new[] {new Tuple<int, char>(-1, '0')},
        new[] {new Tuple<int, char>(-1, '0')},
        new[] {new Tuple<int, char>(-1, '0')},
        new[] {new Tuple<int, char>(-1, '0')},
        new[] {new Tuple<int, char>(-1, '0')},
        new[] {new Tuple<int, char>(-1, '0')},
        new[] {new Tuple<int, char>(-1, '0')},
        new[] {new Tuple<int, char>(-1, '0')},
        new[] {new Tuple<int, char>(-1, '0')},
        new[] {new Tuple<int, char>(-1, '0')},
        new[] {new Tuple<int, char>(-1, '0')},
        new[] {new Tuple<int, char>(-1, '0')},
        new[] {new Tuple<int, char>(-1, '0')},
        new[] {new Tuple<int, char>(-1, '0')},
        new[] {new Tuple<int, char>(-1, '0')},
        new[] {new Tuple<int, char>(-1, '0')},

        new[]
        {
            new Tuple<int, char>(4, 'S'),
            new Tuple<int, char>(5, 'p'),
            new Tuple<int, char>(6, 'e'),
            new Tuple<int, char>(7, 'c'),
            new Tuple<int, char>(8, 'i'),
            new Tuple<int, char>(9, 'a'),
            new Tuple<int, char>(10, 'l'),
            new Tuple<int, char>(11, 'l'),
            new Tuple<int, char>(12, 'y'),
            new Tuple<int, char>(13, 'F'),
            new Tuple<int, char>(14, 'o'),
            new Tuple<int, char>(15, 'r')
        },

        new[]
        {
            new Tuple<int, char>(2, '_'),
            new Tuple<int, char>(3, '.'),
            new Tuple<int, char>(4, 'p'),
            new Tuple<int, char>(5, 'e'),
            new Tuple<int, char>(6, 'r'),
            new Tuple<int, char>(7, 'e'),
            new Tuple<int, char>(8, 's'),
            new Tuple<int, char>(9, 'm'),
            new Tuple<int, char>(10, 'e'),
            new Tuple<int, char>(11, 's'),
            new Tuple<int, char>(12, 'h'),
            new Tuple<int, char>(13, 'n'),
            new Tuple<int, char>(14, 'i'),
            new Tuple<int, char>(15, 'k'),
            new Tuple<int, char>(16, '.'),
            new Tuple<int, char>(17, '_')
        }
    };

    public MainWindow()
    {
        InitializeComponent();
    }

    private void WindowLoaded(object sender, RoutedEventArgs e)
    {
        new Thread(Draw).Start();
    }

    private void Draw()
    {
        Thread.Sleep(1000);
        while (_rendered.Count < 400)
        {
            var x = Random.Next(20);
            var y = Random.Next(20);

            if (_rendered.Contains(new Tuple<int, int>(x, y))) continue;

            _rendered.Add(new Tuple<int, int>(x, y));

            Dispatcher.BeginInvoke((Action) delegate
            {
                var rectangle = new Rectangle
                {
                    Width = 25,
                    Height = 25,
                    Stroke = Brushes.Black,
                    StrokeThickness = 0.7,
                    Fill = _heart[y].FirstOrDefault(v => v == x) != 0
                        ? new SolidColorBrush(HeartColor())
                        : new SolidColorBrush(BackColor())
                };

                Canvas.Children.Add(rectangle);
                Canvas.SetTop(rectangle, 24 * y);
                Canvas.SetLeft(rectangle, 24 * x);

                var textCell = _text[y].FirstOrDefault(v => v.Item1 == x);
                if (textCell == null) return;

                var text = new TextBlock
                {
                    Text = textCell.Item2.ToString(),
                    TextAlignment = TextAlignment.Center,
                    FontWeight = FontWeights.ExtraBlack,
                    FontSize = 16,
                    Foreground = new SolidColorBrush(TextColor()),
                    Width = 25,
                    Height = 25
                };

                Canvas.Children.Add(text);
                Canvas.SetLeft(text, 24 * x);
                Canvas.SetTop(text, 24 * y);
            }, DispatcherPriority.Normal);

            Thread.Sleep(15);
        }
    }

    private static Color HeartColor()
    {
        return Color.FromArgb((byte) Random.Next(82, 164),
            (byte) Random.Next(128 + 64, 255),
            (byte) Random.Next(0, 63),
            (byte) Random.Next(0, 63));
    }

    private static Color BackColor()
    {
        return Color.FromArgb((byte) Random.Next(82, 164),
            (byte) Random.Next(64, 255 - 64),
            (byte) Random.Next(128, 255),
            (byte) Random.Next(128, 255));
    }

    private static Color TextColor()
    {
        return Color.FromArgb(255,
            (byte) Random.Next(128 + 64, 255),
            (byte) Random.Next(0, 63),
            (byte) Random.Next(0, 63));
    }
}