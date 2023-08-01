using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWReport.Views.SkViews
{
    class HorizontalRectGradientView : Base.HorizontalGradientViewBase
    {
        public HorizontalRectGradientView()
        {
        }

        protected override void DrawGradient(SKImageInfo info, SKCanvas canvas, SKPaint paint)
        {
            canvas.DrawRect(0, 0, info.Width, info.Height, paint);
        }
    }
}
