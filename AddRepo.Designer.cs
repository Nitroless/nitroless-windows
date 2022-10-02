namespace Nitroless
{
    partial class AddRepo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRepo));
            this.addRepoBtn = new System.Windows.Forms.Button();
            this.addRepoTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // addRepoBtn
            // 
            this.addRepoBtn.Location = new System.Drawing.Point(12, 40);
            this.addRepoBtn.Name = "addRepoBtn";
            this.addRepoBtn.Size = new System.Drawing.Size(104, 26);
            this.addRepoBtn.TabIndex = 0;
            this.addRepoBtn.Text = "Add Repo";
            this.addRepoBtn.UseVisualStyleBackColor = true;
            this.addRepoBtn.Click += new System.EventHandler(this.AddRepoBtn_Click);
            // 
            // addRepoTextBox
            // 
            this.addRepoTextBox.Location = new System.Drawing.Point(12, 12);
            this.addRepoTextBox.Name = "addRepoTextBox";
            this.addRepoTextBox.Size = new System.Drawing.Size(301, 22);
            this.addRepoTextBox.TabIndex = 3;
            // 
            // AddRepo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 78);
            this.Controls.Add(this.addRepoTextBox);
            this.Controls.Add(this.addRepoBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddRepo";
            this.ShowInTaskbar = false;
            this.Text = "Add Repo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addRepoBtn;
        private System.Windows.Forms.TextBox addRepoTextBox;
    }
}