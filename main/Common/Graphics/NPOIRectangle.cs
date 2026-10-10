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
    /// An integral rectangle defined by its edges.
    /// </summary>
    /// <remarks>
    /// This type exists so that NPOI does not expose rectangles from a particular
    /// graphics library in its public API. Edges are stored directly (rather than
    /// as an origin plus a size) because the Escher records that use this type
    /// persist the bounding edges.
    /// </remarks>
    public struct NPOIRectangle : IEquatable<NPOIRectangle>
    {
        /// <summary>
        /// A rectangle whose edges are all zero.
        /// </summary>
        public static readonly NPOIRectangle Empty = default;

        /// <summary>
        /// Creates a rectangle from the supplied edges.
        /// </summary>
        public NPOIRectangle(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        /// <summary>
        /// Creates a rectangle from an origin and a size.
        /// </summary>
        public static NPOIRectangle Create(int x, int y, int width, int height)
        {
            return new NPOIRectangle(x, y, x + width, y + height);
        }

        /// <summary>Gets or sets the left edge.</summary>
        public int Left { get; set; }

        /// <summary>Gets or sets the top edge.</summary>
        public int Top { get; set; }

        /// <summary>Gets or sets the right edge.</summary>
        public int Right { get; set; }

        /// <summary>Gets or sets the bottom edge.</summary>
        public int Bottom { get; set; }

        /// <summary>Gets the distance between the left and right edges.</summary>
        public int Width
        {
            get { return Right - Left; }
        }

        /// <summary>Gets the distance between the top and bottom edges.</summary>
        public int Height
        {
            get { return Bottom - Top; }
        }

        /// <summary>
        /// Gets a value indicating whether all edges are zero.
        /// </summary>
        public bool IsEmpty
        {
            get { return Left == 0 && Top == 0 && Right == 0 && Bottom == 0; }
        }

        /// <summary>
        /// Gets the size of this rectangle.
        /// </summary>
        public NPOISize Size
        {
            get { return new NPOISize(Width, Height); }
        }

        public bool Equals(NPOIRectangle other)
        {
            return Left == other.Left
                && Top == other.Top
                && Right == other.Right
                && Bottom == other.Bottom;
        }

        public override bool Equals(object obj)
        {
            return obj is NPOIRectangle other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Left;
                hashCode = (hashCode * 397) ^ Top;
                hashCode = (hashCode * 397) ^ Right;
                hashCode = (hashCode * 397) ^ Bottom;
                return hashCode;
            }
        }

        public static bool operator ==(NPOIRectangle left, NPOIRectangle right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(NPOIRectangle left, NPOIRectangle right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return "{Left=" + Left + ", Top=" + Top + ", Right=" + Right + ", Bottom=" + Bottom + "}";
        }
    }
}
