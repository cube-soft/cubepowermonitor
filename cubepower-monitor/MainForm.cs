/* ------------------------------------------------------------------------- */
/*
 *  MainForm.cs
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
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CubePower
{
    /* --------------------------------------------------------------------- */
    /// MainForm
    /* --------------------------------------------------------------------- */
    public partial class MainForm : Form
    {
        /* ----------------------------------------------------------------- */
        /// constructor
        /* ----------------------------------------------------------------- */
        public MainForm(UserSetting setting)
        {
            InitializeComponent();
            this._setting = setting;
            this.Initialize();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Initialize
        /// 
        /// <summary>
        /// メイン画面の初期処理を行います。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Initialize()
        {
            // Title
            var edition = (IntPtr.Size == 4) ? "x86" : "x64";
            this.Text = String.Format("CubePower Monitor {0} ({1})", this._setting.Version, edition);

            // BackgroundWorker
            this._worker.WorkerSupportsCancellation = true;
            this._worker.WorkerReportsProgress = true;
            this._worker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            this._worker.ProgressChanged += new ProgressChangedEventHandler(BackgroundWorker_ProgressChanged);
            this._worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);

            // AreaComboBox
            foreach (Area id in Enum.GetValues(typeof(Area)))
            {
                string s = Appearance.AreaString(id);
                if (s.Length > 0) this.AreaComboBox.Items.Add(s);
            }
            this.AreaComboBox.SelectedIndex = this.AreaToIndex(this._setting.TargetArea);

            // NotifyIcon
            this.RatioNotifyIcon.Icon = Properties.Resources.tasktray;
            this.RatioNotifyIcon.Visible = false;
        }

        /* ----------------------------------------------------------------- */
        //  各種イベントハンドラ
        /* ----------------------------------------------------------------- */
        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// MainForm_Shown
        ///
        /// <summary>
        /// 画面が表示された直後に実行されるイベントハンドラです。
        /// 選択されている地域の電力状況を更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void MainForm_Shown(object sender, EventArgs e)
        {
            this._setting.TargetArea = this.IndexToArea(this.AreaComboBox.SelectedIndex);
            this._worker.RunWorkerAsync();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// MainForm_SizeChanged
        ///
        /// <summary>
        /// フォームのサイズが変更された時に実行されるイベントハンドラです。
        /// 最小化時、タスクバーには非表示に設定し、代わりにタスクトレイに
        /// 表示します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            bool minimized = (this.WindowState == FormWindowState.Minimized);
            this.ShowInTaskbar = !minimized;
            this.RatioNotifyIcon.Visible = minimized;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OpenItem_Click
        ///
        /// <summary>
        /// タスクトレイに表示（最小化）時、「開く」メニューを選択した時に
        /// 実行されるイベントハンドラです。このイベントハンドラは、
        /// タスクトレイに表示されているアイコンを右クリックした時に
        /// 表示されるコンテキストメニューの他、アイコンをダブルクリック
        /// した時にも実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void OpenItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ExitToolStripMenuItem_Click
        ///
        /// <summary>
        /// タスクトレイに表示されているアイコンを右クリックした時に
        /// 表示されるコンテキストメニューから「囚虜」を選択したときに
        /// 実行されるイベントハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._worker.IsBusy) this._worker.CancelAsync();
            this.Close();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// AreaComboBox_SelectedIndexChanged
        ///
        /// <summary>
        /// 電力状況を取得する電力会社が変更された場合に実行される
        /// イベント・ハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void AreaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._setting.TargetArea = this.IndexToArea(this.AreaComboBox.SelectedIndex);
            this._worker.CancelAsync();
        }

        #endregion

        /* ----------------------------------------------------------------- */
        //  BackgroundWorker 関連のメソッド群
        /* ----------------------------------------------------------------- */
        #region Background workder's methods

        /* ----------------------------------------------------------------- */
        ///
        /// BackgroundWorker_DoWork
        ///
        /// <summary>
        /// コンボボックスで指定されている電力会社の電力状況を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void BackgroundWorker_DoWork(Object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            if (worker == null) return;

            try
            {
                var monitor = new Monitor(this._setting.TargetArea);
                var interval = new TimeSpan(0, 10, 0);

                while (true)
                {
                    worker.ReportProgress(0, "最新の情報を取得中です...");
                    if (monitor.Update()) worker.ReportProgress(100, monitor);
                    else worker.ReportProgress(0, "電力使用状況を取得できませんでした");

                    var latest = DateTime.Now;
                    while (DateTime.Now - latest < interval)
                    {
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            catch (Exception err)
            {
                worker.ReportProgress(0, err.Message);
            }

        }

        /* ----------------------------------------------------------------- */
        ///
        /// BackgroundWorker_ProgressChanged
        ///
        /// <summary>
        /// BackgroundWorker 経由で電力状況の更新があった場合に実行される
        /// イベントハンドラです。画面に表示されている電力状況に関する
        /// 情報を更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage > 0)
            {
                var monitor = e.UserState as Monitor;
                if (monitor == null) return;

                int consumption = monitor.Consumption / 10000;
                int supply = monitor.PeekSupply / 10000;
                this.ConsumptionLabel.Text = String.Format("{0}万kW / {1}万kW", consumption, supply);

                this.RatioLabel.Text = String.Format("{0}%", monitor.ConsumptionRatio);
                this.RatioProgressBar.Value = Math.Min(Math.Max(monitor.ConsumptionRatio, this.RatioProgressBar.Minimum), this.RatioProgressBar.Maximum);
                this.RatioNotifyIcon.Icon = this.GetNotifyIcon(monitor.ConsumptionRatio);

                this.InfoToolStripStatusLabel.Text = String.Format("{0} 更新", monitor.Time.ToString());

                this.RatioNotifyIcon.Text = String.Format("{0}\r\n{1} ({2})\r\n{3}",
                    Appearance.AreaString(this._setting.TargetArea), this.ConsumptionLabel.Text, this.RatioLabel.Text, this.InfoToolStripStatusLabel.Text);
            }
            else
            {
                var message = e.UserState as string;
                if (message == null) return;
                this.InfoToolStripStatusLabel.Text = message;
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// BackgroundWorker_ProgressChanged
        ///
        /// <summary>
        /// 情報更新が停止した場合に、再スタートします。
        /// 電力を取得する地域情報が変更された場合は即座に、何らかのエラー
        /// が発生した場合は一定時間後に再スタートします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            if (worker == null) return;

            if (!e.Cancelled) System.Threading.Thread.Sleep(5 * 60 * 1000);
            this._setting.TargetArea = this.IndexToArea(this.AreaComboBox.SelectedIndex);
            worker.RunWorkerAsync();
        }

        #endregion

        /* ----------------------------------------------------------------- */
        //  その他、内部処理用のメソッド群
        /* ----------------------------------------------------------------- */
        #region Other methods

        /* ----------------------------------------------------------------- */
        ///
        /// IndexToArea
        ///
        /// <summary>
        /// コンボボックスのインデックスから対応する Area 列挙体へ変換します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private Area IndexToArea(int index)
        {
            return (Area)index;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// AreaToIndex
        ///
        /// <summary>
        /// Area 列挙体から対応するコンボボックスのインデックスへ変換します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private int AreaToIndex(Area area)
        {
            return (int)area;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// GetNotifyIcon
        ///
        /// <summary>
        /// 電力状況に応じたアイコンを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private Icon GetNotifyIcon(int ratio)
        {
            if (ratio < 10) return Properties.Resources.tasktray;
            else if (ratio <  20) return Properties.Resources.tasktray_10;
            else if (ratio <  30) return Properties.Resources.tasktray_20;
            else if (ratio <  40) return Properties.Resources.tasktray_30;
            else if (ratio <  50) return Properties.Resources.tasktray_40;
            else if (ratio <  60) return Properties.Resources.tasktray_50;
            else if (ratio <  70) return Properties.Resources.tasktray_60;
            else if (ratio <  80) return Properties.Resources.tasktray_70;
            else if (ratio <  85) return Properties.Resources.tasktray_80;
            else if (ratio <  90) return Properties.Resources.tasktray_85;
            else if (ratio <  95) return Properties.Resources.tasktray_90;
            else if (ratio <  96) return Properties.Resources.tasktray_95;
            else if (ratio <  97) return Properties.Resources.tasktray_96;
            else if (ratio <  98) return Properties.Resources.tasktray_97;
            else if (ratio <  99) return Properties.Resources.tasktray_98;
            else if (ratio < 100) return Properties.Resources.tasktray_99;
            else return Properties.Resources.tasktray_100;
        }

        #endregion

        /* ----------------------------------------------------------------- */
        //  変数定義
        /* ----------------------------------------------------------------- */
        #region Variables
        UserSetting _setting;
        BackgroundWorker _worker = new BackgroundWorker();
        #endregion
    }
}
