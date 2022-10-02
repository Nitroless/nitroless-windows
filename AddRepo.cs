using System;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace Nitroless
{
    public partial class AddRepo : Form
    {
        public AddRepo()
        {
            InitializeComponent();
        }

        private void AddRepoBtn_Click(object sender, EventArgs e)
        {
            string reposJson = File.ReadAllText("repos.json");
            dynamic reposArray = JsonConvert.DeserializeObject(reposJson);
            if (addRepoTextBox.Text != String.Empty)
            {
                string repoLink;
                if (addRepoTextBox.Text.EndsWith("/"))
                {
                    repoLink = addRepoTextBox.Text;
                }
                else
                {
                    repoLink = addRepoTextBox.Text + "/";
                }

                if (!reposArray.ToString().Contains(repoLink))
                {
                    reposArray.Add(repoLink);
                    File.WriteAllText("repos.json", reposArray.ToString());
                }
            }
        }
    }
}
