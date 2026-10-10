/* ====================================================================
   Licensed to the Apache Software Foundation (ASF) under one or more
   contributor license agreements.  See the NOTICE file distributed with
   this work for additional information regarding copyright ownership.
   The ASF licenses this file to You under the Apache License, Version 2.0
   (the "License"); you may not use this file except in compliance with
   the License.  You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
==================================================================== */

namespace NPOI.Graphics.SkiaSharp
{
    using System;
    using System.Collections.Concurrent;

    using global::SkiaSharp;

    using NPOI.Common.Graphics;

    /// <summary>
    /// An <see cref="IFontProvider"/> backed by SkiaSharp.
    /// </summary>
    public sealed class SkiaFontProvider : IFontProvider
    {
        private static readonly ConcurrentDictionary<TypefaceKey, SKTypeface> TypefaceCache = new ConcurrentDictionary<TypefaceKey, SKTypeface>();

        /// <summary>
        /// Gets a shared instance of the provider.
        /// </summary>
        public static SkiaFontProvider Instance { get; } = new SkiaFontProvider();

        /// <inheritdoc/>
        public IMeasuredFont GetFont(FontRequest request)
        {
            SKTypeface typeface = TypefaceCache.GetOrAdd(
                new TypefaceKey(request.FontName, request.IsBold, request.IsItalic),
                static key => SKTypeface.FromFamilyName(
                    key.FontName,
                    key.IsBold ? SKFontStyleWeight.Bold : SKFontStyleWeight.Normal,
                    SKFontStyleWidth.Normal,
                    key.IsItalic ? SKFontStyleSlant.Italic : SKFontStyleSlant.Upright)
                    ?? SKTypeface.Default);

            return new SkiaMeasuredFont(new SKFont(typeface, request.SizeInPixels));
        }

        private readonly struct TypefaceKey : IEquatable<TypefaceKey>
        {
            public TypefaceKey(string fontName, bool isBold, bool isItalic)
            {
                FontName = fontName;
                IsBold = isBold;
                IsItalic = isItalic;
            }

            public string FontName { get; }

            public bool IsBold { get; }

            public bool IsItalic { get; }

            public bool Equals(TypefaceKey other)
            {
                return IsBold == other.IsBold
                    && IsItalic == other.IsItalic
                    && string.Equals(FontName, other.FontName, StringComparison.OrdinalIgnoreCase);
            }

            public override bool Equals(object obj)
            {
                return obj is TypefaceKey other && Equals(other);
            }

            public override int GetHashCode()
            {
                int hash = FontName == null ? 0 : StringComparer.OrdinalIgnoreCase.GetHashCode(FontName);
                hash = (hash * 397) ^ (IsBold ? 1 : 0);
                return (hash * 397) ^ (IsItalic ? 1 : 0);
            }

            public static bool operator ==(TypefaceKey left, TypefaceKey right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(TypefaceKey left, TypefaceKey right)
            {
                return !left.Equals(right);
            }
        }

        private sealed class SkiaMeasuredFont : IMeasuredFont
        {
            private readonly SKFont font;

            internal SkiaMeasuredFont(SKFont font)
            {
                this.font = font;
            }

            public float Size
            {
                get { return font.Size; }
            }

            public float MeasureText(string text)
            {
                if(string.IsNullOrEmpty(text))
                {
                    return 0f;
                }

                return font.MeasureText(text);
            }

            public FontMetricsInfo GetMetrics()
            {
                SKFontMetrics metrics = font.Metrics;
                return new FontMetricsInfo(metrics.Ascent, metrics.Descent, metrics.Leading);
            }

            public void Dispose()
            {
                font.Dispose();
            }
        }
    }
}
