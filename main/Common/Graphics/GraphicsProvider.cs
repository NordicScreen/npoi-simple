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

namespace NPOI.Common.Graphics
{
    using System;

    /// <summary>
    /// Holds the ambient graphics providers used by NPOI when no provider is passed
    /// explicitly.
    /// </summary>
    /// <remarks>
    /// <para>
    /// NPOI itself ships no graphics implementation: measuring text and decoding
    /// images require a real font/imaging stack, which would otherwise force every
    /// consumer to take a heavy native dependency even when they never touch
    /// auto-sizing or pictures.
    /// </para>
    /// <para>
    /// Register a provider once during application start-up, for example by
    /// referencing the NPOI.Graphics.SkiaSharp package and calling its
    /// <c>SkiaGraphics.Register()</c> helper. Any NPOI API that needs a provider
    /// throws <see cref="InvalidOperationException"/> until one is registered.
    /// </para>
    /// </remarks>
    public static class GraphicsProvider
    {
        private static IFontProvider _font;
        private static IImageProvider _image;

        /// <summary>
        /// Gets or sets the ambient font provider used for text measurement.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown by the getter when no provider has been registered.
        /// </exception>
        public static IFontProvider Font
        {
            get
            {
                IFontProvider provider = _font;
                if (provider == null)
                {
                    throw new InvalidOperationException(
                        "No NPOI font provider has been registered. Text measurement (for example "
                        + "AutoSizeColumn or GetDefaultCharWidth) requires one. Reference a graphics "
                        + "package such as NPOI.Graphics.SkiaSharp and register it via "
                        + "GraphicsProvider.Font = ..., or pass a provider explicitly to the method being called.");
                }

                return provider;
            }

            set { _font = value; }
        }

        /// <summary>
        /// Gets or sets the ambient image provider used to determine picture dimensions.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown by the getter when no provider has been registered.
        /// </exception>
        public static IImageProvider Image
        {
            get
            {
                IImageProvider provider = _image;
                if (provider == null)
                {
                    throw new InvalidOperationException(
                        "No NPOI image provider has been registered. Determining picture dimensions "
                        + "(for example Picture.Resize or GetImageDimension) requires one. Reference a graphics "
                        + "package such as NPOI.Graphics.SkiaSharp and register it via "
                        + "GraphicsProvider.Image = ..., or pass a provider explicitly to the method being called.");
                }

                return provider;
            }

            set { _image = value; }
        }

        /// <summary>
        /// Gets a value indicating whether a font provider has been registered.
        /// </summary>
        public static bool HasFontProvider
        {
            get { return _font != null; }
        }

        /// <summary>
        /// Gets a value indicating whether an image provider has been registered.
        /// </summary>
        public static bool HasImageProvider
        {
            get { return _image != null; }
        }

        /// <summary>
        /// Registers both providers at once.
        /// </summary>
        public static void Register(IFontProvider fontProvider, IImageProvider imageProvider)
        {
            _font = fontProvider;
            _image = imageProvider;
        }

        /// <summary>
        /// Clears the registered providers. Intended for test isolation.
        /// </summary>
        public static void Reset()
        {
            _font = null;
            _image = null;
        }

        /// <summary>
        /// Returns <paramref name="provider"/> when it is not <c>null</c>, otherwise the
        /// ambient <see cref="Font"/> provider.
        /// </summary>
        public static IFontProvider ResolveFont(IFontProvider provider)
        {
            return provider ?? Font;
        }

        /// <summary>
        /// Returns <paramref name="provider"/> when it is not <c>null</c>, otherwise the
        /// ambient <see cref="Image"/> provider.
        /// </summary>
        public static IImageProvider ResolveImage(IImageProvider provider)
        {
            return provider ?? Image;
        }
    }
}
