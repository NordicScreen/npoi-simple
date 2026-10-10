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
    /// A font resolved by an <see cref="IFontProvider"/>, able to measure text.
    /// </summary>
    /// <remarks>
    /// Instances are owned by the caller and must be disposed. Implementations are
    /// expected to cache the expensive parts (typefaces) internally so that creating
    /// a measured font stays cheap.
    /// </remarks>
    public interface IMeasuredFont : IDisposable
    {
        /// <summary>
        /// Gets the em-square size of this font, in pixels.
        /// </summary>
        float Size { get; }

        /// <summary>
        /// Measures the horizontal advance of the supplied text, in pixels.
        /// </summary>
        /// <param name="text">The text to measure. May be empty.</param>
        /// <returns>The advance width in pixels.</returns>
        float MeasureText(string text);

        /// <summary>
        /// Gets the vertical metrics of this font, in pixels.
        /// </summary>
        FontMetricsInfo GetMetrics();
    }

    /// <summary>
    /// Supplies fonts for text measurement, decoupling NPOI from any particular
    /// graphics or text-shaping library.
    /// </summary>
    /// <remarks>
    /// Register an implementation through <see cref="GraphicsProvider.Font"/>, or pass
    /// one explicitly to the APIs that accept an optional provider argument.
    /// </remarks>
    public interface IFontProvider
    {
        /// <summary>
        /// Resolves the supplied request into a font that can measure text.
        /// </summary>
        /// <param name="request">Describes the wanted family, size and style.</param>
        /// <returns>
        /// A measured font; implementations should substitute a reasonable fallback
        /// family rather than returning <c>null</c> when the request cannot be met exactly.
        /// </returns>
        IMeasuredFont GetFont(FontRequest request);
    }
}
