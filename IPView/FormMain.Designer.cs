namespace IPView
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.tbIpList = new System.Windows.Forms.TextBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.tbStartIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFinishIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTilte = new System.Windows.Forms.Label();
            this.panelBottom.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.buttonStop);
            this.panelBottom.Controls.Add(this.buttonStart);
            this.panelBottom.Controls.Add(this.buttonClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(4, 253);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panelBottom.Size = new System.Drawing.Size(541, 44);
            this.panelBottom.TabIndex = 0;
            // 
            // buttonStart
            // 
            this.buttonStart.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonStart.Location = new System.Drawing.Point(0, 4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(111, 36);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Старт";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.Location = new System.Drawing.Point(430, 4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(111, 36);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.Control;
            this.panelMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.tbIpList);
            this.panelMain.Controls.Add(this.panelTop);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelMain.Location = new System.Drawing.Point(4, 8);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(4);
            this.panelMain.Size = new System.Drawing.Size(541, 245);
            this.panelMain.TabIndex = 1;
            // 
            // tbIpList
            // 
            this.tbIpList.BackColor = System.Drawing.SystemColors.Window;
            this.tbIpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbIpList.Location = new System.Drawing.Point(4, 62);
            this.tbIpList.Multiline = true;
            this.tbIpList.Name = "tbIpList";
            this.tbIpList.ReadOnly = true;
            this.tbIpList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbIpList.Size = new System.Drawing.Size(531, 177);
            this.tbIpList.TabIndex = 2;
            // 
            // buttonStop
            // 
            this.buttonStop.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonStop.Location = new System.Drawing.Point(111, 4);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(111, 36);
            this.buttonStop.TabIndex = 5;
            this.buttonStop.Text = "Стоп";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Visible = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.tbStartIP);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.tbFinishIP);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.labelTilte);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(4, 4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(531, 58);
            this.panelTop.TabIndex = 3;
            // 
            // tbStartIP
            // 
            this.tbStartIP.BackColor = System.Drawing.SystemColors.Window;
            this.tbStartIP.Location = new System.Drawing.Point(113, 27);
            this.tbStartIP.Name = "tbStartIP";
            this.tbStartIP.Size = new System.Drawing.Size(100, 20);
            this.tbStartIP.TabIndex = 10;
            this.tbStartIP.Tag = "0";
            this.tbStartIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbIP_KeyPress);
            this.tbStartIP.Validating += new System.ComponentModel.CancelEventHandler(this.tbIP_Validating);
            this.tbStartIP.Validated += new System.EventHandler(this.tbIP_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Конечное значение:";
            // 
            // tbFinishIP
            // 
            this.tbFinishIP.Location = new System.Drawing.Point(333, 27);
            this.tbFinishIP.Name = "tbFinishIP";
            this.tbFinishIP.Size = new System.Drawing.Size(100, 20);
            this.tbFinishIP.TabIndex = 11;
            this.tbFinishIP.Tag = "1";
            this.tbFinishIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbIP_KeyPress);
            this.tbFinishIP.Validating += new System.ComponentModel.CancelEventHandler(this.tbIP_Validating);
            this.tbFinishIP.Validated += new System.EventHandler(this.tbIP_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Начальное значение:";
            // 
            // labelTilte
            // 
            this.labelTilte.AutoSize = true;
            this.labelTilte.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTilte.Location = new System.Drawing.Point(0, 0);
            this.labelTilte.Name = "labelTilte";
            this.labelTilte.Size = new System.Drawing.Size(214, 13);
            this.labelTilte.TabIndex = 12;
            this.labelTilte.Text = "Укажите диапазон значений IP-адресов:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 301);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelBottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IP View";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelBottom.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TextBox tbIpList;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox tbStartIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFinishIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTilte;
    }
}

