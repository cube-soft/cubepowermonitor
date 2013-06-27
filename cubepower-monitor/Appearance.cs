/* ------------------------------------------------------------------------- */
/*
 *  Appearance.cs
 *
 *  Copyright (c) 2012 CubeSoft, Inc.
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see < http://www.gnu.org/licenses/ >.
 */
/* ------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Text;
using CubePower.Monitoring;

namespace CubePower
{
    /* --------------------------------------------------------------------- */
    ///
    ///  Appearance
    ///  
    ///  <summary>
    ///  CubePower Monitor メイン画面のコンボボックスに表示する文字列を
    ///  定義したクラスです。
    ///  </summary>
    ///  
    /* --------------------------------------------------------------------- */
    class Appearance
    {
        /* ----------------------------------------------------------------- */
        /// AreaString
        /* ----------------------------------------------------------------- */
        public static string AreaString(Area id)
        {
            switch (id)
            {
                case Area.Hokkaido: return "北海道電力";
                case Area.Tohoku:   return "東北電力";
                case Area.Hokuriku: return "北陸電力";
                case Area.Tokyo:    return "東京電力";
                case Area.Chubu:    return "中部電力";
                case Area.Kansai:   return "関西電力";
                case Area.Chugoku:  return "中国電力";
                case Area.Shikoku:  return "四国電力";
                case Area.Kyushu:   return "九州電力";                
                default: break;
            }
            return "Unknown";
        }
    }
}
