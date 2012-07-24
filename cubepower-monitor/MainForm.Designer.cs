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
            this.AreaComboBox = new System.Windows.Forms.ComboBox();
            this.RatioLabel = new System.Windows.Forms.Label();
            this.FooterStatusStrip = new System.Windows.Forms.StatusStrip();
            this.InfoToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ConsumptionLabel = new System.Windows.Forms.Label();
            this.RatioNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TasktrayContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Ratio50Label = new System.Windows.Forms.Label();
            this.Ratio100Label = new System.Windows.Forms.Label();
            this.Ratio60Label = new System.Windows.Forms.Label();
            this.Ratio70Label = new System.Windows.Forms.Label();
            this.Ratio80Label = new System.Windows.Forms.Label();
            this.Ratio90Label = new System.Windows.Forms.Label();
            this.RatioProgressBar = new ExtendedDotNET.Controls.Progress.ProgressBar();
            this.FooterStatusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.TasktrayContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
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
            this.RatioLabel.BackColor = System.Drawing.SystemColors.Control;
            this.RatioLabel.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RatioLabel.ForeColor = System.Drawing.Color.Black;
            this.RatioLabel.Location = new System.Drawing.Point(273, 28);
            this.RatioLabel.Margin = new System.Windows.Forms.Padding(0);
            this.RatioLabel.Name = "RatioLabel";
            this.RatioLabel.Size = new System.Drawing.Size(74, 37);
            this.RatioLabel.TabIndex = 2;
            this.RatioLabel.Text = "00%";
            // 
            // FooterStatusStrip
            // 
            this.FooterStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InfoToolStripStatusLabel});
            this.FooterStatusStrip.Location = new System.Drawing.Point(0, 83);
            this.FooterStatusStrip.Name = "FooterStatusStrip";
            this.FooterStatusStrip.Size = new System.Drawing.Size(370, 23);
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
            this.panel1.Location = new System.Drawing.Point(115, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.panel1.Size = new System.Drawing.Size(147, 20);
            this.panel1.TabIndex = 5;
            // 
            // ConsumptionLabel
            // 
            this.ConsumptionLabel.AutoSize = true;
            this.ConsumptionLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ConsumptionLabel.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ConsumptionLabel.Location = new System.Drawing.Point(86, 7);
            this.ConsumptionLabel.Margin = new System.Windows.Forms.Padding(0);
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
            this.RatioNotifyIcon.DoubleClick += new System.EventHandler(this.OpenItem_Click);
            // 
            // TasktrayContextMenuStrip
            // 
            this.TasktrayContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.TasktrayContextMenuStrip.Name = "TasktrayContextMenuStrip";
            this.TasktrayContextMenuStrip.Size = new System.Drawing.Size(95, 48);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.OpenToolStripMenuItem.Text = "開く";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.ExitToolStripMenuItem.Text = "終了";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // Ratio50Label
            // 
            this.Ratio50Label.AutoSize = true;
            this.Ratio50Label.Location = new System.Drawing.Point(6, 61);
            this.Ratio50Label.Name = "Ratio50Label";
            this.Ratio50Label.Size = new System.Drawing.Size(17, 12);
            this.Ratio50Label.TabIndex = 7;
            this.Ratio50Label.Text = "50";
            // 
            // Ratio100Label
            // 
            this.Ratio100Label.AutoSize = true;
            this.Ratio100Label.Location = new System.Drawing.Point(248, 61);
            this.Ratio100Label.Name = "Ratio100Label";
            this.Ratio100Label.Size = new System.Drawing.Size(23, 12);
            this.Ratio100Label.TabIndex = 8;
            this.Ratio100Label.Text = "100";
            // 
            // Ratio60Label
            // 
            this.Ratio60Label.AutoSize = true;
            this.Ratio60Label.Location = new System.Drawing.Point(56, 61);
            this.Ratio60Label.Name = "Ratio60Label";
            this.Ratio60Label.Size = new System.Drawing.Size(17, 12);
            this.Ratio60Label.TabIndex = 10;
            this.Ratio60Label.Text = "60";
            // 
            // Ratio70Label
            // 
            this.Ratio70Label.AutoSize = true;
            this.Ratio70Label.Location = new System.Drawing.Point(106, 61);
            this.Ratio70Label.Name = "Ratio70Label";
            this.Ratio70Label.Size = new System.Drawing.Size(17, 12);
            this.Ratio70Label.TabIndex = 11;
            this.Ratio70Label.Text = "70";
            // 
            // Ratio80Label
            // 
            this.Ratio80Label.AutoSize = true;
            this.Ratio80Label.Location = new System.Drawing.Point(156, 61);
            this.Ratio80Label.Name = "Ratio80Label";
            this.Ratio80Label.Size = new System.Drawing.Size(17, 12);
            this.Ratio80Label.TabIndex = 12;
            this.Ratio80Label.Text = "80";
            // 
            // Ratio90Label
            // 
            this.Ratio90Label.AutoSize = true;
            this.Ratio90Label.Location = new System.Drawing.Point(206, 61);
            this.Ratio90Label.Name = "Ratio90Label";
            this.Ratio90Label.Size = new System.Drawing.Size(17, 12);
            this.Ratio90Label.TabIndex = 13;
            this.Ratio90Label.Text = "90";
            // 
            // RatioProgressBar
            // 
            this.RatioProgressBar.BarOffset = 1;
            this.RatioProgressBar.Caption = "";
            this.RatioProgressBar.CaptionColor = System.Drawing.Color.Black;
            this.RatioProgressBar.CaptionMode = ExtendedDotNET.Controls.Progress.ProgressCaptionMode.None;
            this.RatioProgressBar.CaptionShadowColor = System.Drawing.Color.White;
            this.RatioProgressBar.CenterColor = System.Drawing.Color.Yellow;
            this.RatioProgressBar.ChangeByMouse = false;
            this.RatioProgressBar.DashSpace = 1;
            this.RatioProgressBar.DashWidth = 4;
            this.RatioProgressBar.Edge = ExtendedDotNET.Controls.Progress.ProgressBarEdge.Rounded;
            this.RatioProgressBar.EdgeColor = System.Drawing.SystemColors.ControlDark;
            this.RatioProgressBar.EdgeLightColor = System.Drawing.SystemColors.ControlLight;
            this.RatioProgressBar.EdgeWidth = 1;
            this.RatioProgressBar.FirstColor = System.Drawing.Color.Lime;
            this.RatioProgressBar.FloodPercentage = 1F;
            this.RatioProgressBar.FloodStyle = ExtendedDotNET.Controls.Progress.ProgressFloodStyle.Horizontal;
            this.RatioProgressBar.Invert = false;
            this.RatioProgressBar.LastColor = System.Drawing.Color.Red;
            this.RatioProgressBar.Location = new System.Drawing.Point(12, 38);
            this.RatioProgressBar.Maximum = 100;
            this.RatioProgressBar.Minimum = 50;
            this.RatioProgressBar.Name = "RatioProgressBar";
            this.RatioProgressBar.Orientation = ExtendedDotNET.Controls.Progress.ProgressBarDirection.Horizontal;
            this.RatioProgressBar.ProgressBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.RatioProgressBar.ProgressBarStyle = ExtendedDotNET.Controls.Progress.ProgressStyle.Dashed;
            this.RatioProgressBar.Shadow = true;
            this.RatioProgressBar.ShadowOffset = 1;
            this.RatioProgressBar.Size = new System.Drawing.Size(250, 20);
            this.RatioProgressBar.Step = 1;
            this.RatioProgressBar.TabIndex = 6;
            this.RatioProgressBar.TabStop = false;
            this.RatioProgressBar.TextAntialias = true;
            this.RatioProgressBar.Value = 50;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(370, 106);
            this.Controls.Add(this.Ratio90Label);
            this.Controls.Add(this.Ratio80Label);
            this.Controls.Add(this.Ratio70Label);
            this.Controls.Add(this.Ratio60Label);
            this.Controls.Add(this.Ratio50Label);
            this.Controls.Add(this.Ratio100Label);
            this.Controls.Add(this.RatioProgressBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.FooterStatusStrip);
            this.Controls.Add(this.AreaComboBox);
            this.Controls.Add(this.RatioLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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

        private System.Windows.Forms.ComboBox AreaComboBox;
        private System.Windows.Forms.Label RatioLabel;
        private System.Windows.Forms.StatusStrip FooterStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel InfoToolStripStatusLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ConsumptionLabel;
        private System.Windows.Forms.NotifyIcon RatioNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip TasktrayContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private ExtendedDotNET.Controls.Progress.ProgressBar RatioProgressBar;
        private System.Windows.Forms.Label Ratio50Label;
        private System.Windows.Forms.Label Ratio100Label;
        private System.Windows.Forms.Label Ratio60Label;
        private System.Windows.Forms.Label Ratio70Label;
        private System.Windows.Forms.Label Ratio80Label;
        private System.Windows.Forms.Label Ratio90Label;
    }
}

