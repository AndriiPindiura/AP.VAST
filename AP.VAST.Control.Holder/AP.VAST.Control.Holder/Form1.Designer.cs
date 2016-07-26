namespace AP.VAST.Control.Holder
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.streamId = new System.Windows.Forms.NumericUpDown();
            this.cameraId = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.serverPort = new System.Windows.Forms.NumericUpDown();
            this.serverIp = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.streamId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverPort)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.date);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.streamId);
            this.panel1.Controls.Add(this.cameraId);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.password);
            this.panel1.Controls.Add(this.login);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.serverPort);
            this.panel1.Controls.Add(this.serverIp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(601, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(214, 512);
            this.panel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(155, 155);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(47, 20);
            this.button3.TabIndex = 12;
            this.button3.Text = "Play";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // date
            // 
            this.date.CustomFormat = "dd\'.\'MM\'.\'yyyy hh\':\'mm\':\'ss";
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date.Location = new System.Drawing.Point(6, 155);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(143, 20);
            this.date.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(155, 129);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 20);
            this.button2.TabIndex = 10;
            this.button2.Text = "Live";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // streamId
            // 
            this.streamId.Location = new System.Drawing.Point(94, 129);
            this.streamId.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.streamId.Name = "streamId";
            this.streamId.Size = new System.Drawing.Size(55, 20);
            this.streamId.TabIndex = 9;
            this.streamId.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cameraId
            // 
            this.cameraId.Location = new System.Drawing.Point(6, 129);
            this.cameraId.Name = "cameraId";
            this.cameraId.Size = new System.Drawing.Size(56, 20);
            this.cameraId.TabIndex = 8;
            this.cameraId.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(156, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 58);
            this.button1.TabIndex = 7;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(6, 103);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(143, 20);
            this.password.TabIndex = 6;
            this.password.Text = "admin";
            this.password.UseSystemPasswordChar = true;
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(6, 65);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(143, 20);
            this.login.TabIndex = 5;
            this.login.Text = "admin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Login:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "VAST Server:";
            // 
            // serverPort
            // 
            this.serverPort.Location = new System.Drawing.Point(155, 26);
            this.serverPort.Maximum = new decimal(new int[] {
            65534,
            0,
            0,
            0});
            this.serverPort.Name = "serverPort";
            this.serverPort.Size = new System.Drawing.Size(47, 20);
            this.serverPort.TabIndex = 1;
            this.serverPort.Value = new decimal(new int[] {
            3454,
            0,
            0,
            0});
            // 
            // serverIp
            // 
            this.serverIp.Location = new System.Drawing.Point(6, 26);
            this.serverIp.Name = "serverIp";
            this.serverIp.Size = new System.Drawing.Size(143, 20);
            this.serverIp.TabIndex = 0;
            this.serverIp.Text = "127.0.0.1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(815, 512);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "VAST Control holder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.streamId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown serverPort;
        private System.Windows.Forms.TextBox serverIp;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown streamId;
        private System.Windows.Forms.NumericUpDown cameraId;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Button button3;
    }
}

