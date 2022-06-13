using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms.Internals;

namespace ValentineWish_Android
{
    public partial class MainPage
    {
        private static readonly Tuple<int, string>[][] ButtonText =
        {
            new[]
            {
                new Tuple<int, string>(6, "П"),
                new Tuple<int, string>(7, "о"),
                new Tuple<int, string>(8, "л"),
                new Tuple<int, string>(9, "у"),
                new Tuple<int, string>(10, "ч"),
                new Tuple<int, string>(11, "и"),
                new Tuple<int, string>(12, "т"),
                new Tuple<int, string>(13, "ь")
            },

            new[]
            {
                new Tuple<int, string>(5, "в"),
                new Tuple<int, string>(6, "а"),
                new Tuple<int, string>(7, "л"),
                new Tuple<int, string>(8, "е"),
                new Tuple<int, string>(9, "н"),
                new Tuple<int, string>(10, "т"),
                new Tuple<int, string>(11, "и"),
                new Tuple<int, string>(12, "н"),
                new Tuple<int, string>(13, "к"),
                new Tuple<int, string>(14, "у")
            }
        };

        private static readonly int[][] ButtonBorder =
        {
            new[] {5, 6, 7, 8, 9, 10, 11, 12, 13, 14},
            new[] {4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15},
            new[] {4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15},
            new[] {5, 6, 7, 8, 9, 10, 11, 12, 13, 14}
        };

        private static readonly Tuple<int, string>[][] Text =
        {
            new[]
            {
                new Tuple<int, string>(1, "F"),
                new Tuple<int, string>(2, "r"),
                new Tuple<int, string>(3, "o"),
                new Tuple<int, string>(4, "m"),
                new Tuple<int, string>(5, ":"),
                new Tuple<int, string>(6, "D"),
                new Tuple<int, string>(7, "a"),
                new Tuple<int, string>(8, "s"),
                new Tuple<int, string>(9, "h")
            },

            new[]
            {
                new Tuple<int, string>(4, "S"),
                new Tuple<int, string>(5, "p"),
                new Tuple<int, string>(6, "e"),
                new Tuple<int, string>(7, "c"),
                new Tuple<int, string>(8, "i"),
                new Tuple<int, string>(9, "a"),
                new Tuple<int, string>(10, "l"),
                new Tuple<int, string>(11, "l"),
                new Tuple<int, string>(12, "y"),
                new Tuple<int, string>(13, "F"),
                new Tuple<int, string>(14, "o"),
                new Tuple<int, string>(15, "r")
            },

            new[]
            {
                new Tuple<int, string>(2, "_"),
                new Tuple<int, string>(3, "."),
                new Tuple<int, string>(4, "p"),
                new Tuple<int, string>(5, "e"),
                new Tuple<int, string>(6, "r"),
                new Tuple<int, string>(7, "e"),
                new Tuple<int, string>(8, "s"),
                new Tuple<int, string>(9, "m"),
                new Tuple<int, string>(10, "e"),
                new Tuple<int, string>(11, "s"),
                new Tuple<int, string>(12, "h"),
                new Tuple<int, string>(13, "n"),
                new Tuple<int, string>(14, "i"),
                new Tuple<int, string>(15, "k"),
                new Tuple<int, string>(16, "."),
                new Tuple<int, string>(17, "_")
            }
        };

        private static readonly int[][] Heart =
        {
            new[] {5, 6, 7, 12, 13, 14},
            new[] {4, 5, 6, 7, 8, 11, 12, 13, 14, 15},
            new[] {3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16},
            new[] {2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17},
            new[] {2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17},
            new[] {2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17},
            new[] {3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16},
            new[] {4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15},
            new[] {5, 6, 7, 8, 9, 10, 11, 12, 13, 14},
            new[] {5, 6, 7, 8, 9, 10, 11, 12, 13, 14},
            new[] {6, 7, 8, 9, 10, 11, 12, 13},
            new[] {7, 8, 9, 10, 11, 12},
            new[] {8, 9, 10, 11},
            new[] {9, 10}
        };

        private static readonly int[][] HeartBorder =
        {
            new[] {5, 6, 7, 12, 13, 14},
            new[] {4, 5, 6, 7, 8, 11, 12, 13, 14, 15},
            new[] {3, 4, 8, 9, 10, 11, 15, 16},
            new[] {2, 3, 9, 10, 16, 17},
            new[] {1, 2, 17, 18},
            new[] {1, 2, 17, 18},
            new[] {1, 2, 17, 18},
            new[] {2, 3, 16, 17},
            new[] {3, 4, 15, 16},
            new[] {4, 5, 14, 15},
            new[] {4, 5, 14, 15},
            new[] {5, 6, 13, 14},
            new[] {6, 7, 12, 13},
            new[] {7, 8, 11, 12},
            new[] {8, 9, 10, 11},
            new[] {9, 10}
        };

        private static readonly Random Random = new();

        private readonly SKPaint _fillBrush = new()
        {
            IsAntialias = true,
            Style = SKPaintStyle.Fill
        };

        private readonly SKPaint _textBrush = new()
        {
            TextAlign = SKTextAlign.Center,
            Typeface = SKTypeface.FromFamilyName("Sans-Serif",
                SKFontStyleWeight.ExtraBlack,
                SKFontStyleWidth.Normal,
                SKFontStyleSlant.Upright)
        };

        private readonly int _xCount = 20;

        private bool _animate;
        private bool _animationActive;

        private Enum _animationState;
        private bool _buttonClicked;
        private int _canvasHeight;

        private int _canvasWidth;
        private float _cellHeight;

        private float _cellWidth;
        private int _marginTop;
        private bool _pageIsActive;

        private SKRect _rectangle;

        private Queue<Tuple<int, int>> _renderQueue;
        private float _xDelta;
        private int _yCount;
        private float _yDelta;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _pageIsActive = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _pageIsActive = false;
        }

        private void PaintTouch(object sender, SKTouchEventArgs e)
        {
            _buttonClicked = true;
            Paint.EnableTouchEvents = false;
#pragma warning disable CS4014
            DrawingLoop();
#pragma warning restore CS4014
        }

        private void OnPainting(object sender, SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;

            if (_buttonClicked)
            {
                canvas.Clear(SKColors.White);
                _buttonClicked = false;
            }

            if (_cellWidth != 0 && _cellHeight != 0)
            {
                if (_renderQueue.Count <= 0 && !_animationActive)
                {
                    _animationActive = true;
#pragma warning disable CS4014
                    AnimationLoop();
#pragma warning restore CS4014
                }

                for (var i = 0; i < Random.Next(1, 5); i++)
                {
                    if (_renderQueue.Count <= 0)
                        _renderQueue.Enqueue(new Tuple<int, int>(Random.Next(_xCount), Random.Next(_yCount)));

                    var (cellX, cellY) = _renderQueue.Dequeue();

                    if (_animationActive && cellY >= _marginTop - 1 && cellY < _marginTop - 1 + HeartBorder.Length &&
                        HeartBorder[cellY - (_marginTop - 1)].FirstOrDefault(v => v == cellX) != 0) continue;

                    _rectangle.Location = new SKPoint(_cellWidth * cellX - _xDelta, _cellHeight * cellY - _yDelta);
                    if (cellY >= _marginTop && cellY < _marginTop + Heart.Length &&
                        Heart[cellY - _marginTop].FirstOrDefault(v => v == cellX) != 0)
                        _fillBrush.Color = HeartColor();
                    else
                        _fillBrush.Color = BackColor();
                    canvas.DrawRect(_rectangle, _fillBrush);

                    Tuple<int, string> textCell = null;
                    if (cellY == 1)
                        textCell = Text[0].FirstOrDefault(v => v.Item1 == cellX);
                    else if (cellY == _yCount - 3)
                        textCell = Text[1].FirstOrDefault(v => v.Item1 == cellX);
                    else if (cellY == _yCount - 2)
                        textCell = Text[2].FirstOrDefault(v => v.Item1 == cellX);

                    _textBrush.Color = TextColor();
                    if (textCell != null)
                        canvas.DrawText(textCell.Item2, _cellWidth * (cellX + 0.5f) - _xDelta,
                            _cellHeight * (cellY + 0.75f) - _yDelta, _textBrush);
                }

                if (!_animate || !_animationActive) return;
                _animate = false;

                var pixmap = e.Surface.PeekPixels();
                switch (_animationState)
                {
                    case AnimationStates.Small:
                        _animationState = AnimationStates.Big;
                        DrawAnimation(canvas, pixmap, _marginTop - 1, true);
                        break;
                    default:
                        _animationState = AnimationStates.Small;
                        DrawAnimation(canvas, pixmap, _marginTop - 1);
                        break;
                }
            }
            else
            {
                InitializeCanvas(canvas, e);
            }
        }

        private async Task DrawingLoop()
        {
            while (_pageIsActive)
            {
                Paint.InvalidateSurface();

                await Task.Delay(TimeSpan.FromSeconds(1.0 / 30));
            }
        }

        private async Task AnimationLoop()
        {
            while (_pageIsActive && _animationActive)
            {
                _animate = true;

                await Task.Delay(TimeSpan.FromMilliseconds(750));
            }
        }

        private void InitializeCanvas(SKCanvas canvas, SKPaintSurfaceEventArgs e)
        {
            canvas.Clear(SKColors.White);

            _canvasWidth = e.Info.Width;
            _canvasHeight = e.Info.Height;

            _cellWidth = (int) Math.Ceiling((float) _canvasWidth / _xCount);
            _yCount = (int) Math.Ceiling(_canvasHeight / _cellWidth);
            _cellHeight = (int) Math.Ceiling((float) _canvasHeight / _yCount);
            _marginTop = (int) Math.Ceiling((_yCount - 14.0) / 2);
            _xDelta = Math.Abs((_canvasWidth - _cellWidth * _xCount) / 2);
            _yDelta = Math.Abs((_canvasHeight - _cellHeight * _yCount) / 2);

            _rectangle.Size = new SKSize(_cellWidth, _cellHeight);

            _textBrush.TextSize = 0.5f * _cellWidth * _textBrush.TextSize / _textBrush.MeasureText("S");

            var cellX = Random.Next(_xCount);
            var cellY = Random.Next(_yCount);

            _renderQueue = new Queue<Tuple<int, int>>(_xCount * _yCount);
            while (_renderQueue.Count < _xCount * _yCount)
            {
                while (_renderQueue.Contains(new Tuple<int, int>(cellX, cellY)))
                {
                    cellX = Random.Next(_xCount);
                    cellY = Random.Next(_yCount);
                }

                _renderQueue.Enqueue(new Tuple<int, int>(cellX, cellY));
            }

            DrawWelcomePage(canvas);
        }

        private void DrawWelcomePage(SKCanvas canvas)
        {
            canvas.Clear(SKColors.White);

            var textMarginTop = (_yCount - 2) / 2;
            var textBorderMarginTop = (_yCount - 4) / 2;

            foreach (var (cellX, cellY) in _renderQueue)
            {
                _rectangle.Location = new SKPoint(_cellWidth * cellX - _xDelta, _cellHeight * cellY - _yDelta);
                _fillBrush.Color = BackColor();
                canvas.DrawRect(_rectangle, _fillBrush);

                if (cellY < textBorderMarginTop || cellY >= textBorderMarginTop + ButtonBorder.Length ||
                    ButtonBorder[cellY - textBorderMarginTop].FirstOrDefault(v => v == cellX) == 0) continue;

                _rectangle.Location = new SKPoint(_cellWidth * cellX - _xDelta, _cellHeight * cellY - _yDelta);
                for (var i = 0; i < 10; i++)
                {
                    _fillBrush.Color = BackColor();
                    canvas.DrawRect(_rectangle, _fillBrush);
                }

                if (cellY < textMarginTop || cellY >= textMarginTop + ButtonText.Length ||
                    ButtonText[cellY - textMarginTop].FirstOrDefault(v => v.Item1 == cellX) == null) continue;

                _textBrush.Color = TextColor();
                canvas.DrawText(ButtonText[cellY - textMarginTop].First(v => v.Item1 == cellX).Item2,
                    _cellWidth * (cellX + 0.5f) - _xDelta, _cellHeight * (cellY + 0.75f) - _yDelta,
                    _textBrush);
            }
        }

        private void DrawAnimation(SKCanvas canvas, SKPixmap pixmap, int marginTop, bool heartColor = false)
        {
            for (var y = 0; y < HeartBorder.Length; y++)
            {
                var y1 = y;
                HeartBorder[y].ForEach(x =>
                {
                    _rectangle.Location =
                        new SKPoint(_cellWidth * x - _xDelta, _cellHeight * (y1 + marginTop) - _yDelta);

                    var i = Random.Next(Heart.Length);
                    var j = Heart[i][Random.Next(Heart[i].Length)];
                    // ReSharper disable once AccessToModifiedClosure
                    while (HeartBorder[i + 1].FirstOrDefault(v => v == j) != 0)
                    {
                        i = Random.Next(Heart.Length);
                        j = Heart[i][Random.Next(Heart[i].Length)];
                    }

                    _fillBrush.Color = heartColor
                        ? pixmap.GetPixelColor((int) Math.Ceiling((j < 10 ? j + 1 : j - 1) * _cellWidth - _xDelta),
                            (int) Math.Ceiling(((i < 8 ? i + 1 : i - 1) + _marginTop) * _cellHeight - _yDelta))
                        : pixmap.GetPixelColor((int) Math.Ceiling(Random.Next(_xCount) * _cellWidth - _xDelta),
                            (int) Math.Ceiling(Random.Next(2, marginTop - 3) * _cellHeight - _yDelta));

                    canvas.DrawRect(_rectangle, _fillBrush);
                });
            }
        }

        private static SKColor HeartColor()
        {
            return new SKColor(
                (byte) Random.Next(128 + 64, 255),
                (byte) Random.Next(0, 63),
                (byte) Random.Next(0, 63),
                (byte) Random.Next(70, 100));
        }

        private static SKColor BackColor()
        {
            return new SKColor(
                (byte) Random.Next(64, 255 - 64),
                (byte) Random.Next(128, 255),
                (byte) Random.Next(128, 255),
                (byte) Random.Next(55, 85));
        }

        private static SKColor TextColor()
        {
            return new SKColor(
                (byte) Random.Next(200, 255),
                (byte) Random.Next(0, 32),
                (byte) Random.Next(0, 32),
                255);
        }

        private enum AnimationStates
        {
            Small,
            Big
        }
    }
}