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

    using global::SkiaSharp;

    using NPOI.Common.Graphics;

    /// <summary>
    /// An <see cref="IImageProvider"/> backed by SkiaSharp.
    /// </summary>
    public sealed class SkiaImageProvider : IImageProvider
    {
        /// <summary>
        /// Gets a shared instance of the provider.
        /// </summary>
        public static SkiaImageProvider Instance { get; } = new SkiaImageProvider();

        /// <inheritdoc/>
        public IDecodedImage Decode(byte[] data)
        {
            if(data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            SKBitmap bitmap = SKBitmap.Decode(data);
            if(bitmap == null)
            {
                throw new ArgumentException("The supplied data could not be decoded as an image.", nameof(data));
            }

            return new SkiaDecodedImage(bitmap);
        }

        private sealed class SkiaDecodedImage : IDecodedImage
        {
            private readonly SKBitmap bitmap;

            internal SkiaDecodedImage(SKBitmap bitmap)
            {
                this.bitmap = bitmap;
            }

            public int Width
            {
                get { return bitmap.Width; }
            }

            public int Height
            {
                get { return bitmap.Height; }
            }

            public void Dispose()
            {
                bitmap.Dispose();
            }
        }
    }
}
