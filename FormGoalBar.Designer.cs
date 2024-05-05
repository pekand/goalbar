namespace GoalBar
{
    partial class FormGoalBar
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGoalBar));
            contextMenuStrip1 = new ContextMenuStrip(components);
            changeNameToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            addGoalToolStripMenuItem = new ToolStripMenuItem();
            removeGoalToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            moveUpToolStripMenuItem = new ToolStripMenuItem();
            moveDownToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            openToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            topMostToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            timer1 = new System.Windows.Forms.Timer(components);
            timerConfigUpdate = new System.Windows.Forms.Timer(components);
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { changeNameToolStripMenuItem, toolStripMenuItem1, addGoalToolStripMenuItem, removeGoalToolStripMenuItem, toolStripMenuItem3, moveUpToolStripMenuItem, moveDownToolStripMenuItem, toolStripMenuItem2, openToolStripMenuItem, optionsToolStripMenuItem, closeToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(181, 220);
            // 
            // changeNameToolStripMenuItem
            // 
            changeNameToolStripMenuItem.Name = "changeNameToolStripMenuItem";
            changeNameToolStripMenuItem.Size = new Size(180, 22);
            changeNameToolStripMenuItem.Text = "Change name";
            changeNameToolStripMenuItem.Click += changeNameToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(177, 6);
            // 
            // addGoalToolStripMenuItem
            // 
            addGoalToolStripMenuItem.Name = "addGoalToolStripMenuItem";
            addGoalToolStripMenuItem.Size = new Size(180, 22);
            addGoalToolStripMenuItem.Text = "Add goal";
            addGoalToolStripMenuItem.Click += addGoalToolStripMenuItem_Click;
            // 
            // removeGoalToolStripMenuItem
            // 
            removeGoalToolStripMenuItem.Name = "removeGoalToolStripMenuItem";
            removeGoalToolStripMenuItem.Size = new Size(180, 22);
            removeGoalToolStripMenuItem.Text = "Remove goal";
            removeGoalToolStripMenuItem.Click += removeGoalToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(177, 6);
            // 
            // moveUpToolStripMenuItem
            // 
            moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            moveUpToolStripMenuItem.Size = new Size(180, 22);
            moveUpToolStripMenuItem.Text = "Move up";
            moveUpToolStripMenuItem.Click += moveUpToolStripMenuItem_Click;
            // 
            // moveDownToolStripMenuItem
            // 
            moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            moveDownToolStripMenuItem.Size = new Size(180, 22);
            moveDownToolStripMenuItem.Text = "Move down";
            moveDownToolStripMenuItem.Click += moveDownToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(177, 6);
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "Open config file";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { topMostToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(180, 22);
            optionsToolStripMenuItem.Text = "Options";
            // 
            // topMostToolStripMenuItem
            // 
            topMostToolStripMenuItem.Name = "topMostToolStripMenuItem";
            topMostToolStripMenuItem.Size = new Size(123, 22);
            topMostToolStripMenuItem.Text = "Top most";
            topMostToolStripMenuItem.Click += topMostToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(180, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // timerConfigUpdate
            // 
            timerConfigUpdate.Interval = 1000;
            timerConfigUpdate.Tick += timerConfigUpdate_Tick;
            // 
            // FormGoalBar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ContextMenuStrip = contextMenuStrip1;
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormGoalBar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GoalBar";
            Activated += FormGoalBar_Activated;
            FormClosing += FormGoalBar_FormClosing;
            Load += FormGoalBar_Load;
            Paint += FormGoalBar_Paint;
            MouseDown += FormGoalBar_MouseDown;
            MouseMove += FormGoalBar_MouseMove;
            MouseUp += FormGoalBar_MouseUp;
            Resize += FormGoalBar_Resize;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem topMostToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timerConfigUpdate;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem addGoalToolStripMenuItem;
        private ToolStripMenuItem removeGoalToolStripMenuItem;
        private ToolStripMenuItem changeNameToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem moveUpToolStripMenuItem;
        private ToolStripMenuItem moveDownToolStripMenuItem;
    }
}
