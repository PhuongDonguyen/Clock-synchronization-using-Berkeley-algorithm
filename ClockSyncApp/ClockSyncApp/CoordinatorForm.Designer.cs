namespace ClockSyncApp
{
    partial class CoordinatorForm
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
            this.btnSync = new System.Windows.Forms.Button();
            this.txtMessageLog = new System.Windows.Forms.TextBox();
            this.coordinatorTimeLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtClientTimes = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSync
            // 
            this.btnSync.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnSync.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSync.Location = new System.Drawing.Point(0, 423);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(371, 38);
            this.btnSync.TabIndex = 0;
            this.btnSync.Text = "Bắt đầu đồng bộ";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // txtMessageLog
            // 
            this.txtMessageLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessageLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.txtMessageLog.Location = new System.Drawing.Point(2, 23);
            this.txtMessageLog.Multiline = true;
            this.txtMessageLog.Name = "txtMessageLog";
            this.txtMessageLog.ReadOnly = true;
            this.txtMessageLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessageLog.Size = new System.Drawing.Size(367, 154);
            this.txtMessageLog.TabIndex = 1;
            // 
            // coordinatorTimeLbl
            // 
            this.coordinatorTimeLbl.AutoSize = true;
            this.coordinatorTimeLbl.Font = new System.Drawing.Font("SF Mono", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.coordinatorTimeLbl.Location = new System.Drawing.Point(244, 22);
            this.coordinatorTimeLbl.Name = "coordinatorTimeLbl";
            this.coordinatorTimeLbl.Size = new System.Drawing.Size(58, 24);
            this.coordinatorTimeLbl.TabIndex = 2;
            this.coordinatorTimeLbl.Text = "time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF Mono", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thời gian máy chủ:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtMessageLog);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 244);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(371, 179);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "Message log";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txtClientTimes);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl2.Location = new System.Drawing.Point(0, 64);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(371, 180);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "Connected clients";
            // 
            // txtClientTimes
            // 
            this.txtClientTimes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtClientTimes.Location = new System.Drawing.Point(2, 23);
            this.txtClientTimes.Multiline = true;
            this.txtClientTimes.Name = "txtClientTimes";
            this.txtClientTimes.ReadOnly = true;
            this.txtClientTimes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtClientTimes.Size = new System.Drawing.Size(367, 155);
            this.txtClientTimes.TabIndex = 0;
            // 
            // CoordinatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(371, 461);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.coordinatorTimeLbl);
            this.Controls.Add(this.btnSync);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "CoordinatorForm";
            this.Text = "Máy chủ";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.TextBox txtMessageLog;
        private System.Windows.Forms.Label coordinatorTimeLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.TextBox txtClientTimes;
    }
}