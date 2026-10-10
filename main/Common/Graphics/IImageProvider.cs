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
    /// A decoded raster image, exposing only the information NPOI needs.
    /// </summary>
    /// <remarks>
    /// NPOI never rasterizes or draws; it only needs pixel dimensions in order to
    /// compute preferred picture sizes and anchors.
    /// </remarks>
    public interface IDecodedImage : IDisposable
    {
        /// <summary>Gets the image width, in pixels.</summary>
        int Width { get; }

        /// <summary>Gets the image height, in pixels.</summary>
        int Height { get; }
    }

    /// <summary>
    /// Decodes image data, decoupling NPOI from any particular imaging library.
    /// </summary>
    /// <remarks>
    /// Register an implementation through <see cref="GraphicsProvider.Image"/>, or pass
    /// one explicitly to the APIs that accept an optional provider argument.
    /// </remarks>
    public interface IImageProvider
    {
        /// <summary>
        /// Decodes the supplied image bytes far enough to report their dimensions.
        /// </summary>
        /// <param name="data">The raw encoded image bytes.</param>
        /// <returns>
        /// The decoded image, or <c>null</c> when the data cannot be decoded.
        /// </returns>
        IDecodedImage Decode(byte[] data);
    }
}
