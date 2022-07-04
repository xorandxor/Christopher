namespace Monitor
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
            this.components = new System.ComponentModel.Container();
            this.listbox = new System.Windows.Forms.ListBox();
            this.txtApi = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGoogle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.panelAPITime = new System.Windows.Forms.Panel();
            this.panelWebSiteTime = new System.Windows.Forms.Panel();
            this.panelDBStatus = new System.Windows.Forms.Panel();
            this.panelTradeProc = new System.Windows.Forms.Panel();
            this.lblAPIResponsetime = new System.Windows.Forms.Label();
            this.lblGoogleResponsetime = new System.Windows.Forms.Label();
            this.lblTimerInfo = new System.Windows.Forms.Label();
            this.lblTimerState = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listbox
            // 
            this.listbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listbox.FormattingEnabled = true;
            this.listbox.ItemHeight = 16;
            this.listbox.Location = new System.Drawing.Point(10, 10);
            this.listbox.Name = "listbox";
            this.listbox.Size = new System.Drawing.Size(329, 583);
            this.listbox.TabIndex = 0;
            // 
            // txtApi
            // 
            this.txtApi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApi.Location = new System.Drawing.Point(21, 101);
            this.txtApi.Name = "txtApi";
            this.txtApi.Size = new System.Drawing.Size(288, 30);
            this.txtApi.TabIndex = 1;
            this.txtApi.Text = "https://api.kraken.com/0/public/SystemStatus";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listbox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(786, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(349, 603);
            this.panel1.TabIndex = 2;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(783, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 603);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 603);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "API Server URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Database Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Google.com";
            // 
            // txtGoogle
            // 
            this.txtGoogle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGoogle.Location = new System.Drawing.Point(21, 166);
            this.txtGoogle.Name = "txtGoogle";
            this.txtGoogle.Size = new System.Drawing.Size(288, 30);
            this.txtGoogle.TabIndex = 8;
            this.txtGoogle.Text = "https://www.google.com";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "Trading Process";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(12, 10);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(133, 40);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "Start Timer";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panelAPITime
            // 
            this.panelAPITime.Location = new System.Drawing.Point(316, 101);
            this.panelAPITime.Name = "panelAPITime";
            this.panelAPITime.Size = new System.Drawing.Size(30, 30);
            this.panelAPITime.TabIndex = 13;
            // 
            // panelWebSiteTime
            // 
            this.panelWebSiteTime.Location = new System.Drawing.Point(316, 166);
            this.panelWebSiteTime.Name = "panelWebSiteTime";
            this.panelWebSiteTime.Size = new System.Drawing.Size(29, 30);
            this.panelWebSiteTime.TabIndex = 14;
            // 
            // panelDBStatus
            // 
            this.panelDBStatus.Location = new System.Drawing.Point(156, 219);
            this.panelDBStatus.Name = "panelDBStatus";
            this.panelDBStatus.Size = new System.Drawing.Size(25, 25);
            this.panelDBStatus.TabIndex = 14;
            // 
            // panelTradeProc
            // 
            this.panelTradeProc.Location = new System.Drawing.Point(156, 260);
            this.panelTradeProc.Name = "panelTradeProc";
            this.panelTradeProc.Size = new System.Drawing.Size(25, 25);
            this.panelTradeProc.TabIndex = 15;
            // 
            // lblAPIResponsetime
            // 
            this.lblAPIResponsetime.AutoSize = true;
            this.lblAPIResponsetime.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAPIResponsetime.Location = new System.Drawing.Point(352, 108);
            this.lblAPIResponsetime.Name = "lblAPIResponsetime";
            this.lblAPIResponsetime.Size = new System.Drawing.Size(124, 23);
            this.lblAPIResponsetime.TabIndex = 16;
            this.lblAPIResponsetime.Text = "Response Time";
            // 
            // lblGoogleResponsetime
            // 
            this.lblGoogleResponsetime.AutoSize = true;
            this.lblGoogleResponsetime.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoogleResponsetime.Location = new System.Drawing.Point(352, 169);
            this.lblGoogleResponsetime.Name = "lblGoogleResponsetime";
            this.lblGoogleResponsetime.Size = new System.Drawing.Size(124, 23);
            this.lblGoogleResponsetime.TabIndex = 17;
            this.lblGoogleResponsetime.Text = "Response Time";
            // 
            // lblTimerInfo
            // 
            this.lblTimerInfo.AutoSize = true;
            this.lblTimerInfo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimerInfo.Location = new System.Drawing.Point(288, 19);
            this.lblTimerInfo.Name = "lblTimerInfo";
            this.lblTimerInfo.Size = new System.Drawing.Size(57, 23);
            this.lblTimerInfo.TabIndex = 18;
            this.lblTimerInfo.Text = "Timer:";
            // 
            // lblTimerState
            // 
            this.lblTimerState.AutoSize = true;
            this.lblTimerState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimerState.Location = new System.Drawing.Point(152, 19);
            this.lblTimerState.Name = "lblTimerState";
            this.lblTimerState.Size = new System.Drawing.Size(121, 23);
            this.lblTimerState.TabIndex = 19;
            this.lblTimerState.Text = "Timer Stopped";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 603);
            this.Controls.Add(this.lblTimerState);
            this.Controls.Add(this.lblTimerInfo);
            this.Controls.Add(this.lblGoogleResponsetime);
            this.Controls.Add(this.lblAPIResponsetime);
            this.Controls.Add(this.panelTradeProc);
            this.Controls.Add(this.panelWebSiteTime);
            this.Controls.Add(this.panelDBStatus);
            this.Controls.Add(this.panelAPITime);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGoogle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtApi);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listbox;
        private System.Windows.Forms.TextBox txtApi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGoogle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panelAPITime;
        private System.Windows.Forms.Panel panelWebSiteTime;
        private System.Windows.Forms.Panel panelDBStatus;
        private System.Windows.Forms.Panel panelTradeProc;
        private System.Windows.Forms.Label lblAPIResponsetime;
        private System.Windows.Forms.Label lblGoogleResponsetime;
        private System.Windows.Forms.Label lblTimerInfo;
        private System.Windows.Forms.Label lblTimerState;
    }
}

