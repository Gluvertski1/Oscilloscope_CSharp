namespace Oscilliscope1
{
    partial class Oscilloscope
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.collectButton = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.deviceControls = new System.Windows.Forms.GroupBox();
            this.lowChannel = new System.Windows.Forms.NumericUpDown();
            this.highChannel = new System.Windows.Forms.NumericUpDown();
            this.rate = new System.Windows.Forms.NumericUpDown();
            this.samplesPerChannel = new System.Windows.Forms.NumericUpDown();
            this.voltageRange = new System.Windows.Forms.ComboBox();
            this.terminalConfig = new System.Windows.Forms.ComboBox();
            this.deviceName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acquireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpenDlg = new System.Windows.Forms.OpenFileDialog();
            this.saveFD = new System.Windows.Forms.SaveFileDialog();
            this.deviceControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lowChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.highChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.samplesPerChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // collectButton
            // 
            this.collectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collectButton.Location = new System.Drawing.Point(474, 413);
            this.collectButton.Name = "collectButton";
            this.collectButton.Size = new System.Drawing.Size(170, 36);
            this.collectButton.TabIndex = 0;
            this.collectButton.Text = "Collect";
            this.collectButton.UseVisualStyleBackColor = true;
            this.collectButton.Click += new System.EventHandler(this.collectButton_Click);
            // 
            // stop
            // 
            this.stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stop.Location = new System.Drawing.Point(801, 413);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(170, 36);
            this.stop.TabIndex = 1;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // deviceControls
            // 
            this.deviceControls.Controls.Add(this.lowChannel);
            this.deviceControls.Controls.Add(this.highChannel);
            this.deviceControls.Controls.Add(this.rate);
            this.deviceControls.Controls.Add(this.samplesPerChannel);
            this.deviceControls.Controls.Add(this.voltageRange);
            this.deviceControls.Controls.Add(this.terminalConfig);
            this.deviceControls.Controls.Add(this.deviceName);
            this.deviceControls.Controls.Add(this.label7);
            this.deviceControls.Controls.Add(this.label6);
            this.deviceControls.Controls.Add(this.label5);
            this.deviceControls.Controls.Add(this.label4);
            this.deviceControls.Controls.Add(this.label3);
            this.deviceControls.Controls.Add(this.label2);
            this.deviceControls.Controls.Add(this.label1);
            this.deviceControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deviceControls.Location = new System.Drawing.Point(72, 42);
            this.deviceControls.Name = "deviceControls";
            this.deviceControls.Size = new System.Drawing.Size(320, 407);
            this.deviceControls.TabIndex = 2;
            this.deviceControls.TabStop = false;
            this.deviceControls.Text = "Device Controls";
            // 
            // lowChannel
            // 
            this.lowChannel.Location = new System.Drawing.Point(179, 134);
            this.lowChannel.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.lowChannel.Name = "lowChannel";
            this.lowChannel.Size = new System.Drawing.Size(120, 26);
            this.lowChannel.TabIndex = 12;
            this.lowChannel.ValueChanged += new System.EventHandler(this.lowChannel_ValueChanged);
            this.lowChannel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lowChannel_KeyPress);
            // 
            // highChannel
            // 
            this.highChannel.Location = new System.Drawing.Point(179, 86);
            this.highChannel.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.highChannel.Name = "highChannel";
            this.highChannel.Size = new System.Drawing.Size(120, 26);
            this.highChannel.TabIndex = 11;
            this.highChannel.ValueChanged += new System.EventHandler(this.highChannel_ValueChanged);
            this.highChannel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.highChannel_KeyPress);
            // 
            // rate
            // 
            this.rate.Location = new System.Drawing.Point(179, 339);
            this.rate.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.rate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rate.Name = "rate";
            this.rate.Size = new System.Drawing.Size(120, 26);
            this.rate.TabIndex = 10;
            this.rate.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.rate.ValueChanged += new System.EventHandler(this.rate_ValueChanged);
            // 
            // samplesPerChannel
            // 
            this.samplesPerChannel.Location = new System.Drawing.Point(179, 293);
            this.samplesPerChannel.Maximum = new decimal(new int[] {
            500000000,
            0,
            0,
            0});
            this.samplesPerChannel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.samplesPerChannel.Name = "samplesPerChannel";
            this.samplesPerChannel.Size = new System.Drawing.Size(120, 26);
            this.samplesPerChannel.TabIndex = 9;
            this.samplesPerChannel.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.samplesPerChannel.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // voltageRange
            // 
            this.voltageRange.FormattingEnabled = true;
            this.voltageRange.Items.AddRange(new object[] {
            "+/- 10V",
            "+/- 5V",
            "+/- 1V",
            "+/- 0.2V"});
            this.voltageRange.Location = new System.Drawing.Point(178, 226);
            this.voltageRange.Name = "voltageRange";
            this.voltageRange.Size = new System.Drawing.Size(121, 28);
            this.voltageRange.TabIndex = 8;
            this.voltageRange.Text = "+/- 10V";
            this.voltageRange.SelectedIndexChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            this.voltageRange.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.voltageRange_KeyPress);
            // 
            // terminalConfig
            // 
            this.terminalConfig.FormattingEnabled = true;
            this.terminalConfig.Items.AddRange(new object[] {
            "Differential",
            "RSE",
            "NRSE"});
            this.terminalConfig.Location = new System.Drawing.Point(178, 179);
            this.terminalConfig.Name = "terminalConfig";
            this.terminalConfig.Size = new System.Drawing.Size(121, 28);
            this.terminalConfig.TabIndex = 7;
            this.terminalConfig.Text = "Differential";
            this.terminalConfig.SelectedIndexChanged += new System.EventHandler(this.terminalConfig_SelectedIndexChanged);
            this.terminalConfig.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.terminalConfig_KeyPress);
            // 
            // deviceName
            // 
            this.deviceName.FormattingEnabled = true;
            this.deviceName.Items.AddRange(new object[] {
            "FakeDAQ"});
            this.deviceName.Location = new System.Drawing.Point(178, 39);
            this.deviceName.Name = "deviceName";
            this.deviceName.Size = new System.Drawing.Size(121, 28);
            this.deviceName.TabIndex = 6;
            this.deviceName.Text = "Dev1";
            this.deviceName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deviceName_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(65, 345);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Rate (Hz):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Samples/Channel:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Voltage Range:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Terminal Config:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Low Channel:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "High Channel:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Device Name:";
            // 
            // chart1
            // 
            chartArea1.AxisX.Title = "Time (s)";
            chartArea1.AxisY.Title = "Voltage (V)";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(431, 42);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(540, 345);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Voltage";
            title1.Text = "Voltage Input Oscilloscope";
            this.chart1.Titles.Add(title1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.acquireToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1028, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.menuToolStripMenuItem.Text = "&File";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.appendToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // appendToolStripMenuItem
            // 
            this.appendToolStripMenuItem.Name = "appendToolStripMenuItem";
            this.appendToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.appendToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.appendToolStripMenuItem.Text = "&Append";
            this.appendToolStripMenuItem.Click += new System.EventHandler(this.appendToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.quitToolStripMenuItem.Text = "&Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // acquireToolStripMenuItem
            // 
            this.acquireToolStripMenuItem.Name = "acquireToolStripMenuItem";
            this.acquireToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.acquireToolStripMenuItem.Text = "&Acquire";
            this.acquireToolStripMenuItem.Click += new System.EventHandler(this.acquireToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem1.Text = "&Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // Oscilloscope
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 502);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.deviceControls);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.collectButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Oscilloscope";
            this.Text = "8 Channel  Oscilloscope with Finite Samples";
            this.Load += new System.EventHandler(this.Oscilloscope_Load);
            this.deviceControls.ResumeLayout(false);
            this.deviceControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lowChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.highChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.samplesPerChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button collectButton;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.GroupBox deviceControls;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown samplesPerChannel;
        private System.Windows.Forms.ComboBox voltageRange;
        private System.Windows.Forms.ComboBox terminalConfig;
        private System.Windows.Forms.ComboBox deviceName;
        private System.Windows.Forms.NumericUpDown rate;
        private System.Windows.Forms.NumericUpDown lowChannel;
        private System.Windows.Forms.NumericUpDown highChannel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acquireToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog fileOpenDlg;
        private System.Windows.Forms.SaveFileDialog saveFD;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
    }
}

