namespace Nitroless
{
    partial class RemoveRepo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoveRepo));
            this.reposListBox = new System.Windows.Forms.ListBox();
            this.removeRepoBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reposListBox
            // 
            this.reposListBox.FormattingEnabled = true;
            this.reposListBox.ItemHeight = 16;
            this.reposListBox.Location = new System.Drawing.Point(12, 12);
            this.reposListBox.Name = "reposListBox";
            this.reposListBox.Size = new System.Drawing.Size(371, 228);
            this.reposListBox.TabIndex = 3;
            // 
            // removeRepoBtn
            // 
            this.removeRepoBtn.Location = new System.Drawing.Point(12, 246);
            this.removeRepoBtn.Name = "removeRepoBtn";
            this.removeRepoBtn.Size = new System.Drawing.Size(104, 25);
            this.removeRepoBtn.TabIndex = 4;
            this.removeRepoBtn.Text = "Remove";
            this.removeRepoBtn.UseVisualStyleBackColor = true;
            // 
            // RemoveRepo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 283);
            this.Controls.Add(this.removeRepoBtn);
            this.Controls.Add(this.reposListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RemoveRepo";
            this.ShowInTaskbar = false;
            this.Text = "Remove Repo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox reposListBox;
        private System.Windows.Forms.Button removeRepoBtn;
    }
}