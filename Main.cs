using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using System.Reflection;

namespace Nitroless
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            if (!File.Exists("repos.json"))
            {
                File.Create("repos.json").Close();
                File.AppendAllText("repos.json", "[]");
            }
            this.BackColor = Color.FromArgb(60, 63, 65);
            // this.TopMost = true;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            TrayMenu();
            LowerRight();
            LoadPanel();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.Hide();
            }
        }

        private void Main_Closing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void TrayMenu()
        {
            trayIcon.ContextMenuStrip = new ContextMenuStrip();
            trayIcon.ContextMenuStrip.Items.Add("Show", null, Main_Show);
            trayIcon.ContextMenuStrip.Items.Add("Hide", null, Main_Hide);
            trayIcon.ContextMenuStrip.Items.Add("Add Repo", null, Main_AddRepo);
            trayIcon.ContextMenuStrip.Items.Add("Delete Repo", null, Main_DeleteRepo);
            trayIcon.ContextMenuStrip.Items.Add("Exit", null, Main_Close);
        }
        private void Main_Show(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }
        private void Main_Hide(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void Main_AddRepo(object sender, EventArgs e)
        {
        }

        private void Main_DeleteRepo(object sender, EventArgs e)
        {
        }

        private void Main_Close(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }

        private void LowerRight()
        {
            Screen rightmost = Screen.AllScreens[0];
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.Right > rightmost.WorkingArea.Right)
                    rightmost = screen;
            }

            this.Left = rightmost.WorkingArea.Right - this.Width;
            this.Top = rightmost.WorkingArea.Bottom - this.Height;
        }

        private void LoadPanel()
        {
            string reposJson = File.ReadAllText("repos.json");
            dynamic reposArray = JsonConvert.DeserializeObject(reposJson);
            using (WebClient wc = new WebClient())
            {
                int x = 0;
                int y = 0;
                int t = 0;

                for (int a = 0; a < reposArray.Count; a++)
                {
                    string reposResponse = wc.DownloadString(reposArray[a].ToString() + "index.json");
                    dynamic reposJsonResponse = JsonConvert.DeserializeObject(reposResponse);

                    PictureBox repoPictureBox = new PictureBox();
                    repoPictureBox.ImageLocation = reposArray[a] + reposJsonResponse.icon;
                    repoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    repoPictureBox.Size = new Size(30, 30);
                    repoPictureBox.Location = new Point(x, y);
                    mainPanel.Controls.Add(repoPictureBox);

                    x += 40;

                    Label repoLabel = new Label();
                    repoLabel.Text = reposJsonResponse.name;
                    repoLabel.Location = new Point(x, y);
                    repoLabel.AutoSize = true;
                    repoLabel.Font = new Font(repoLabel.Font.Name, 18);
                    repoLabel.Padding = new Padding(0);
                    repoLabel.ForeColor = Color.FromArgb(220, 220, 220);
                    mainPanel.Controls.Add(repoLabel);

                    x = 0;
                    y += 42;

                    for (int b = 0; b < reposJsonResponse.emotes.Count; b++)
                    {
                        string emoteImageUrl = reposArray[a] + reposJsonResponse.path + "/" + reposJsonResponse.emotes[b].name + "." + reposJsonResponse.emotes[b].type;
                        PictureBox emotePictureBox = new PictureBox();
                        emotePictureBox.ImageLocation = emoteImageUrl;
                        emotePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        emotePictureBox.Size = new Size(35, 35);
                        emotePictureBox.MouseClick += (sender, EventArgs) => { EmotePictureBox_Click(emoteImageUrl); };
                        emotePictureBox.Cursor = Cursors.Hand;
                        emotePictureBox.Location = new Point(x, y);
                        mainPanel.Controls.Add(emotePictureBox);
                        x += 40;
                        t += 1;
                        if (t == 8)
                        {
                            x = 0;
                            y += 40;
                            t = 0;
                        }
                        if (b == (reposJsonResponse.emotes.Count - 1))
                        {
                            x = 0;
                            y += 80;
                            t = 0;
                        }
                    }
                }
            }
        }

        private void EmotePictureBox_Click(string pictureurl)
        {
            Clipboard.SetText(pictureurl);
        }

        private void TrayIcon_DoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }
    }
}
