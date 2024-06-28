using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FrootyLoops.UserControls.WorkplaceContent
{
    public class TimeRuler : UserControl
    {
        private const double MajorTickHeight = 10;
        private const double MinorTickHeight = 5;
        private readonly Pen pen = new Pen(Brushes.Black, 1);
        private readonly Typeface typeface = new Typeface("Arial");

        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration", typeof(TimeSpan), typeof(TimeRuler), new FrameworkPropertyMetadata(TimeSpan.Zero, FrameworkPropertyMetadataOptions.AffectsRender));
        public static readonly DependencyProperty OldDurationProperty =
            DependencyProperty.Register("OldDuration", typeof(TimeSpan), typeof(TimeRuler), new FrameworkPropertyMetadata(TimeSpan.Zero, FrameworkPropertyMetadataOptions.AffectsRender));

        public TimeSpan Duration
        {
            get { return (TimeSpan)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }
        public TimeSpan OldDuration
        {
            get { return (TimeSpan)GetValue(OldDurationProperty); }
            set { SetValue(OldDurationProperty, value); }
        }
        public static double _scaleFactor = 1.0;
        public static double GlobalScaleFactor { get; set; } = 1.0;
        public double ScaleFactor 
        { 
            get  => _scaleFactor; 
            set { _scaleFactor = value; OnPropertyChanged("ScaleFactor"); } 
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public TimeRuler()
        {
            // Добавление обработчика событий MouseWheel
            MouseWheel += OnMouseWheel;
        }

        private void OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            OldDuration = Duration;
            // Изменение длительности в зависимости от направления вращения колесика мыши
            Duration = Duration.Add(TimeSpan.FromSeconds((e.Delta > 0 ? 1 : -1)));
            if (Duration.TotalSeconds < 0)
            {
                Duration = TimeSpan.Zero;
            }
            ScaleFactor *= Math.Round(Duration.TotalSeconds / OldDuration.TotalSeconds,5,MidpointRounding.ToEven);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            double width = ActualWidth;
            double height = ActualHeight;

            int tickIndex = 0;
            for (double x = 0; x < width; x += 10 * ScaleFactor)
            {
                double tickHeight = tickIndex % 5 == 0 ? MajorTickHeight : MinorTickHeight;
                drawingContext.DrawLine(pen, new Point(x, height), new Point(x, height - tickHeight));

                if (tickIndex % 5 == 0)
                {
                    double time = tickIndex * 5 / ScaleFactor; // 5 seconds per major tick
                    FormattedText text = new FormattedText($"{time:0.0}s", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, typeface, 12, Brushes.Black);
                    if (x + text.Width < width)
                    {
                        drawingContext.DrawText(text, new Point(x, height - tickHeight - text.Height));
                    }
                }
                tickIndex++;
            }
        }
    }
}