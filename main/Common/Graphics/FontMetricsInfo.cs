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
    /// <summary>
    /// Vertical metrics of a font, in pixels.
    /// </summary>
    /// <remarks>
    /// Following the usual convention, <see cref="Ascent"/> is negative (above the
    /// baseline) and <see cref="Descent"/> is positive (below the baseline).
    /// </remarks>
    public readonly struct FontMetricsInfo
    {
        /// <summary>
        /// Creates a set of font metrics.
        /// </summary>
        public FontMetricsInfo(float ascent, float descent, float leading)
        {
            Ascent = ascent;
            Descent = descent;
            Leading = leading;
        }

        /// <summary>Gets the distance from the baseline to the top of the tallest glyph (negative).</summary>
        public float Ascent { get; }

        /// <summary>Gets the distance from the baseline to the bottom of the lowest glyph (positive).</summary>
        public float Descent { get; }

        /// <summary>Gets the recommended additional space between lines.</summary>
        public float Leading { get; }

        /// <summary>
        /// Gets the recommended distance between consecutive baselines.
        /// </summary>
        public float LineHeight
        {
            get { return Descent - Ascent + Leading; }
        }
    }
}
