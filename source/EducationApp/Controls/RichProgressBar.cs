using System;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace EducationApp.Controls
{
    public class RichProgressBar : SKCanvasView
    {
        public static BindableProperty PercentageProperty = BindableProperty.Create(nameof(Percentage), typeof(float),
            typeof(RichProgressBar), 0f, BindingMode.OneWay,
            validateValue: (_, value) => value != null,
            propertyChanged: OnPropertyChangedInvalidate);

        public float Percentage
        {
            get => (float)GetValue(PercentageProperty);
            set => SetValue(PercentageProperty, value);
        }

        public static BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(Percentage), typeof(float),
            typeof(RichProgressBar), 5f, BindingMode.OneWay,
            validateValue: (_, value) => value != null && (float)value >= 0,
            propertyChanged: OnPropertyChangedInvalidate);

        public float CornerRadius
        {
            get => (float)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static BindableProperty BarBackgroundColorProperty = BindableProperty.Create(nameof(BarBackgroundColor), typeof(Color),
            typeof(RichProgressBar), Color.White, BindingMode.OneWay,
            validateValue: (_, value) => value != null, propertyChanged: OnPropertyChangedInvalidate);

        public Color BarBackgroundColor
        {
            get => (Color)GetValue(BarBackgroundColorProperty);
            set => SetValue(BarBackgroundColorProperty, value);
        }

        public static BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(float),
            typeof(RichProgressBar), 12f, BindingMode.OneWay,
            validateValue: (_, value) => value != null && (float)value >= 0,
            propertyChanged: OnPropertyChangedInvalidate);

        public float FontSize
        {
            get => (float)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public static BindableProperty GradientStartColorProperty = BindableProperty.Create(nameof(GradientStartColor), typeof(Color),
            typeof(RichProgressBar), Color.Purple, BindingMode.OneWay,
            validateValue: (_, value) => value != null, propertyChanged: OnPropertyChangedInvalidate);

        public Color GradientStartColor
        {
            get => (Color)GetValue(GradientStartColorProperty);
            set => SetValue(GradientStartColorProperty, value);
        }

        public static BindableProperty GradientEndColorProperty = BindableProperty.Create(nameof(GradientEndColor), typeof(Color),
            typeof(RichProgressBar), Color.Blue, BindingMode.OneWay,
            validateValue: (_, value) => value != null, propertyChanged: OnPropertyChangedInvalidate);

        public Color GradientEndColor
        {
            get => (Color)GetValue(GradientEndColorProperty);
            set => SetValue(GradientEndColorProperty, value);
        }

        public static BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color),
            typeof(RichProgressBar), Color.Blue, BindingMode.OneWay,
            validateValue: (_, value) => value != null, propertyChanged: OnPropertyChangedInvalidate);

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public static BindableProperty AlternativeTextColorProperty = BindableProperty.Create(nameof(AlternativeTextColor), typeof(Color),
            typeof(RichProgressBar), Color.Blue, BindingMode.OneWay,
            validateValue: (_, value) => value != null, propertyChanged: OnPropertyChangedInvalidate);

        public Color AlternativeTextColor
        {
            get => (Color)GetValue(AlternativeTextColorProperty);
            set => SetValue(AlternativeTextColorProperty, value);
        }

        public static BindableProperty HasTextProperty = BindableProperty.Create(nameof(HasText), typeof(bool),
            typeof(RichProgressBar), false, BindingMode.OneWay,
            validateValue: (_, value) => value != null, propertyChanged: OnPropertyChangedInvalidate);

        public bool HasText
        {
            get => (bool)GetValue(HasTextProperty);
            set => SetValue(HasTextProperty, value);
        }




        private static void OnPropertyChangedInvalidate(BindableObject bindable, object oldvalue, object newvalue)
        {
            var control = (RichProgressBar)bindable;

            if (oldvalue != newvalue)
                control.InvalidateSurface();
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            var info = e.Info;
            var canvas = e.Surface.Canvas;

            float width = (float)Width;
            var scale = CanvasSize.Width / width;

            var percentage = Percentage;

            var cornerRadius = CornerRadius * scale;

            var textSize = FontSize * scale;

            var height = e.Info.Height;

            var str = percentage.ToString("0%");

            var percentageWidth = (int)Math.Floor(info.Width * percentage);

            canvas.Clear();

            var backgroundBar = new SKRoundRect(new SKRect(0, 0, info.Width, height), cornerRadius, cornerRadius);
            var progressBar = new SKRoundRect(new SKRect(0, 0, percentageWidth, height), cornerRadius, cornerRadius);

            var background = new SKPaint { Color = BarBackgroundColor.ToSKColor(), IsAntialias = true };
            canvas.DrawRoundRect(backgroundBar, background);

            using (var paint = new SKPaint() { IsAntialias = true })
            {
                float x = percentageWidth;
                float y = info.Height;
                var rect = new SKRect(0, 0, x, y);

                paint.Shader = SKShader.CreateLinearGradient(
                    new SKPoint(rect.Left, rect.Top),
                    new SKPoint(rect.Right, rect.Top),
                    new[]
                    {
                        GradientStartColor.ToSKColor(),
                        GradientEndColor.ToSKColor()
                    },
                    new float[] { 0, 1 },
                    SKShaderTileMode.Clamp);

                canvas.DrawRoundRect(progressBar, paint);
            }

            if(HasText)
            {
                var textPaint = new SKPaint { Color = TextColor.ToSKColor(), TextSize = textSize };

                var textBounds = new SKRect();

                textPaint.MeasureText(str, ref textBounds);

                var xText = percentageWidth / 2 - textBounds.MidX;
                if (xText < 0)
                {
                    xText = info.Width / 2 - textBounds.MidX;
                    textPaint.Color = AlternativeTextColor.ToSKColor();
                }

                var yText = info.Height / 2 - textBounds.MidY;

                canvas.DrawText(str, xText, yText, textPaint);
            }
        }
    }
}
