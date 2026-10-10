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
    using System.Globalization;

    /// <summary>
    /// An immutable 32-bit RGBA color value.
    /// </summary>
    /// <remarks>
    /// This type exists so that NPOI does not expose colors from a particular
    /// graphics library in its public API. It is a plain value type with no
    /// dependency on any rendering engine.
    /// </remarks>
    public readonly struct NPOIColor : IEquatable<NPOIColor>
    {
        /// <summary>
        /// The "no color" sentinel (all components zero, i.e. fully transparent black).
        /// </summary>
        public static readonly NPOIColor Empty = default;

        /// <summary>
        /// Creates an opaque color from the supplied red, green and blue components.
        /// </summary>
        public NPOIColor(byte red, byte green, byte blue)
            : this(red, green, blue, 0xFF)
        {
        }

        /// <summary>
        /// Creates a color from the supplied red, green, blue and alpha components.
        /// </summary>
        public NPOIColor(byte red, byte green, byte blue, byte alpha)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }

        /// <summary>Gets the red component.</summary>
        public byte Red { get; }

        /// <summary>Gets the green component.</summary>
        public byte Green { get; }

        /// <summary>Gets the blue component.</summary>
        public byte Blue { get; }

        /// <summary>Gets the alpha component.</summary>
        public byte Alpha { get; }

        /// <summary>
        /// Gets a value indicating whether this instance equals <see cref="Empty"/>.
        /// </summary>
        public bool IsEmpty
        {
            get { return Red == 0 && Green == 0 && Blue == 0 && Alpha == 0; }
        }

        /// <summary>
        /// Creates a color from a packed 0xAARRGGBB value.
        /// </summary>
        public static NPOIColor FromArgb(uint argb)
        {
            return new NPOIColor(
                (byte) ((argb >> 16) & 0xFF),
                (byte) ((argb >> 8) & 0xFF),
                (byte) (argb & 0xFF),
                (byte) ((argb >> 24) & 0xFF));
        }

        /// <summary>
        /// Returns this color as a packed 0xAARRGGBB value.
        /// </summary>
        public uint ToArgb()
        {
            return ((uint) Alpha << 24) | ((uint) Red << 16) | ((uint) Green << 8) | Blue;
        }

        public bool Equals(NPOIColor other)
        {
            return Red == other.Red
                && Green == other.Green
                && Blue == other.Blue
                && Alpha == other.Alpha;
        }

        public override bool Equals(object obj)
        {
            return obj is NPOIColor other && Equals(other);
        }

        public override int GetHashCode()
        {
            return unchecked((int) ToArgb());
        }

        public static bool operator ==(NPOIColor left, NPOIColor right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(NPOIColor left, NPOIColor right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return ToArgb().ToString("X8", CultureInfo.InvariantCulture);
        }
    }
}
