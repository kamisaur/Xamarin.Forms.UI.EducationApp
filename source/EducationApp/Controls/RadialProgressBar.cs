using System;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace EducationApp.Controls
{
    public class RadialProgressBar : SKCanvasView
    {
        public static BindableProperty ProgressProperty = BindableProperty.Create(nameof(Progress), typeof(float),
            typeof(RadialProgressBar), 0f, BindingMode.OneWay,
            validateValue: (_, value) => value != null,
            propertyChanged: OnPropertyChangedInvalidate);

        public float Progress
        {
            get => (float)GetValue(ProgressProperty);
            set => SetValue(ProgressProperty, value);
        }
        
        public static BindableProperty ProgressThicknessProperty = BindableProperty.Create(nameof(Progress), typeof(float),
            typeof(RadialProgressBar), 1f, BindingMode.OneWay,
            validateValue: (_, value) => value != null,
            propertyChanged: OnPropertyChangedInvalidate);

        public float ProgressThickness
        {
            get => (float)GetValue(ProgressThicknessProperty);
            set => SetValue(ProgressThicknessProperty, value);
        }


        public static BindableProperty ProgressBackgroundColorProperty = BindableProperty.Create(nameof(ProgressBackgroundColor), typeof(Color),
            typeof(RadialProgressBar), Color.LightGray, BindingMode.OneWay,
            validateValue: (_, value) => value != null, propertyChanged: OnPropertyChangedInvalidate);

        public Color ProgressBackgroundColor
        {
            get => (Color)GetValue(ProgressBackgroundColorProperty);
            set => SetValue(ProgressBackgroundColorProperty, value);
        }


        public static BindableProperty ProgressColorProperty = BindableProperty.Create(nameof(ProgressBackgroundColor), typeof(Color),
            typeof(RadialProgressBar), Color.Green, BindingMode.OneWay,
            validateValue: (_, value) => value != null, propertyChanged: OnPropertyChangedInvalidate);

        public Color ProgressColor
        {
            get => (Color)GetValue(ProgressColorProperty);
            set => SetValue(ProgressColorProperty, value);
        }



        private static void OnPropertyChangedInvalidate(BindableObject bindable, object oldvalue, object newvalue)
        {
            var control = (RadialProgressBar)bindable;

            if (oldvalue != newvalue)
                control.InvalidateSurface();
        }



        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            var info = e.Info;
            var canvas = e.Surface.Canvas;

            float width = (float)Width;
            var scale = CanvasSize.Width / width;

            canvas.Clear();

            var progress = Progress * 360;
            var circleSize = (float)Math.Min(Width, Height) * scale;
            var circleRadius = (float)circleSize / 2;

            var strokeThickness = ProgressThickness * scale;
            // progressEdgeStyle


            var progressBackgroundPaint = new SKPaint
            {
                Color = ProgressBackgroundColor.ToSKColor(),
                IsAntialias = true,
                Style = SKPaintStyle.Stroke,
                StrokeWidth = strokeThickness
            };

            canvas.DrawCircle(
            circleRadius
            , circleRadius
            , circleRadius - strokeThickness
            , progressBackgroundPaint);



            SKPaint arcPaint = new SKPaint
            {
                Color = ProgressColor.ToSKColor(),
                Style = SKPaintStyle.Stroke,
                IsAntialias = true,
                StrokeWidth = strokeThickness,
                StrokeCap = SKStrokeCap.Butt
            };


            SKRect arcContainerRect = new SKRect(
            strokeThickness
            , strokeThickness
            , circleSize - strokeThickness
            , circleSize - strokeThickness);


            SKPath arcPath = new SKPath();
            arcPath.AddArc(arcContainerRect, 90, progress);

            canvas.DrawPath(arcPath, arcPaint);

        }
    }
}
