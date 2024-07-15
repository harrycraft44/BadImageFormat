namespace BadImageFormat
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            convertToolStripMenuItem = new ToolStripMenuItem();
            tOBadImageToolStripMenuItem = new ToolStripMenuItem();
            topngToolStripMenuItem = new ToolStripMenuItem();
            regToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1789, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, convertToolStripMenuItem, regToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(290, 34);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // convertToolStripMenuItem
            // 
            convertToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tOBadImageToolStripMenuItem, topngToolStripMenuItem });
            convertToolStripMenuItem.Name = "convertToolStripMenuItem";
            convertToolStripMenuItem.Size = new Size(290, 34);
            convertToolStripMenuItem.Text = "Convert";
            // 
            // tOBadImageToolStripMenuItem
            // 
            tOBadImageToolStripMenuItem.Name = "tOBadImageToolStripMenuItem";
            tOBadImageToolStripMenuItem.Size = new Size(281, 34);
            tOBadImageToolStripMenuItem.Text = "TO .BADFILEFORMAT";
            tOBadImageToolStripMenuItem.Click += tOBadImageToolStripMenuItem_Click;
            // 
            // topngToolStripMenuItem
            // 
            topngToolStripMenuItem.Name = "topngToolStripMenuItem";
            topngToolStripMenuItem.Size = new Size(281, 34);
            topngToolStripMenuItem.Text = "To .png";
            topngToolStripMenuItem.Click += topngToolStripMenuItem_Click;
            // 
            // regToolStripMenuItem
            // 
            regToolStripMenuItem.Name = "regToolStripMenuItem";
            regToolStripMenuItem.Size = new Size(290, 34);
            regToolStripMenuItem.Text = "registerFileAssociation";
            regToolStripMenuItem.Click += regToolStripMenuItem_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1789, 1117);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem convertToolStripMenuItem;
        private ToolStripMenuItem tOBadImageToolStripMenuItem;
        private ToolStripMenuItem topngToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private ToolStripMenuItem regToolStripMenuItem;
    }
}
