
namespace Passwood
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Create New", "plus-icon.png");
            this.favicons = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this._5Minute = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // favicons
            // 
            this.favicons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("favicons.ImageStream")));
            this.favicons.TransparentColor = System.Drawing.Color.Transparent;
            this.favicons.Images.SetKeyName(0, "9gag.png");
            this.favicons.Images.SetKeyName(1, "facebook.png");
            this.favicons.Images.SetKeyName(2, "gmail.png");
            this.favicons.Images.SetKeyName(3, "google.png");
            this.favicons.Images.SetKeyName(4, "instagram.png");
            this.favicons.Images.SetKeyName(5, "outlook.png");
            this.favicons.Images.SetKeyName(6, "reddit.png");
            this.favicons.Images.SetKeyName(7, "twitch.png");
            this.favicons.Images.SetKeyName(8, "twitter.png");
            this.favicons.Images.SetKeyName(9, "yandexMail.png");
            this.favicons.Images.SetKeyName(10, "youtube.png");
            this.favicons.Images.SetKeyName(11, "plus-icon.png");
            this.favicons.Images.SetKeyName(12, "password.png");
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            listViewItem1.Tag = "CRTNW";
            listViewItem1.ToolTipText = "Creates New Password";
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.LargeImageList = this.favicons;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(707, 563);
            this.listView1.SmallImageList = this.favicons;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            // 
            // _5Minute
            // 
            this._5Minute.Interval = 300000;
            this._5Minute.Tick += new System.EventHandler(this._5Minute_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 563);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Passwood";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList favicons;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Timer _5Minute;
    }
}

