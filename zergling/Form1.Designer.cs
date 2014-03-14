namespace zergling
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
            this.EmailInput = new System.Windows.Forms.TextBox();
            this.IDInput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // EmailInput
            // 
            this.EmailInput.ForeColor = System.Drawing.Color.SlateGray;
            this.EmailInput.Location = new System.Drawing.Point(12, 12);
            this.EmailInput.Name = "EmailInput";
            this.EmailInput.Size = new System.Drawing.Size(154, 20);
            this.EmailInput.TabIndex = 0;
            this.EmailInput.Text = "Username";
            this.EmailInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EmailInput.TextChanged += new System.EventHandler(this.EmailInput_TextChanged);
            this.EmailInput.Leave += new System.EventHandler(this.EmailInput_Leave);
            // 
            // IDInput
            // 
            this.IDInput.ForeColor = System.Drawing.Color.SlateGray;
            this.IDInput.Location = new System.Drawing.Point(12, 38);
            this.IDInput.Name = "IDInput";
            this.IDInput.Size = new System.Drawing.Size(154, 20);
            this.IDInput.TabIndex = 1;
            this.IDInput.Text = "worker key";
            this.IDInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IDInput.TextChanged += new System.EventHandler(this.IDInput_TextChanged);
            this.IDInput.Leave += new System.EventHandler(this.IDInput_Leave);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(51, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(51, 111);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(75, 23);
            this.LoginBtn.TabIndex = 3;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "CGminer",
            "Cudaminer",
            "SGminer",
            "CPUminer"});
            this.comboBox1.Location = new System.Drawing.Point(12, 64);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(154, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "CGminer";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(187, 175);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IDInput);
            this.Controls.Add(this.EmailInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Zergling";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EmailInput;
        private System.Windows.Forms.TextBox IDInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox comboBox1;

    }
}