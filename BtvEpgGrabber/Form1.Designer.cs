namespace BtvEpgGrabber
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MakeChannelBtn = new System.Windows.Forms.Button();
            this.buttonMakeEpg = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.checkBoxAutoSearch = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoExit = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoCopy = new System.Windows.Forms.CheckBox();
            this.buttonSelectPath = new System.Windows.Forms.Button();
            this.checkBoxAddTime = new System.Windows.Forms.CheckBox();
            this.numericUpDownDay = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCopyPath = new System.Windows.Forms.TextBox();
            this.checkBoxRun = new System.Windows.Forms.CheckBox();
            this.textBoxRun = new System.Windows.Forms.TextBox();
            this.buttonSelectPathRun = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDay)).BeginInit();
            this.SuspendLayout();
            // 
            // MakeChannelBtn
            // 
            this.MakeChannelBtn.Location = new System.Drawing.Point(54, 405);
            this.MakeChannelBtn.Name = "MakeChannelBtn";
            this.MakeChannelBtn.Size = new System.Drawing.Size(112, 31);
            this.MakeChannelBtn.TabIndex = 0;
            this.MakeChannelBtn.Text = "채널 정보 생성";
            this.MakeChannelBtn.UseVisualStyleBackColor = true;
            this.MakeChannelBtn.Click += new System.EventHandler(this.MakeChannelBtn_Click);
            // 
            // buttonMakeEpg
            // 
            this.buttonMakeEpg.Location = new System.Drawing.Point(229, 448);
            this.buttonMakeEpg.Name = "buttonMakeEpg";
            this.buttonMakeEpg.Size = new System.Drawing.Size(125, 38);
            this.buttonMakeEpg.TabIndex = 1;
            this.buttonMakeEpg.Text = "EPG 생성";
            this.buttonMakeEpg.UseVisualStyleBackColor = true;
            this.buttonMakeEpg.Click += new System.EventHandler(this.buttonMakeEpg_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxLog);
            this.groupBox1.Location = new System.Drawing.Point(29, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 63);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(15, 20);
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.Size = new System.Drawing.Size(513, 21);
            this.textBoxLog.TabIndex = 3;
            // 
            // checkBoxAutoSearch
            // 
            this.checkBoxAutoSearch.AutoSize = true;
            this.checkBoxAutoSearch.Location = new System.Drawing.Point(54, 116);
            this.checkBoxAutoSearch.Name = "checkBoxAutoSearch";
            this.checkBoxAutoSearch.Size = new System.Drawing.Size(76, 16);
            this.checkBoxAutoSearch.TabIndex = 4;
            this.checkBoxAutoSearch.Text = "자동 검색";
            this.checkBoxAutoSearch.UseVisualStyleBackColor = true;
            this.checkBoxAutoSearch.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBoxAutoExit
            // 
            this.checkBoxAutoExit.AutoSize = true;
            this.checkBoxAutoExit.Location = new System.Drawing.Point(54, 158);
            this.checkBoxAutoExit.Name = "checkBoxAutoExit";
            this.checkBoxAutoExit.Size = new System.Drawing.Size(76, 16);
            this.checkBoxAutoExit.TabIndex = 6;
            this.checkBoxAutoExit.Text = "자동 종료";
            this.checkBoxAutoExit.UseVisualStyleBackColor = true;
            this.checkBoxAutoExit.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBoxAutoCopy
            // 
            this.checkBoxAutoCopy.AutoSize = true;
            this.checkBoxAutoCopy.Location = new System.Drawing.Point(54, 204);
            this.checkBoxAutoCopy.Name = "checkBoxAutoCopy";
            this.checkBoxAutoCopy.Size = new System.Drawing.Size(76, 16);
            this.checkBoxAutoCopy.TabIndex = 7;
            this.checkBoxAutoCopy.Text = "자동 복사";
            this.checkBoxAutoCopy.UseVisualStyleBackColor = true;
            this.checkBoxAutoCopy.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // buttonSelectPath
            // 
            this.buttonSelectPath.Location = new System.Drawing.Point(482, 224);
            this.buttonSelectPath.Name = "buttonSelectPath";
            this.buttonSelectPath.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectPath.TabIndex = 9;
            this.buttonSelectPath.Text = "...";
            this.buttonSelectPath.UseVisualStyleBackColor = true;
            this.buttonSelectPath.Click += new System.EventHandler(this.buttonSelectPath_Click);
            // 
            // checkBoxAddTime
            // 
            this.checkBoxAddTime.AutoSize = true;
            this.checkBoxAddTime.Location = new System.Drawing.Point(54, 275);
            this.checkBoxAddTime.Name = "checkBoxAddTime";
            this.checkBoxAddTime.Size = new System.Drawing.Size(111, 16);
            this.checkBoxAddTime.TabIndex = 10;
            this.checkBoxAddTime.Text = "EPG 9시간 추가";
            this.checkBoxAddTime.UseVisualStyleBackColor = true;
            this.checkBoxAddTime.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // numericUpDownDay
            // 
            this.numericUpDownDay.Location = new System.Drawing.Point(229, 115);
            this.numericUpDownDay.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDownDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDay.Name = "numericUpDownDay";
            this.numericUpDownDay.Size = new System.Drawing.Size(53, 21);
            this.numericUpDownDay.TabIndex = 11;
            this.numericUpDownDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDay.ValueChanged += new System.EventHandler(this.numericUpDownDay_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "검색 분량(일) :";
            // 
            // textBoxCopyPath
            // 
            this.textBoxCopyPath.Location = new System.Drawing.Point(69, 226);
            this.textBoxCopyPath.Name = "textBoxCopyPath";
            this.textBoxCopyPath.ReadOnly = true;
            this.textBoxCopyPath.Size = new System.Drawing.Size(395, 21);
            this.textBoxCopyPath.TabIndex = 13;
            this.textBoxCopyPath.Text = "C:\\epg.xml";
            // 
            // checkBoxRun
            // 
            this.checkBoxRun.AutoSize = true;
            this.checkBoxRun.Location = new System.Drawing.Point(54, 315);
            this.checkBoxRun.Name = "checkBoxRun";
            this.checkBoxRun.Size = new System.Drawing.Size(116, 16);
            this.checkBoxRun.TabIndex = 14;
            this.checkBoxRun.Text = "생성 후 자동실행";
            this.checkBoxRun.UseVisualStyleBackColor = true;
            this.checkBoxRun.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // textBoxRun
            // 
            this.textBoxRun.Location = new System.Drawing.Point(69, 339);
            this.textBoxRun.Name = "textBoxRun";
            this.textBoxRun.ReadOnly = true;
            this.textBoxRun.Size = new System.Drawing.Size(395, 21);
            this.textBoxRun.TabIndex = 16;
            // 
            // buttonSelectPathRun
            // 
            this.buttonSelectPathRun.Location = new System.Drawing.Point(482, 337);
            this.buttonSelectPathRun.Name = "buttonSelectPathRun";
            this.buttonSelectPathRun.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectPathRun.TabIndex = 15;
            this.buttonSelectPathRun.Text = "...";
            this.buttonSelectPathRun.UseVisualStyleBackColor = true;
            this.buttonSelectPathRun.Click += new System.EventHandler(this.buttonSelectPathRun_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 512);
            this.Controls.Add(this.textBoxRun);
            this.Controls.Add(this.buttonSelectPathRun);
            this.Controls.Add(this.checkBoxRun);
            this.Controls.Add(this.textBoxCopyPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownDay);
            this.Controls.Add(this.checkBoxAddTime);
            this.Controls.Add(this.buttonSelectPath);
            this.Controls.Add(this.checkBoxAutoCopy);
            this.Controls.Add(this.checkBoxAutoExit);
            this.Controls.Add(this.checkBoxAutoSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonMakeEpg);
            this.Controls.Add(this.MakeChannelBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "BTV EPG Gragbber";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MakeChannelBtn;
        private System.Windows.Forms.Button buttonMakeEpg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxAutoSearch;
        private System.Windows.Forms.CheckBox checkBoxAutoExit;
        private System.Windows.Forms.CheckBox checkBoxAutoCopy;
        private System.Windows.Forms.Button buttonSelectPath;
        private System.Windows.Forms.CheckBox checkBoxAddTime;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.NumericUpDown numericUpDownDay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCopyPath;
        private System.Windows.Forms.CheckBox checkBoxRun;
        private System.Windows.Forms.TextBox textBoxRun;
        private System.Windows.Forms.Button buttonSelectPathRun;
    }
}

