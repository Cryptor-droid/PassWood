
namespace Passwood
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PWD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CFM = new System.Windows.Forms.TextBox();
            this.labl = new System.Windows.Forms.Label();
            this.Securityt = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.reg = new System.Windows.Forms.Button();
            this.Securityq = new System.Windows.Forms.Label();
            this.Logn = new System.Windows.Forms.Button();
            this.recv = new System.Windows.Forms.Button();
            this.shide = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Passwood.Properties.Resources.password;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PWD
            // 
            this.PWD.Location = new System.Drawing.Point(118, 51);
            this.PWD.Name = "PWD";
            this.PWD.Size = new System.Drawing.Size(308, 20);
            this.PWD.TabIndex = 1;
            this.PWD.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(208, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter and confirm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CFM
            // 
            this.CFM.Location = new System.Drawing.Point(118, 77);
            this.CFM.Name = "CFM";
            this.CFM.Size = new System.Drawing.Size(308, 20);
            this.CFM.TabIndex = 3;
            this.CFM.UseSystemPasswordChar = true;
            // 
            // labl
            // 
            this.labl.AutoSize = true;
            this.labl.Location = new System.Drawing.Point(274, 144);
            this.labl.Name = "labl";
            this.labl.Size = new System.Drawing.Size(137, 13);
            this.labl.TabIndex = 4;
            this.labl.Text = "Enter your security question";
            // 
            // Securityt
            // 
            this.Securityt.Location = new System.Drawing.Point(118, 160);
            this.Securityt.Name = "Securityt";
            this.Securityt.Size = new System.Drawing.Size(308, 20);
            this.Securityt.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(118, 199);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(308, 20);
            this.textBox2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Enter your question\'s answer";
            // 
            // reg
            // 
            this.reg.Location = new System.Drawing.Point(272, 225);
            this.reg.Name = "reg";
            this.reg.Size = new System.Drawing.Size(154, 27);
            this.reg.TabIndex = 8;
            this.reg.Text = "Register";
            this.reg.UseVisualStyleBackColor = true;
            this.reg.Click += new System.EventHandler(this.reg_Click);
            // 
            // Securityq
            // 
            this.Securityq.AutoSize = true;
            this.Securityq.Location = new System.Drawing.Point(37, 141);
            this.Securityq.Name = "Securityq";
            this.Securityq.Size = new System.Drawing.Size(0, 13);
            this.Securityq.TabIndex = 9;
            // 
            // Logn
            // 
            this.Logn.Location = new System.Drawing.Point(272, 103);
            this.Logn.Name = "Logn";
            this.Logn.Size = new System.Drawing.Size(154, 27);
            this.Logn.TabIndex = 10;
            this.Logn.Text = "Login";
            this.Logn.UseVisualStyleBackColor = true;
            this.Logn.Click += new System.EventHandler(this.Logn_Click);
            // 
            // recv
            // 
            this.recv.Location = new System.Drawing.Point(12, 245);
            this.recv.Name = "recv";
            this.recv.Size = new System.Drawing.Size(84, 23);
            this.recv.TabIndex = 11;
            this.recv.Text = "Recover key";
            this.recv.UseVisualStyleBackColor = true;
            this.recv.Click += new System.EventHandler(this.recv_Click);
            // 
            // shide
            // 
            this.shide.Location = new System.Drawing.Point(70, 49);
            this.shide.Name = "shide";
            this.shide.Size = new System.Drawing.Size(42, 23);
            this.shide.TabIndex = 12;
            this.shide.Text = "Show";
            this.shide.UseVisualStyleBackColor = true;
            this.shide.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Clear Entries";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 280);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.shide);
            this.Controls.Add(this.recv);
            this.Controls.Add(this.Logn);
            this.Controls.Add(this.Securityq);
            this.Controls.Add(this.reg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Securityt);
            this.Controls.Add(this.labl);
            this.Controls.Add(this.CFM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PWD);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.ShowIcon = false;
            this.Text = "Passwood - Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox PWD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CFM;
        private System.Windows.Forms.Label labl;
        private System.Windows.Forms.TextBox Securityt;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button reg;
        private System.Windows.Forms.Label Securityq;
        private System.Windows.Forms.Button Logn;
        private System.Windows.Forms.Button recv;
        private System.Windows.Forms.Button shide;
        private System.Windows.Forms.Button button1;
    }
}