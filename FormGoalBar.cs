using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Linq;

namespace GoalBar
{
    public partial class FormGoalBar : Form
    {
        bool enableResizeUpdate = false;
        public FormGoalBar()
        {
            InitializeComponent();
        }

        private void FormGoalBar_Load(object sender, EventArgs e)
        {
            this.updateFromConfig();
            enableResizeUpdate = true;
        }

        private void topMostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.config.topmost = !Program.config.topmost;
            topMostToolStripMenuItem.Checked = Program.config.topmost;
            this.TopMost = Program.config.topmost;
            updateConfig();

        }

        public void updateFromConfig()
        {
            this.Left = Program.config.left;
            this.Top = Program.config.top;
            this.Height = Program.config.height;
            this.Width = Program.config.width;
            this.TopMost = Program.config.topmost;
            topMostToolStripMenuItem.Checked = Program.config.topmost;
        }

        public void updateConfig()
        {
            Program.config.left = this.Left;
            Program.config.top = this.Top;
            Program.config.height = this.Height;
            Program.config.width = this.Width;
            Program.config.topmost = this.TopMost;
            Program.configFile.Save();
            FielChangeDetector.changed(Program.config.configPath);
        }

        private void FormGoalBar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.updateConfig();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (FielChangeDetector.changed(Program.config.configPath))
            {
                Program.configFile.Load();
                this.Invalidate();
            }
        }

        public Goal selectedGoal = null;


        public bool valueChange = false;

        private void FormGoalBar_Paint(object sender, PaintEventArgs e)
        {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            int topSpace = 20;
            int space = 10;
            int top = topSpace;
            int left = 0;
            int right = w - 30;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Brush brushBarBackground = new SolidBrush(Color.FromArgb(30, 0, 0, 0));

            foreach (Goal goal in Program.config.goals)
            {

                if (!goal.show)
                {
                    continue;
                }

                int gL = 10;
                int gT = top;
                int gW = w - 40;
                int gH = 50;

                int diameter = Math.Min(w, h) - 10;
                Rectangle circleBounds = new Rectangle(gL, gT, gH, gH);

                // empty bar
                int barX = gL + 30;
                int barY = gT + 10;
                int barWidth = gW - 10;
                int barHeight = gH - 20;

                g.FillRectangle(brushBarBackground, new Rectangle(barX, barY, barWidth, barHeight));

                // calculate bar value
                if (this.mouseDown &&
                    (barX <= mouseX) && (mouseX <= barX + barWidth) &&
                    (barY <= mouseY) && (mouseY <= barY + barHeight))
                {
                    selectedGoal = goal;

                    if (mouseButton == 1)
                    {
                        valueChange = true;
                    }
                }

                if (this.valueChange && selectedGoal != null && selectedGoal == goal && valueChange)
                {
                    int newValue = selectedGoal.value;

                    float pos = ((mouseX - barX) / (barWidth / 100.0f)) / 100.0f;
                    newValue = (int)(goal.min + (pos * (goal.max - goal.min)));

                    if (newValue < selectedGoal.min)
                    {
                        newValue = selectedGoal.min;
                    }
                    if (selectedGoal.max < newValue)
                    {
                        newValue = selectedGoal.max;
                    }

                    if (newValue != selectedGoal.value)
                    {
                        selectedGoal.value = newValue;
                    }
                }

                // partial bar
                int barWidth2 = (int)(barWidth * ((float)(goal.value - goal.min) / (goal.max - goal.min)));

                if (barWidth2 < 0)
                {
                    barWidth2 = 0;
                }

                if (barWidth2 > barWidth)
                {
                    barWidth2 = barWidth;
                }

                float barPer = (float)barWidth2 / (float)barWidth;

                int red = (int)(255 + barPer * (0 - 255));
                int green = (int)(0 + barPer * (255 - 0));

                Brush brushBar = new SolidBrush(Color.FromArgb(
                    255,
                    red,
                    green,
                    0
                ));

                g.FillRectangle(brushBar, new Rectangle(barX, barY, barWidth2, barHeight));

                // circle
                g.FillEllipse(brushBar, circleBounds);

                // circle text
                string text = goal.value.ToString();
                Font font = new Font("Consolas", 16);
                SizeF textSize = g.MeasureString(text, font);
                float textX = gL + (gH - textSize.Width) / 2;
                float textY = gT + (gH - textSize.Height) / 2;
                g.DrawString(text, font, Brushes.Black, textX, textY);


                // caption text
                int namrPosX = gL + 50;
                int namrPosY = gT + 15;
                string name = goal.name.ToString();
                Font fontName = new Font("Arial", 12);
                SizeF textNameSize = g.MeasureString(text, fontName);
                g.DrawString(name, fontName, Brushes.Black, namrPosX, namrPosY);

                top += gH + space;
            }
        }

        private void FormGoalBar_Resize(object sender, EventArgs e)
        {

            if (!this.enableResizeUpdate)
            {
                return;
            }

            this.Invalidate();

            if (!timerConfigUpdate.Enabled)
            {
                timerConfigUpdate.Enabled = true;
            }

        }

        private void timerConfigUpdate_Tick(object sender, EventArgs e)
        {
            updateConfig();
            timerConfigUpdate.Enabled = false;
        }

        public bool mouseDown = false;
        public int mouseDownX = 0;
        public int mouseDownY = 0;
        public bool mouseMove = false;
        public int mouseX = 0;
        public int mouseY = 0;
        public bool mouseUp = false;
        public int mouseUpX = 0;
        public int mouseUpY = 0;
        public int mouseButton = 0;



        private void FormGoalBar_MouseDown(object sender, MouseEventArgs e)
        {
            Point clientPoint = this.PointToClient(MousePosition);
            mouseDownX = clientPoint.X;
            mouseDownY = clientPoint.Y;
            mouseX = clientPoint.X;
            mouseY = clientPoint.Y;

            this.mouseDown = true;
            this.mouseMove = false;
            this.mouseUp = false;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    mouseButton = 1;
                    break;
                case MouseButtons.Right:
                    mouseButton = 2;
                    break;
                case MouseButtons.Middle:
                    mouseButton = 3;
                    break;
                default:
                    mouseButton = 4;
                    break;
            }

            this.Invalidate();
        }

        private void FormGoalBar_MouseMove(object sender, MouseEventArgs e)
        {
            Point clientPoint = this.PointToClient(MousePosition);
            mouseX = clientPoint.X;
            mouseY = clientPoint.Y;
            this.mouseMove = true;

            if (this.mouseDown)
            {
                this.Invalidate();
            }
        }

        private void FormGoalBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectedGoal != null)
            {
                if (!timerConfigUpdate.Enabled)
                {
                    timerConfigUpdate.Enabled = true;
                }
            }

            valueChange = false;

            Point clientPoint = this.PointToClient(MousePosition);
            mouseUpX = clientPoint.X;
            mouseUpY = clientPoint.Y;

            this.mouseDown = false;
            this.mouseUp = true;
            this.mouseMove = false;

            this.Invalidate();
        }

        private void FormGoalBar_Activated(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = Program.config.configPath,
                    UseShellExecute = true
                };

                Process.Start(psi);
            }
            catch (Exception ex)
            {
                Program.log.write(ex.Message);
            }
        }

        private void addGoalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Goal goal = new Goal();
            goal.name = "New goal";
            goal.min = 0;
            goal.max = 100;
            goal.value = 50;

            if (selectedGoal != null)
            {
                int index = Program.config.goals.IndexOf(selectedGoal);
                Program.config.goals.Insert(index+1, goal);
            }
            else
            {
                Program.config.goals.Add(goal);
            }

            this.update();
        }

        private void removeGoalToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (selectedGoal != null)
            {
                int index = Program.config.goals.IndexOf(selectedGoal);
                Program.config.goals.RemoveAt(index);
                selectedGoal = null;
                this.update();
            }

        }

        private void changeNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedGoal != null)
            {
                GoalOptions form = new GoalOptions();
                form.SetGoalName(selectedGoal.name);
                form.ShowDialog();
                string newName = form.GetGoalName();
                selectedGoal.name = newName;

                this.update();
            }
        }

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedGoal != null)
            {
                int index = Program.config.goals.IndexOf(selectedGoal);

                int nextVisible = index;
                for (int i = index -1; i >= 0; i--)
                {
                    if (Program.config.goals[i].show)
                    {
                        nextVisible = i;
                        break;
                    }
                }

                if ((0 < index) && (index < Program.config.goals.Count))
                {

                    Program.config.goals.RemoveAt(index);
                    Program.config.goals.Insert(nextVisible, selectedGoal);
                }

                this.update();
            }
        }

        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedGoal != null)
            {
                int index = Program.config.goals.IndexOf(selectedGoal);

                int nextVisible = index;
                for (int i = index+1; i< Program.config.goals.Count; i++) {
                    if (Program.config.goals[i].show) {
                        nextVisible = i;
                        break;
                    }
                }

                if ((-1< index) && (index < Program.config.goals.Count-1)) {
                    
                    Program.config.goals.RemoveAt(index);
                    Program.config.goals.Insert(nextVisible, selectedGoal);
                }

                this.update();
            }
        }
        public void update()
        {
            this.Invalidate(true);

            if (!timerConfigUpdate.Enabled)
            {
                timerConfigUpdate.Enabled = true;
            }
        }
    }
}
