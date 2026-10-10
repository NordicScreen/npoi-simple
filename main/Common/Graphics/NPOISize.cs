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
    /// An integral width/height pair, typically expressed in pixels or EMUs.
    /// </summary>
    /// <remarks>
    /// This type exists so that NPOI does not expose sizes from a particular
    /// graphics library in its public API.
    /// </remarks>
    public struct NPOISize : IEquatable<NPOISize>
    {
        /// <summary>
        /// A size whose width and height are both zero.
        /// </summary>
        public static readonly NPOISize Empty = default;

        /// <summary>
        /// Creates a size with the supplied width and height.
        /// </summary>
        public NPOISize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>Gets or sets the width.</summary>
        public int Width { get; set; }

        /// <summary>Gets or sets the height.</summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets a value indicating whether both width and height are zero.
        /// </summary>
        public bool IsEmpty
        {
            get { return Width == 0 && Height == 0; }
        }

        public bool Equals(NPOISize other)
        {
            return Width == other.Width && Height == other.Height;
        }

        public override bool Equals(object obj)
        {
            return obj is NPOISize other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Width * 397) ^ Height;
            }
        }

        public static bool operator ==(NPOISize left, NPOISize right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(NPOISize left, NPOISize right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return "{Width=" + Width + ", Height=" + Height + "}";
        }
    }
}
