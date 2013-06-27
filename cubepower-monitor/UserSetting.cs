/* ------------------------------------------------------------------------- */
/*
 *  UserSetting.cs
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
using Microsoft.Win32;
using CubePower.Monitoring;

namespace CubePower
{
    /* --------------------------------------------------------------------- */
    ///
    /// UserSetting
    ///
    /// <summary>
    /// レジストリに保存されてあるユーザ設定の取得および設定を行うクラス。
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public class UserSetting
    {
        /* ----------------------------------------------------------------- */
        ///
        /// Constructor
        ///
        /// <summary>
        /// UserSetting クラスを初期化します。CubePower Monitor の
        /// バージョン情報やインストールパス等、ユーザによらず一定
        /// (HKEY_LOCAL_MACHINE¥Software¥CubeSoft¥CubePower Monitor 下で
        /// 定義されているもの) である情報のみロードされます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public UserSetting()
        {
            this.MustLoad();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Load
        /// 
        /// <summary>
        /// ユーザ毎の設定情報を読み込みます。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        public bool Load()
        {
            bool status = true;

            try
            {
                RegistryKey subkey = Registry.CurrentUser.CreateSubKey(REG_ROOT);
                if (subkey == null) status = false;
                else
                {
                    _area = (Area)subkey.GetValue(REG_TARGETAREA, Area.Tokyo);
                    subkey.Close();
                }
            }
            catch (Exception /* err */)
            {
                status = false;
            }

            return status;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Save
        /// 
        /// <summary>
        /// ユーザ毎の設定情報を保存します。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        public bool Save()
        {
            bool status = true;

            try
            {
                RegistryKey subkey = Registry.CurrentUser.CreateSubKey(REG_ROOT);
                if (subkey == null) status = false;
                else
                {
                    subkey.SetValue(REG_TARGETAREA, (int)_area);
                    subkey.Close();
                }
            }
            catch (Exception /* err */)
            {
                status = false;
            }

            return status;
        }

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// InstallDirectory
        ///
        /// <summary>
        /// 現在インストールされている CubePower Monitor のインストール
        /// フォルダへのパスを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public string InstallDirectory
        {
            get { return _install; }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Version
        ///
        /// <summary>
        /// 現在インストールされている CubePower Monitor のバージョン情報を
        /// 取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public string Version
        {
            get { return _version; }
        }

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
            set { _area = value; }
        }

        #endregion

        /* ----------------------------------------------------------------- */
        //  その他のメソッド群
        /* ----------------------------------------------------------------- */
        #region Other methods

        /* ----------------------------------------------------------------- */
        ///
        /// MustLoad
        ///
        /// <summary>
        /// CubePower Monitor のバージョン情報やインストールパス等、
        /// ユーザによらず一定である情報をロードします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private bool MustLoad()
        {
            bool status = true;

            try
            {
                RegistryKey subkey = Registry.LocalMachine.OpenSubKey(REG_ROOT, false);
                if (subkey == null) status = false;
                else
                {
                    _version = subkey.GetValue(REG_VERSION, REG_VALUE_UNKNOWN) as string;
                    _install = subkey.GetValue(REG_INSTALLDIRECTORY, REG_VALUE_UNKNOWN) as string;
                    subkey.Close();
                }
                if (_version == null) _version = REG_VALUE_UNKNOWN;
                if (_install == null) _install = REG_VALUE_UNKNOWN;
            }
            catch (Exception /* err */)
            {
                status = false;
            }

            return status;

        }

        #endregion

        /* ----------------------------------------------------------------- */
        //  変数定義
        /* ----------------------------------------------------------------- */
        #region Variables
        private string _install = "";
        private string _version = "1.0.0";
        private Area _area = Area.Tokyo;
        #endregion

        /* ----------------------------------------------------------------- */
        //  定数定義
        /* ----------------------------------------------------------------- */
        #region Constant variables
        const string REG_ROOT = @"Software\CubeSoft\CubePower Monitor";
        const string REG_INSTALLDIRECTORY = "InstallDirectory";
        const string REG_VERSION = "Version";
        const string REG_TARGETAREA = "TargetArea";
        const string REG_VALUE_UNKNOWN = "Unknown";
        #endregion
    }
}
