using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GoalBar
{
    public partial class GoalOptions : Form
    {
        public GoalOptions()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GoalOptions_Load(object sender, EventArgs e)
        {

        }

        public void SetGoalName(string name)
        {
            this.textBox1.Text = name;
        }

        public string GetGoalName()
        {
            return this.textBox1.Text;
        }
    }
}
