/* ------------------------------------------------------------------------- */
/*
 *  Monitor.cs
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
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace CubePower
{
    /* --------------------------------------------------------------------- */
    ///
    /// Area
    ///
    /// <summary>
    /// 電力情報を取得可能な地域一覧
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public enum Area
    {
        Tokyo,      // 東京電力
        Tohoku,     // 東北電力
        Kansai,     // 関西電力
        Kyushu,     // 九州電力
        Chubu       // 中部電力
    }

    /* --------------------------------------------------------------------- */
    ///
    /// Area
    ///
    /// <summary>
    /// 各電力会社の消費電力量、および供給電力量を取得するクラスです。
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public class Monitor
    {
        /* ----------------------------------------------------------------- */
        /// constructor
        /* ----------------------------------------------------------------- */
        public Monitor() { }

        /* ----------------------------------------------------------------- */
        /// constructor
        /* ----------------------------------------------------------------- */
        public Monitor(Area area)
        {
            _area = area;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Update
        ///
        /// <summary>
        /// 電力情報を更新します。PeekSupply に関しては、早い時刻の場合には
        /// まだ当日の情報が用意されていない事があるので、当日の情報取得に
        /// 失敗した場合は、昨日の情報を取得を試みます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public bool Update()
        {
            int consumption = this.GetConsumption();
            if (consumption < 0) return false;

            int supply = this.GetPeekSupply();
            if (supply < 0)
            {
                var yesterday = DateTime.Today.AddDays(-1);
                supply = this.GetPeekSupply(yesterday);
            }

            if (supply < 0 && _supply <= 0) return false;
            _consumption = consumption;
            _supply = supply;
            return true;
        }

        /* ----------------------------------------------------------------- */
        /// プロパティ
        /* ----------------------------------------------------------------- */
        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// TargetArea
        ///
        /// <summary>
        /// 電力情報を取得する地域を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public Area TargetArea
        {
            get { return _area; }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Time
        ///
        /// <summary>
        /// 現在、取得している情報の取得時刻を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public DateTime Time
        {
            get { return _time; }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Consumption
        ///
        /// <summary>
        /// 現在の電力消費量を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public int Consumption
        {
            get { return _consumption; }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ConsumptionRaio
        ///
        /// <summary>
        /// 現在の電力消費割合をパーセンテージ単位で取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public int ConsumptionRatio
        {
            get
            {
                double ratio = _consumption / (double)_supply;
                ratio *= 100;
                return (int)(ratio + 0.5);
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// PeekSupply
        ///
        /// <summary>
        /// 本日のピーク時の電力供給量を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public int PeekSupply
        {
            get { return _supply; }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// PowerUnit
        /// 
        /// <summary>
        /// 取得する電力量の単位を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public string PowerUnit
        {
            get { return _unit; }
        }

        #endregion

        /* ----------------------------------------------------------------- */
        /// 内部処理用メソッド群
        /* ----------------------------------------------------------------- */
        #region Private methods

        /* ----------------------------------------------------------------- */
        ///
        /// GetConsumption
        ///
        /// <summary>
        /// API 経由で最新の電力消費量を取得します。
        /// GetConsumption() メソッドが実行される度に Time プロパティで
        /// 取得される時刻も更新されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private int GetConsumption()
        {
            int dest = -1;

            try
            {
                var area = _area.ToString().ToLower();
                var kind = (area == "chubu") ? "actual" : "instant";
                var uri = String.Format("http://{0}/usage/{1}/{2}/latest?output=xml", API_HOST, area, kind);
                using (var reader = new XmlTextReader(uri))
                {
                    if (!reader.ReadToFollowing("usage")) return dest;

                    var datetime = reader.GetAttribute("datetime");
                    if (datetime.Length > 0) _time = DateTime.Parse(datetime);

                    var value = reader.ReadString();
                    if (value.Length > 0) dest = Int32.Parse(value);
                }
            }
            catch (Exception /* err */) { }

            return dest;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// GetPeekSupply
        ///
        /// <summary>
        /// API 経由で本日のピーク時の電力供給量を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private int GetPeekSupply()
        {
            int dest = -1;
            try
            {
                var uri = String.Format("http://{0}/peak/{1}/supply/today?output=xml", API_HOST, _area.ToString().ToLower());
                using (var reader = new XmlTextReader(uri))
                {
                    if (!reader.ReadToFollowing("supply")) return dest;
                    var value = reader.ReadString();
                    if (value.Length > 0) dest = Int32.Parse(value);
                }
            }
            catch (Exception /* err */) { }

            return dest;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// GetPeekSupply
        ///
        /// <summary>
        /// API 経由で引数に指定した日付のピーク時の電力供給量を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private int GetPeekSupply(DateTime date)
        {
            int dest = -1;
            try
            {
                var uri = String.Format("http://{0}/peak/{1}/supply/{2}/{3:D2}/{4:D2}?output=xml",
                    API_HOST, _area.ToString().ToLower(), date.Year, date.Month, date.Day);
                using (var reader = new XmlTextReader(uri))
                {
                    if (!reader.ReadToFollowing("supply")) return dest;
                    var value = reader.ReadString();
                    if (value.Length > 0) dest = Int32.Parse(value);
                }
            }
            catch (Exception /* err */) { }

            return dest;
        }

        #endregion

        /* ----------------------------------------------------------------- */
        /// 変数定義
        /* ----------------------------------------------------------------- */
        #region Variables
        private Area _area = Area.Tokyo;
        private DateTime _time = new DateTime();
        private int _consumption = 0;
        private int _supply = 0;
        private string _unit = "kW";
        #endregion

        /* ----------------------------------------------------------------- */
        /// 定数定義
        /* ----------------------------------------------------------------- */
        #region Constant variables
        const string API_HOST = "api.gosetsuden.jp";
        #endregion
    }
}
