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
        public MainForm()
        {
            InitializeComponent();
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
            this._worker.WorkerSupportsCancellation = true;
            this._worker.WorkerReportsProgress = true;
            this._worker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            this._worker.ProgressChanged += new ProgressChangedEventHandler(BackgroundWorker_ProgressChanged);
            this._worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);

            foreach (Area id in Enum.GetValues(typeof(Area)))
            {
                string s = Appearance.AreaString(id);
                if (s.Length > 0) this.AreaComboBox.Items.Add(s);
            }
            this.AreaComboBox.SelectedIndex = 0;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// MainForm_Shown
        ///
        /// <summary>
        /// 画面が表示された直後に電力状況を更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void MainForm_Shown(object sender, EventArgs e)
        {
            this._area = this.IndexToArea(this.AreaComboBox.SelectedIndex);
            this._worker.RunWorkerAsync();
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
            this._area = this.IndexToArea(this.AreaComboBox.SelectedIndex);
            this._worker.CancelAsync();
        }
        
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
                var monitor = new Monitor(this._area);
                var interval = new TimeSpan(0, 10, 0);

                while (true)
                {
                    worker.ReportProgress(50, "最新の情報を取得中です...");
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
                        System.Threading.Thread.Sleep(1000);
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
        /// 電力状況取得中に、ステータスバーに情報を表示する必要のある
        /// 場合に、このメソッドを通じて更新を行います。
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
                this.RatioProgressBar.Value = monitor.ConsumptionRatio;

                this.InfoToolStripStatusLabel.Text = String.Format("{0} 現在", monitor.Time.ToString());
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
            this._area = this.IndexToArea(this.AreaComboBox.SelectedIndex);
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

        #endregion

        /* ----------------------------------------------------------------- */
        //  変数定義
        /* ----------------------------------------------------------------- */
        #region Variables
        Area _area = Area.Tokyo;
        BackgroundWorker _worker = new BackgroundWorker();
        #endregion
    }
}
