using System;
using System.Drawing;
using System.Windows.Forms;
using TauWarriorCore.Script;

namespace TauWarriorScript
{
    public partial class PointForm : Form
    {
        private int index = -1;
        public PointForm()
        {
            InitializeComponent();
        }
        public void LoadData(int index)
        {
            name.Text = MainForm.Script.ScreenPoints[index].Name;
            x.Value = MainForm.Script.ScreenPoints[index].Point.X;
            y.Value = MainForm.Script.ScreenPoints[index].Point.Y;
            this.index = index;
        }
        private void ok_Click(object sender, EventArgs e)
        {
            if (index == -1)
            {
                MainForm.Script.ScreenPoints.Add(new ScreenPoint(name.Text, new Point((int)x.Value, (int)y.Value)));
            }
            else
            {
                MainForm.Script.ScreenPoints[index] = new ScreenPoint(name.Text, new Point((int)x.Value, (int)y.Value));
            }
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
