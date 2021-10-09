using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Passwood
{
    public partial class Modify : Form
    {
        static ImageList.ImageCollection images;
        public enum KnownSite
        {
            unknown,
            _9gag,
            facebook,
            gmail,
            google,
            instagram,
            outlook,
            reddit,
            twitch,
            twitter,
            yandexMail,
            youtube
            
        }

        public struct Entry
        {
            public ListViewItem icon;
            private Bitmap bit;
            /// <summary>
            /// Unused value that allows parent program to bound this struct to respective ListViewItem.
            /// </summary>
            public string Bounder;
            public string Password;
            public string Url;
            public string CustomName;
            public KnownSite KnownSite;
            public Bitmap logo
            {
                get
                {
                    if (KnownSite != KnownSite.unknown)
                    {
                        return new Bitmap(images[(int)KnownSite - 1]);
                    }
                    else
                    {
                        return bit;
                    }
                }
                set
                {
                    KnownSite = KnownSite.unknown;
                    bit = value;
                }
            }
            public byte[] construct()
            {
                string stringdata = Password + "#" + Url + "#" + CustomName + "#" + Bounder;
                byte[] strencoded = Encoding.UTF32.GetBytes(stringdata);
                int len = strencoded.Length;
                byte[] bitencoded;
                if (KnownSite == KnownSite.unknown && bit != null)
                {
                    MemoryStream ms = new MemoryStream();
                    
                    bit.Save(ms,ImageFormat.Jpeg);
                    bitencoded = ms.ToArray();;
                }
                else
                {
                    bitencoded = new byte[1];
                }
                byte[] ret = new byte[3 + len + bitencoded.Length];

                ret[0] = (byte)KnownSite;
                BitConverter.GetBytes((ushort)strencoded.Length).CopyTo(ret,1);
                strencoded.CopyTo(ret, 3);
                bitencoded.CopyTo(ret, 3 + strencoded.Length);

                return ret;
            }
            /// <summary>
            /// Data is the byte array coming from construct function.
            /// </summary>
            /// <param name="data"></param>
            public void deConstruct(byte[] data)
            {
                KnownSite = (KnownSite)data[0];
                byte[] q = { data[1], data[2] };
                int strlen = (int)BitConverter.ToUInt16(q,0);
                byte[] strencoded = new byte[strlen];
                byte[] bitencoded = new byte[data.Length - (3 + strlen)];
                Array.Copy(data, 3, strencoded, 0, strlen);
                Array.Copy(data, 3 + strlen, bitencoded, 0, bitencoded.Length);
                string stringdata = Encoding.UTF32.GetString(strencoded);

                if (bitencoded.Length > 2)
                {
                    bit = new Bitmap(new MemoryStream(bitencoded));
                }
                else
                {
                    bit = new Bitmap(1, 1);
                }
                var w = stringdata.Split('#');
                Password = w[0];
                Url = w[1];
                CustomName = w[2];
                Bounder = w[3];
            }
        }

        static string byto(byte[] data)
        {
            string ret = "";
            foreach (byte dat in data)
            {
                ret += dat.ToString() + " ,";
            }
            return ret;
        }

        public Entry entry;

        string iconurl = "";
        public Modify()
        {
            InitializeComponent();
        }
        private bool focus = false;
        private string navigated = "";
        private void focusCheck_Tick(object sender, EventArgs e)
        {
            if (WebsiteUrl.Focused)
            {
                focus = true;
            }
            
            if (focus && !WebsiteUrl.Focused && WebsiteUrl.Text.Length > 2)
            {
                //lost focus
                if (WebsiteUrl.Text.Contains("9gag"))
                {
                    entry.KnownSite = KnownSite._9gag;
                }
                else if (WebsiteUrl.Text.Contains("facebook"))
                {
                    entry.KnownSite = KnownSite.facebook;
                }
                else if (WebsiteUrl.Text.Contains("gmail"))
                {
                    entry.KnownSite = KnownSite.gmail;
                }
                else if (WebsiteUrl.Text.Contains("google"))
                {
                    entry.KnownSite = KnownSite.google;
                }
                else if (WebsiteUrl.Text.Contains("instagram"))
                {
                    entry.KnownSite = KnownSite.instagram;
                }
                else if (WebsiteUrl.Text.Contains("outlook"))
                {
                    entry.KnownSite = KnownSite.outlook;
                }
                else if (WebsiteUrl.Text.Contains("reddit"))
                {
                    entry.KnownSite = KnownSite.reddit;
                }
                else if (WebsiteUrl.Text.Contains("twitch"))
                {
                    entry.KnownSite = KnownSite.twitch;
                }
                else if (WebsiteUrl.Text.Contains("twitter"))
                {
                    entry.KnownSite = KnownSite.twitter;
                }
                else if (WebsiteUrl.Text.Contains("yandexMail"))
                {
                    entry.KnownSite = KnownSite.yandexMail;
                }
                else if (WebsiteUrl.Text.Contains("youtube"))
                {
                    entry.KnownSite = KnownSite.youtube;
                }
                else
                {

                    webBrowser1.Navigate("");
                    webBrowser1.Navigate(WebsiteUrl.Text);
                    navigated = WebsiteUrl.Text;
                    if (!navigated.EndsWith("/")) navigated += "/";
                    focus = false;
                }
                pictureBox1.Image = entry.logo;
                this.Text = entry.KnownSite.ToString();
            }
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string imageurl = "";
            foreach (HtmlElement a in webBrowser1.Document.All)
            {
                if (a.GetAttribute("rel") == "icon" || a.GetAttribute("type") == "image/x-icon")
                {
                    imageurl = a.GetAttribute("href");
                }
            }
            if (imageurl == "")
            {
                iconurl = navigated + "favicon.ico";
            }
            else
            {
                iconurl = navigated + imageurl.Replace("16","32") ;
            }
            WebClient client = new WebClient();
            client.OpenReadCompleted += (s, ee) =>
            {
                // byte[] imageBytes = new byte[ee.Result.Length];
                // ee.Result.Read(imageBytes, 0, imageBytes.Length);

                // Now you can use the returned stream to set the image source too
                try
                {
                    var image = new Bitmap(ee.Result);
                    pictureBox1.Image = image;
                    entry.logo = image;
                }
                catch (Exception)
                {

                }
                
            };
            Thread aq = new Thread(() => {
                try
                {
                    client.OpenReadAsync(new Uri(iconurl));
                }
                catch (Exception)
                {
                }
            });
            aq.Start();
        }
        private string RandomString(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }

            return res.ToString();
        }
        private void Modify_Load(object sender, EventArgs e)
        {
            images = knowns.Images;
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.ScrollBarsEnabled = false;
            webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
            if (entry.Password != null)
            {
                if (entry.CustomName == null) entry.CustomName = "";
                if (entry.logo == null) entry.logo = new Bitmap(1, 1);
                if (entry.Url == null) entry.Url = "";
                Custom.Text = entry.CustomName;
                WebsiteUrl.Text = entry.Url;
                PWD.Text = entry.Password;
                pictureBox1.Image = entry.logo;
                this.Controls.Remove(CREATE);
                PWD.ReadOnly = true;
            }
            else
            {
                this.Controls.Remove(DEL);
            }
        }

        private void LEN_ValueChanged(object sender, EventArgs e)
        {
            PWD.Text = RandomString((int)LEN.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PWD.UseSystemPasswordChar)
            {
                HIDE.Text = "Hide password";
                PWD.UseSystemPasswordChar = false;
            }
            else
            {
                HIDE.Text = "Show password";
                PWD.UseSystemPasswordChar = true;
            }
        }

        private void Modify_FormClosing(object sender, FormClosingEventArgs e)
        {
            entry.Url = WebsiteUrl.Text;
            entry.CustomName = Custom.Text;
            if (PWD.ReadOnly == false) entry.Password = PWD.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?","Deleting a password from " + entry.Url,MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                entry = new Entry();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(PWD.Text);
        }
    }
}
