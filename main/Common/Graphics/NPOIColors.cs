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
    /// The named colors that NPOI itself refers to, for example through number formats.
    /// </summary>
    public static class NPOIColors
    {
        /// <summary>Opaque black (#000000).</summary>
        public static NPOIColor Black { get; } = new NPOIColor(0x00, 0x00, 0x00);

        /// <summary>Opaque white (#FFFFFF).</summary>
        public static NPOIColor White { get; } = new NPOIColor(0xFF, 0xFF, 0xFF);

        /// <summary>Opaque red (#FF0000).</summary>
        public static NPOIColor Red { get; } = new NPOIColor(0xFF, 0x00, 0x00);

        /// <summary>Opaque green (#008000).</summary>
        public static NPOIColor Green { get; } = new NPOIColor(0x00, 0x80, 0x00);

        /// <summary>Opaque blue (#0000FF).</summary>
        public static NPOIColor Blue { get; } = new NPOIColor(0x00, 0x00, 0xFF);

        /// <summary>Opaque yellow (#FFFF00).</summary>
        public static NPOIColor Yellow { get; } = new NPOIColor(0xFF, 0xFF, 0x00);

        /// <summary>Opaque cyan (#00FFFF).</summary>
        public static NPOIColor Cyan { get; } = new NPOIColor(0x00, 0xFF, 0xFF);

        /// <summary>Opaque magenta (#FF00FF).</summary>
        public static NPOIColor Magenta { get; } = new NPOIColor(0xFF, 0x00, 0xFF);

        /// <summary>Opaque orange (#FFA500).</summary>
        public static NPOIColor Orange { get; } = new NPOIColor(0xFF, 0xA5, 0x00);

        /// <summary>Opaque wheat (#F5DEB3).</summary>
        public static NPOIColor Wheat { get; } = new NPOIColor(0xF5, 0xDE, 0xB3);
    }
}
