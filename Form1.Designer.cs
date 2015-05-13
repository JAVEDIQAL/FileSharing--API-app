namespace ReClient_ServerWinforms
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
            this.IPAddr_Serv = new System.Windows.Forms.TextBox();
            this.SelectFile = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.IPAddr_Client = new System.Windows.Forms.TextBox();
            this.PortNo_Client = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label_server = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnlisten = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.PortNo_serv = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CLear = new System.Windows.Forms.Button();
            this.labelProgress = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstLocal = new System.Windows.Forms.ListView();
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Host = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Refresh_button = new System.Windows.Forms.Button();
            this.SS = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SS.SuspendLayout();
            this.SuspendLayout();
            // 
            // IPAddr_Serv
            // 
            this.IPAddr_Serv.Location = new System.Drawing.Point(90, 37);
            this.IPAddr_Serv.Name = "IPAddr_Serv";
            this.IPAddr_Serv.Size = new System.Drawing.Size(117, 20);
            this.IPAddr_Serv.TabIndex = 2;
            // 
            // SelectFile
            // 
            this.SelectFile.Location = new System.Drawing.Point(107, 129);
            this.SelectFile.Name = "SelectFile";
            this.SelectFile.Size = new System.Drawing.Size(197, 20);
            this.SelectFile.TabIndex = 7;
            // 
            // btnBrowse
            // 
            this.btnBrowse.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnBrowse.Location = new System.Drawing.Point(326, 126);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 8;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click_1);
            // 
            // btnSend
            // 
            this.btnSend.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnSend.Location = new System.Drawing.Point(290, 162);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click_1);
            // 
            // IPAddr_Client
            // 
            this.IPAddr_Client.Location = new System.Drawing.Point(107, 33);
            this.IPAddr_Client.Name = "IPAddr_Client";
            this.IPAddr_Client.Size = new System.Drawing.Size(100, 20);
            this.IPAddr_Client.TabIndex = 10;
            // 
            // PortNo_Client
            // 
            this.PortNo_Client.Location = new System.Drawing.Point(107, 83);
            this.PortNo_Client.Name = "PortNo_Client";
            this.PortNo_Client.Size = new System.Drawing.Size(100, 20);
            this.PortNo_Client.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.label_server);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.btnlisten);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.PortNo_serv);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.IPAddr_Serv);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(603, 138);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server";
            // 
            // btnClear
            // 
            this.btnClear.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnClear.Location = new System.Drawing.Point(496, 109);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label_server
            // 
            this.label_server.AutoSize = true;
            this.label_server.Location = new System.Drawing.Point(499, 37);
            this.label_server.Name = "label_server";
            this.label_server.Size = new System.Drawing.Size(0, 13);
            this.label_server.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(493, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 8;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(401, 37);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(86, 57);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // btnlisten
            // 
            this.btnlisten.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnlisten.Location = new System.Drawing.Point(316, 109);
            this.btnlisten.Name = "btnlisten";
            this.btnlisten.Size = new System.Drawing.Size(75, 23);
            this.btnlisten.TabIndex = 6;
            this.btnlisten.Text = "Listen";
            this.btnlisten.UseVisualStyleBackColor = true;
            this.btnlisten.Click += new System.EventHandler(this.btnlisten_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Port No.";
            // 
            // PortNo_serv
            // 
            this.PortNo_serv.Location = new System.Drawing.Point(90, 96);
            this.PortNo_serv.Name = "PortNo_serv";
            this.PortNo_serv.Size = new System.Drawing.Size(117, 20);
            this.PortNo_serv.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Server IP";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CLear);
            this.groupBox2.Controls.Add(this.labelProgress);
            this.groupBox2.Controls.Add(this.btn_Cancel);
            this.groupBox2.Controls.Add(this.pictureBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnSend);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.SelectFile);
            this.groupBox2.Controls.Add(this.IPAddr_Client);
            this.groupBox2.Controls.Add(this.btnBrowse);
            this.groupBox2.Controls.Add(this.PortNo_Client);
            this.groupBox2.Location = new System.Drawing.Point(0, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(603, 191);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Client";
            // 
            // CLear
            // 
            this.CLear.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.CLear.Location = new System.Drawing.Point(517, 162);
            this.CLear.Name = "CLear";
            this.CLear.Size = new System.Drawing.Size(75, 23);
            this.CLear.TabIndex = 18;
            this.CLear.Text = "Clear";
            this.CLear.UseVisualStyleBackColor = true;
            this.CLear.Click += new System.EventHandler(this.CLear_Click);
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(458, 60);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(0, 13);
            this.labelProgress.TabIndex = 17;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_Cancel.Location = new System.Drawing.Point(412, 162);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 16;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(401, 40);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(51, 50);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Select File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Port No.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Client IP";
            // 
            // lstLocal
            // 
            this.lstLocal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IP,
            this.Host});
            this.lstLocal.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lstLocal.FullRowSelect = true;
            this.lstLocal.GridLines = true;
            this.lstLocal.Location = new System.Drawing.Point(598, 27);
            this.lstLocal.Name = "lstLocal";
            this.lstLocal.Size = new System.Drawing.Size(409, 282);
            this.lstLocal.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lstLocal.TabIndex = 18;
            this.lstLocal.UseCompatibleStateImageBehavior = false;
            this.lstLocal.SelectedIndexChanged += new System.EventHandler(this.lstLocal_SelectedIndexChanged);
            // 
            // Refresh_button
            // 
            this.Refresh_button.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Refresh_button.Location = new System.Drawing.Point(918, 329);
            this.Refresh_button.Name = "Refresh_button";
            this.Refresh_button.Size = new System.Drawing.Size(75, 23);
            this.Refresh_button.TabIndex = 19;
            this.Refresh_button.Text = "Refresh";
            this.Refresh_button.UseVisualStyleBackColor = true;
            this.Refresh_button.Click += new System.EventHandler(this.Refresh_button_Click);
            // 
            // SS
            // 
            this.SS.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel4});
            this.SS.Location = new System.Drawing.Point(0, 382);
            this.SS.Name = "SS";
            this.SS.Size = new System.Drawing.Size(1018, 22);
            this.SS.TabIndex = 50;
            this.SS.Text = "SS";
            this.SS.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.SS_ItemClicked);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.IsLink = true;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(84, 17);
            this.toolStripStatusLabel2.Text = "puetechh.com";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(444, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(444, 17);
            this.toolStripStatusLabel4.Spring = true;
            this.toolStripStatusLabel4.Text = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Click += new System.EventHandler(this.toolStripStatusLabel4_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1018, 24);
            this.menuStrip1.TabIndex = 51;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(316, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(8, 8);
            this.listView1.TabIndex = 52;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1018, 404);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.SS);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.Refresh_button);
            this.Controls.Add(this.lstLocal);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileSharo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.SS.ResumeLayout(false);
            this.SS.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IPAddr_Serv;
        private System.Windows.Forms.TextBox SelectFile;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox IPAddr_Client;
        private System.Windows.Forms.TextBox PortNo_Client;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PortNo_serv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnlisten;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label_server;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListView lstLocal;
        private System.Windows.Forms.Button Refresh_button;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.ColumnHeader Host;
        private System.Windows.Forms.Button CLear;
        private System.Windows.Forms.StatusStrip SS;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ListView listView1;
    }
}

