namespace CubePower
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.RatioProgressBar = new System.Windows.Forms.ProgressBar();
            this.AreaComboBox = new System.Windows.Forms.ComboBox();
            this.RatioLabel = new System.Windows.Forms.Label();
            this.FooterStatusStrip = new System.Windows.Forms.StatusStrip();
            this.InfoToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ConsumptionLabel = new System.Windows.Forms.Label();
            this.RatioNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TasktrayContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NormalizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FooterStatusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.TasktrayContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // RatioProgressBar
            // 
            this.RatioProgressBar.Location = new System.Drawing.Point(12, 38);
            this.RatioProgressBar.Minimum = 50;
            this.RatioProgressBar.Name = "RatioProgressBar";
            this.RatioProgressBar.Size = new System.Drawing.Size(250, 20);
            this.RatioProgressBar.TabIndex = 0;
            this.RatioProgressBar.Value = 50;
            // 
            // AreaComboBox
            // 
            this.AreaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AreaComboBox.FormattingEnabled = true;
            this.AreaComboBox.Location = new System.Drawing.Point(12, 12);
            this.AreaComboBox.Name = "AreaComboBox";
            this.AreaComboBox.Size = new System.Drawing.Size(100, 20);
            this.AreaComboBox.TabIndex = 1;
            this.AreaComboBox.SelectedIndexChanged += new System.EventHandler(this.AreaComboBox_SelectedIndexChanged);
            // 
            // RatioLabel
            // 
            this.RatioLabel.AutoSize = true;
            this.RatioLabel.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RatioLabel.ForeColor = System.Drawing.Color.Black;
            this.RatioLabel.Location = new System.Drawing.Point(268, 16);
            this.RatioLabel.Name = "RatioLabel";
            this.RatioLabel.Size = new System.Drawing.Size(77, 37);
            this.RatioLabel.TabIndex = 2;
            this.RatioLabel.Text = "00%";
            // 
            // FooterStatusStrip
            // 
            this.FooterStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InfoToolStripStatusLabel});
            this.FooterStatusStrip.Location = new System.Drawing.Point(0, 73);
            this.FooterStatusStrip.Name = "FooterStatusStrip";
            this.FooterStatusStrip.Size = new System.Drawing.Size(354, 23);
            this.FooterStatusStrip.SizingGrip = false;
            this.FooterStatusStrip.TabIndex = 4;
            this.FooterStatusStrip.Text = "statusStrip1";
            // 
            // InfoToolStripStatusLabel
            // 
            this.InfoToolStripStatusLabel.Name = "InfoToolStripStatusLabel";
            this.InfoToolStripStatusLabel.Size = new System.Drawing.Size(152, 18);
            this.InfoToolStripStatusLabel.Text = "最新の情報を取得中です...";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ConsumptionLabel);
            this.panel1.Location = new System.Drawing.Point(118, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.panel1.Size = new System.Drawing.Size(144, 20);
            this.panel1.TabIndex = 5;
            // 
            // ConsumptionLabel
            // 
            this.ConsumptionLabel.AutoSize = true;
            this.ConsumptionLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ConsumptionLabel.Location = new System.Drawing.Point(83, 8);
            this.ConsumptionLabel.Name = "ConsumptionLabel";
            this.ConsumptionLabel.Size = new System.Drawing.Size(61, 12);
            this.ConsumptionLabel.TabIndex = 0;
            this.ConsumptionLabel.Text = "0kW / 0kW";
            this.ConsumptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RatioNotifyIcon
            // 
            this.RatioNotifyIcon.ContextMenuStrip = this.TasktrayContextMenuStrip;
            this.RatioNotifyIcon.Text = "RatioNotifyIcon";
            this.RatioNotifyIcon.Visible = true;
            this.RatioNotifyIcon.DoubleClick += new System.EventHandler(this.NormalizeItem_Click);
            // 
            // TasktrayContextMenuStrip
            // 
            this.TasktrayContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NormalizeToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.TasktrayContextMenuStrip.Name = "TasktrayContextMenuStrip";
            this.TasktrayContextMenuStrip.Size = new System.Drawing.Size(153, 70);
            // 
            // NormalizeToolStripMenuItem
            // 
            this.NormalizeToolStripMenuItem.Name = "NormalizeToolStripMenuItem";
            this.NormalizeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.NormalizeToolStripMenuItem.Text = "元に戻す";
            this.NormalizeToolStripMenuItem.Click += new System.EventHandler(this.NormalizeItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ExitToolStripMenuItem.Text = "終了";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 96);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.RatioLabel);
            this.Controls.Add(this.FooterStatusStrip);
            this.Controls.Add(this.AreaComboBox);
            this.Controls.Add(this.RatioProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "CubePower Monitor";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.FooterStatusStrip.ResumeLayout(false);
            this.FooterStatusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TasktrayContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar RatioProgressBar;
        private System.Windows.Forms.ComboBox AreaComboBox;
        private System.Windows.Forms.Label RatioLabel;
        private System.Windows.Forms.StatusStrip FooterStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel InfoToolStripStatusLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ConsumptionLabel;
        private System.Windows.Forms.NotifyIcon RatioNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip TasktrayContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem NormalizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
    }
}

