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
        }

        private void Main_Load(object sender, EventArgs e)
        {
            string reposJson = File.ReadAllText("repos.json");
            dynamic reposArray = JsonConvert.DeserializeObject(reposJson);
            using (WebClient wc = new WebClient())
            {
                int x = 0;
                int y = 0;

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
                    mainPanel.Controls.Add(repoLabel);

                    x = 0;
                    y += 42;

                    for (int b = 0; b < reposJsonResponse.emotes.Count; b++)
                    {
                        PictureBox emotePictureBox = new PictureBox();
                        emotePictureBox.ImageLocation = reposArray[a] + reposJsonResponse.path + "/" + reposJsonResponse.emotes[b].name + "." + reposJsonResponse.emotes[b].type;
                        emotePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        emotePictureBox.Size = new Size(35, 35);
                        emotePictureBox.Cursor = Cursors.Hand;
                        emotePictureBox.Location = new Point(x, y);
                        mainPanel.Controls.Add(emotePictureBox);
                        x += 40;
                    }

                    x = 0;
                    y += 80;
                }

                x = 0;
                y = 0;
            }
        }
    }
}
