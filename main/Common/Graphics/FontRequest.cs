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
    /// Describes the font that a caller wants to measure text with.
    /// </summary>
    public readonly struct FontRequest : IEquatable<FontRequest>
    {
        /// <summary>
        /// The DPI assumed by NPOI when converting point sizes to pixels.
        /// </summary>
        public const float DefaultDpi = 96f;

        /// <summary>
        /// Creates a font request.
        /// </summary>
        /// <param name="fontName">The desired font family name.</param>
        /// <param name="sizeInPoints">The font size in typographic points.</param>
        /// <param name="isBold">Whether a bold face is wanted.</param>
        /// <param name="isItalic">Whether an italic face is wanted.</param>
        /// <param name="dpi">The resolution used to convert points to pixels.</param>
        public FontRequest(string fontName, float sizeInPoints, bool isBold, bool isItalic, float dpi = DefaultDpi)
        {
            FontName = fontName;
            SizeInPoints = sizeInPoints;
            IsBold = isBold;
            IsItalic = isItalic;
            Dpi = dpi;
        }

        /// <summary>Gets the desired font family name.</summary>
        public string FontName { get; }

        /// <summary>Gets the font size in typographic points.</summary>
        public float SizeInPoints { get; }

        /// <summary>Gets a value indicating whether a bold face is wanted.</summary>
        public bool IsBold { get; }

        /// <summary>Gets a value indicating whether an italic face is wanted.</summary>
        public bool IsItalic { get; }

        /// <summary>Gets the resolution used to convert points to pixels.</summary>
        public float Dpi { get; }

        /// <summary>
        /// Gets the font size converted to pixels at <see cref="Dpi"/>.
        /// </summary>
        public float SizeInPixels
        {
            get { return SizeInPoints * Dpi / 72f; }
        }

        public bool Equals(FontRequest other)
        {
            return FontName == other.FontName
                && SizeInPoints.Equals(other.SizeInPoints)
                && IsBold == other.IsBold
                && IsItalic == other.IsItalic
                && Dpi.Equals(other.Dpi);
        }

        public override bool Equals(object obj)
        {
            return obj is FontRequest other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = FontName != null ? FontName.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ SizeInPoints.GetHashCode();
                hashCode = (hashCode * 397) ^ IsBold.GetHashCode();
                hashCode = (hashCode * 397) ^ IsItalic.GetHashCode();
                hashCode = (hashCode * 397) ^ Dpi.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(FontRequest left, FontRequest right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FontRequest left, FontRequest right)
        {
            return !left.Equals(right);
        }
    }
}
