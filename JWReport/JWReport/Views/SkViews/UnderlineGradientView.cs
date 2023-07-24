﻿using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWReport.Views.SkViews
{
    public class UnderlineGradientView : RectGradientView
    {
        protected override SKShader CreateGradientShader(SKImageInfo info)
        {
            return SKShader.CreateLinearGradient(
                new SKPoint(0, info.Height / 2),
                new SKPoint(info.Width / 2, info.Height / 2),
                new SKColor[] { StartColor.ToSKColor(), EndColor.ToSKColor() },
                new float[] { 0, 0.5f },
                SKShaderTileMode.Mirror);

        }
    }
}
