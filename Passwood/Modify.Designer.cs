
namespace Passwood
{
    partial class Modify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Modify));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.WebsiteUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PWD = new System.Windows.Forms.TextBox();
            this.HIDE = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.focusCheck = new System.Windows.Forms.Timer(this.components);
            this.CREATE = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.LEN = new System.Windows.Forms.NumericUpDown();
            this.Custom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.knowns = new System.Windows.Forms.ImageList(this.components);
            this.DEL = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.CREATE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LEN)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(40, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // WebsiteUrl
            // 
            this.WebsiteUrl.Location = new System.Drawing.Point(153, 25);
            this.WebsiteUrl.Name = "WebsiteUrl";
            this.WebsiteUrl.Size = new System.Drawing.Size(202, 20);
            this.WebsiteUrl.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Website URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // PWD
            // 
            this.PWD.Location = new System.Drawing.Point(153, 64);
            this.PWD.Name = "PWD";
            this.PWD.Size = new System.Drawing.Size(411, 20);
            this.PWD.TabIndex = 4;
            this.PWD.UseSystemPasswordChar = true;
            // 
            // HIDE
            // 
            this.HIDE.Location = new System.Drawing.Point(472, 90);
            this.HIDE.Name = "HIDE";
            this.HIDE.Size = new System.Drawing.Size(92, 23);
            this.HIDE.TabIndex = 5;
            this.HIDE.Text = "Show Password";
            this.HIDE.UseVisualStyleBackColor = true;
            this.HIDE.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(428, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 33);
            this.button2.TabIndex = 6;
            this.button2.Text = "Copy to clipboard";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(969, 351);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(88, 68);
            this.webBrowser1.TabIndex = 8;
            this.webBrowser1.Visible = false;
            // 
            // focusCheck
            // 
            this.focusCheck.Enabled = true;
            this.focusCheck.Tick += new System.EventHandler(this.focusCheck_Tick);
            // 
            // CREATE
            // 
            this.CREATE.Controls.Add(this.label3);
            this.CREATE.Controls.Add(this.LEN);
            this.CREATE.Location = new System.Drawing.Point(153, 90);
            this.CREATE.Name = "CREATE";
            this.CREATE.Size = new System.Drawing.Size(136, 23);
            this.CREATE.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Lenght";
            // 
            // LEN
            // 
            this.LEN.Location = new System.Drawing.Point(47, 3);
            this.LEN.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.LEN.Name = "LEN";
            this.LEN.Size = new System.Drawing.Size(89, 20);
            this.LEN.TabIndex = 8;
            this.LEN.ValueChanged += new System.EventHandler(this.LEN_ValueChanged);
            // 
            // Custom
            // 
            this.Custom.Location = new System.Drawing.Point(362, 25);
            this.Custom.Name = "Custom";
            this.Custom.Size = new System.Drawing.Size(202, 20);
            this.Custom.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(361, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Name";
            // 
            // knowns
            // 
            this.knowns.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("knowns.ImageStream")));
            this.knowns.TransparentColor = System.Drawing.Color.Transparent;
            this.knowns.Images.SetKeyName(0, "9gag.png");
            this.knowns.Images.SetKeyName(1, "facebook.png");
            this.knowns.Images.SetKeyName(2, "gmail.png");
            this.knowns.Images.SetKeyName(3, "google.png");
            this.knowns.Images.SetKeyName(4, "instagram.png");
            this.knowns.Images.SetKeyName(5, "outlook.png");
            this.knowns.Images.SetKeyName(6, "reddit.png");
            this.knowns.Images.SetKeyName(7, "twitch.png");
            this.knowns.Images.SetKeyName(8, "twitter.png");
            this.knowns.Images.SetKeyName(9, "yandexMail.png");
            this.knowns.Images.SetKeyName(10, "youtube.png");
            // 
            // DEL
            // 
            this.DEL.Location = new System.Drawing.Point(12, 129);
            this.DEL.Name = "DEL";
            this.DEL.Size = new System.Drawing.Size(46, 23);
            this.DEL.TabIndex = 13;
            this.DEL.Text = "Delete";
            this.DEL.UseVisualStyleBackColor = true;
            this.DEL.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Modify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 162);
            this.Controls.Add(this.DEL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Custom);
            this.Controls.Add(this.CREATE);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.HIDE);
            this.Controls.Add(this.PWD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WebsiteUrl);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Modify";
            this.Text = "Modify";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Modify_FormClosing);
            this.Load += new System.EventHandler(this.Modify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.CREATE.ResumeLayout(false);
            this.CREATE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LEN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox WebsiteUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PWD;
        private System.Windows.Forms.Button HIDE;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Timer focusCheck;
        private System.Windows.Forms.Panel CREATE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown LEN;
        private System.Windows.Forms.TextBox Custom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ImageList knowns;
        private System.Windows.Forms.Button DEL;
    }
}