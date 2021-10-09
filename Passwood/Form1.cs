using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Passwood
{
    public partial class Form1 : Form
    {
        List<Modify.Entry> entries = new List<Modify.Entry>();
        private byte[] password;
        public Form1()
        {
            InitializeComponent();
        }
        private static byte[] Get_Bytes(byte[] src, int startindex, int count)
        {
            byte[] retval = new byte[count];
            for (int i = 0; i < count; i++)
            {
                retval[i] = src[startindex + i];
            }
            return retval;
        }
        private static byte[] Set_Bytes(byte[] src, int srcindex, byte[] dest, int destindex,int count)
        {
            byte[] retval = src;
            if (srcindex + count > src.Length) throw new Exception("The end of src");
            if (destindex + count > dest.Length) throw new Exception("The end of dest");
            for (int i = 0; i < count; i++)
            {
                retval[srcindex + i] = dest[destindex + i];
            }
            return retval;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory("C:\\ProgramData\\Passwood\\Entries");
            if (File.Exists("C:\\ProgramData\\Passwood\\Userfile.usrf"))
            {
                bool isPassCorrect = false;
                while (!isPassCorrect)
                {
                    Login a = readUserFile();
                    a.ShowDialog();
                    if (a.oprt == Login.operation.not_set) { this.Close(); isPassCorrect = true; }
                    else if (a.oprt == Login.operation.login)
                    {
                        password = Encoding.UTF8.GetBytes(a.password);

                        using (FileStream fs = new FileStream("C:\\ProgramData\\Passwood\\Userfile.usrf", FileMode.Open))
                        {
                            byte[] userfile = new byte[fs.Length];
                            fs.Read(userfile, 0, userfile.Length);
                            byte[] doubleHash = Get_Bytes(userfile, userfile.Length - 32, 32);
                            if (Convert.ToBase64String(doubleHash) == Convert.ToBase64String(DoubleHash(password)))
                            {
                                isPassCorrect = true;
                            }
                            else
                            {
                                MessageBox.Show("Wrong password");
                            }
                        }
                    }
                    else if (a.oprt == Login.operation.reset)
                    {
                        try
                        {
                            
                            MessageBox.Show(byto(a.encpaswd));
                            password = AES.Decrypt(a.encpaswd, Encoding.UTF8.GetBytes(a.answerda));
                            MessageBox.Show("Password is: " + Encoding.UTF8.GetString(password));
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Answer is wrong or security question is not set");
                        }
                    }
                }
                foreach (string url in Directory.GetFiles("C:\\ProgramData\\Passwood\\Entries"))
                {
                    bool error = false;
                    try
                    {
                        using (FileStream fs = new FileStream(url, FileMode.Open))
                        {
                            byte[] randomEntry = new byte[fs.Length];
                            fs.Read(randomEntry, 0, randomEntry.Length);
                            byte[] constructedEntry = AES.Decrypt(randomEntry, password);
                            Modify.Entry entry = new Modify.Entry();
                            entry.deConstruct(constructedEntry);

                            ListViewItem item = new ListViewItem();
                            item.Text = entry.CustomName.Length > 0 ? entry.CustomName : entry.Url;
                            item.Tag = entry.Bounder;
                            if (entry.KnownSite == Modify.KnownSite.unknown)
                            {
                                if (entry.logo == null) entry.logo = (Bitmap)favicons.Images[favicons.Images.Count - 1];
                                favicons.Images.Add(entry.logo);
                                favicons.Images.SetKeyName(favicons.Images.Count - 1, entry.Url);
                                item.ImageKey = entry.Url;
                            }
                            else
                            {
                                item.ImageIndex = (int)entry.KnownSite - 1;
                            }

                            listView1.Items.Add(item);
                            entries.Add(entry);
                        }
                    }
                    catch (Exception)
                    {

                        error = true;
                    }
                    if (error)
                    {
                        MessageBox.Show("There are entries that can't be decrypted. Did you mess with files? If not your entries might be corrupted.");
                    }
                }
            }
            else
            {
                createUserFile();
            }
            _5Minute.Enabled = true;
        }

        Login readUserFile()
        {
            Login retval = new Login();

            using (FileStream fs = new FileStream("C:\\ProgramData\\Passwood\\Userfile.usrf", FileMode.OpenOrCreate))
            {
                byte[] userfile = new byte[fs.Length];
                fs.Read(userfile, 0, userfile.Length);
                byte[] len = new byte[2];
                len[0] = userfile[0]; len[1] = userfile[1];
                int securityqlen = (int)BitConverter.ToUInt16(len,0);
                string securityq = Encoding.UTF8.GetString(Get_Bytes(userfile, 2, securityqlen));
                len[0] = userfile[2 + securityqlen]; len[1] = userfile[3 + securityqlen];
                int encpaswdlen = (int)BitConverter.ToUInt16(len, 0);
                retval.recoverq = securityq;
                retval.register = false;
                retval.encpaswd = Get_Bytes(userfile, 4 + securityqlen, encpaswdlen);
            }
            return retval;
        }

        byte[] DoubleHash(byte[] data)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                var q = sha256Hash.ComputeHash(data);
                return sha256Hash.ComputeHash(q);
            }
        }
        void createUserFile()
        {
            Login a = new Login();
            a.register = true;
            a.ShowDialog();
            if (a.oprt == Login.operation.not_set)
            {
                this.Close();
            }

            if (a.password.Length == 0 || a.answerda.Length == 0)
            {
                return;
            }

            byte[] recq = Encoding.UTF8.GetBytes(a.recoverq);
            byte[] recl = BitConverter.GetBytes((ushort)recq.Length);

            byte[] answ = Encoding.UTF8.GetBytes(a.answerda);

            byte[] pass = recq.Length > 0 ? AES.Encrypt(Encoding.UTF8.GetBytes(a.password),answ) : new byte[1];
            byte[] pasl = BitConverter.GetBytes((ushort)pass.Length);

            byte[] pash = DoubleHash(Encoding.UTF8.GetBytes(a.password));

            password = Encoding.UTF8.GetBytes(a.password);

            MessageBox.Show(byto(pass));

            byte[] Userfile = new byte[recq.Length + recl.Length + pass.Length + pasl.Length + pash.Length];
            Userfile = Set_Bytes(Userfile, 0, recl, 0, recl.Length);
            Userfile = Set_Bytes(Userfile, recl.Length, recq, 0, recq.Length);
            Userfile = Set_Bytes(Userfile, recl.Length + recq.Length, pasl, 0, pasl.Length);
            Userfile = Set_Bytes(Userfile, recl.Length + recq.Length + pasl.Length, pass, 0, pass.Length);
            Userfile = Set_Bytes(Userfile, recl.Length + recq.Length + pasl.Length + pass.Length, pash, 0, pash.Length);

            //byte[] entry = AES.Encrypt(Encoding.UTF8.GetBytes("<PASWOOD>"), password);

            using (FileStream fs = new FileStream("C:\\ProgramData\\Passwood\\Userfile.usrf", FileMode.OpenOrCreate))
            {
                fs.Write(Userfile, 0, Userfile.Length);
            }
            /*using (FileStream fs = new FileStream("C:\\ProgramData\\Passwood\\Entries\\" + RandomString(16) + ".ent", FileMode.Create))
            {
                fs.Write(entry, 0, entry.Length);
            }*/
            
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
        private void listView1_Click(object sender, EventArgs e)
        {
            var clicked = listView1.SelectedItems[0];
            if (clicked.Tag == "CRTNW")
            {
                createEntry();
            }
            else if (clicked.Text != null)
            {
                bool found = false;
                Modify.Entry toDelete = new Modify.Entry();
                Modify.Entry toAdd = new Modify.Entry();
                foreach (var entry in entries)
                {
                    if (entry.Bounder == (string)clicked.Tag)
                    {
                        found = true;
                        Modify a = new Modify();
                        a.entry = entry;
                        a.ShowDialog();
                        if (a.entry.Password == null)
                        {
                            toDelete = entry;
                        }
                        if (a.entry.Url != entry.Url || a.entry.CustomName != entry.CustomName)
                        {
                            listView1.Items.Remove(clicked);
                            ListViewItem item = new ListViewItem();
                            item.Text = a.entry.CustomName.Length > 0 ? a.entry.CustomName : a.entry.Url;
                            a.entry.Bounder = RandomString(32);
                            item.Tag = a.entry.Bounder;
                            if (a.entry.KnownSite == Modify.KnownSite.unknown)
                            {
                                if (a.entry.logo == null) a.entry.logo = (Bitmap)favicons.Images[favicons.Images.Count - 1];
                                favicons.Images.Add(a.entry.logo);
                                favicons.Images.SetKeyName(favicons.Images.Count - 1, a.entry.Url);
                                item.ImageKey = a.entry.Url;
                            }
                            else
                            {
                                item.ImageIndex = (int)a.entry.KnownSite - 1;
                            }
                            listView1.Items.Add(item);
                            toAdd = a.entry;
                            toDelete = entry;
                        }
                    }
                }
                if (toAdd.Password != null)
                {
                    entries.Add(toAdd);
                }
                if (toDelete.Password != null)
                {
                    entries.Remove(toDelete);
                    listView1.Items.Remove(clicked);
                    if (toDelete.KnownSite != Modify.KnownSite.unknown)
                    {
                        favicons.Images.RemoveByKey(toDelete.Url);
                    }
                }
            }
        }
        private void createEntry()
        {
            ListViewItem item = new ListViewItem();
            Modify.Entry entry = new Modify.Entry();
            Modify a = new Modify();
            a.entry = entry;
            a.ShowDialog();
            if (a.entry.Password != null && a.entry.Url != null)
            {
                entry = a.entry;
                entry.Bounder = RandomString(32);
                item.Tag = entry.Bounder;
                if (entry.KnownSite == Modify.KnownSite.unknown)
                {
                    if (entry.logo == null) entry.logo = (Bitmap)favicons.Images[favicons.Images.Count - 1];
                    favicons.Images.Add(entry.logo);
                    favicons.Images.SetKeyName(favicons.Images.Count - 1, entry.Url);
                    item.ImageKey = entry.Url;
                }
                else
                {
                    item.ImageIndex = (int)entry.KnownSite - 1;
                }
                item.Text = entry.CustomName.Length > 0 ? entry.CustomName : entry.Url;
                entry.icon = item;
                entries.Add(entry);
                listView1.Items.Add(item);
            }
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save();
        }

        private void _5Minute_Tick(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            List<string> corrupted = new List<string>();
            List<string> ToDelete = new List<string>();
            List<string> existing_bounders = new List<string>();
            bool error = false;
            foreach (string url in Directory.GetFiles("C:\\ProgramData\\Passwood\\Entries"))
            {
                
                try
                {
                    using (FileStream fs = new FileStream(url, FileMode.Open))
                    {
                        byte[] randomEntry = new byte[fs.Length];
                        fs.Read(randomEntry, 0, randomEntry.Length);
                        byte[] constructedEntry = AES.Decrypt(randomEntry, password);
                        Modify.Entry entry = new Modify.Entry();
                        entry.deConstruct(constructedEntry);
                        bool exist = false;
                        foreach (Modify.Entry Q in entries)
                        {
                            if (Q.Bounder == entry.Bounder)
                            {
                                existing_bounders.Add(Q.Bounder);
                                exist = true;
                            }
                        }
                        if (!exist)
                        {
                            ToDelete.Add(url);
                        }
                    }
                }
                catch (Exception)
                {
                    corrupted.Add(url);
                    error = true;
                    
                }
                
            }
            if (error)
            {
                if (MessageBox.Show("Do you wan't to delete corrupted entries?","Passwood",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ToDelete.AddRange(corrupted);
                }
            }
            foreach (string url in ToDelete)
            {
                File.Delete(url);
            }
            foreach (Modify.Entry entry in entries)
            {
                bool exists = false;
                foreach (string bounder in existing_bounders)
                {
                    if (bounder == entry.Bounder)
                    {
                        exists = true;
                    }
                }
                if (!exists)
                {
                    using (FileStream fs = new FileStream("C:\\ProgramData\\Passwood\\Entries\\" + RandomString(16) + ".ent", FileMode.OpenOrCreate))
                    {
                        byte[] encryie = AES.Encrypt(entry.construct(), password);
                        fs.Write(encryie, 0, encryie.Length);
                    }
                }
            }
        }
    }
}
