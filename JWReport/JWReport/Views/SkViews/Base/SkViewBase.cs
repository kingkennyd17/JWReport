using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JWReport.Views.SkViews.Base
{
    public abstract class SkViewBase : ContentView
    {
        public SkViewBase()
        {
            var canvas = new SKCanvasView();
            canvas.PaintSurface += Canvas_PaintSurface;
            Content = canvas;
        }

        protected abstract void OnPaintSurface(SKImageInfo info, SKCanvas canvas, SKPaint paint);
        private void Canvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKCanvas canvas = e.Surface.Canvas;

            canvas.Clear();

            using (var paint = new SKPaint())
            {
                OnPaintSurface(info, canvas, paint);
            }
        }
    }
}
