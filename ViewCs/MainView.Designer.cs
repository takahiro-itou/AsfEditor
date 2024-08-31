namespace ViewCs
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRun = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRunCommand = new System.Windows.Forms.ToolStripMenuItem();

            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();

            this.Label1 = new System.Windows.Forms.Label();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();

            this.mnuMain.SuspendLayout();
            this.SuspendLayout();

            //
            //  mnuMain
            //
            mnuMain.Items.AddRange(new ToolStripItem[] { mnuFile, mnuRun });
            resources.ApplyResources(mnuMain, "mnuMain");
            this.mnuMain.Name = "mnuMain";
            //
            //  mnuFile
            //
            resources.ApplyResources(mnuFile, "mnuFile");
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuFileExit });
            this.mnuFile.Name = "mnuFile";
            //
            //  mnuFileExit
            //
            resources.ApplyResources(mnuFileExit, "mnuFileExit");
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Click += this.mnuFileExit_Click;
            //
            //  mnuRun
            //
            resources.ApplyResources(mnuRun, "mnuRun");
            mnuRun.DropDownItems.AddRange(new ToolStripItem[] { mnuRunCommand });
            this.mnuRun.Name = "mnuRun";
            //
            //  mnuRunCommand
            //
            resources.ApplyResources(mnuRunCommand, "mnuRunCommand");
            this.mnuRunCommand.Name = "mnuRunCommand";
            this.mnuRunCommand.Click += this.mnuRunCommand_Click;

            //
            //  dlgOpen
            //
            resources.ApplyResources(dlgOpen, "dlgOpen");
            dlgOpen.FileName = "dlgOpen";

            //
            //  Label1
            //
            resources.ApplyResources(Label1, "Label1");
            this.Label1.Name = "Label1";
            //
            //  txtCommand
            //
            resources.ApplyResources(txtCommand, "txtCommand");
            this.txtCommand.Name = "txtCommand";
            //
            //  btnRun
            //
            resources.ApplyResources(btnRun, "btnRun");
            this.btnRun.Name = "btnRun";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += this.btnRun_Click;
            //
            //  txtOutput
            //
            resources.ApplyResources(txtOutput, "txtOutput");
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.BackColor = SystemColors.Window;
            this.txtOutput.ReadOnly = true;

            //
            //  MainView
            //
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.mnuMain);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtOutput);
            this.Name = "MainView";

            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        internal MenuStrip mnuMain;
        internal ToolStripMenuItem mnuFile;
        internal ToolStripMenuItem mnuFileExit;
        internal ToolStripMenuItem mnuRun;
        internal ToolStripMenuItem mnuRunCommand;

        internal OpenFileDialog dlgOpen;

        internal Label Label1;
        internal TextBox txtCommand;
        internal Button btnRun;
        internal TextBox txtOutput;
    }
}
