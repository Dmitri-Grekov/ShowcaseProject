using System;
using System.Windows.Forms;
using TauWarriorCore.Script;

namespace TauWarriorScript
{
    public partial class ColorForm : Form
    {
        int index = -1;
        public ColorForm()
        {
            InitializeComponent();
        }
        public void LoadData(int index)
        {
            name.Text = MainForm.Script.ScreenColors[index].Name;
            red.Text = MainForm.Script.ScreenColors[index].Color.R.ToString();
            green.Text = MainForm.Script.ScreenColors[index].Color.G.ToString();
            blue.Text = MainForm.Script.ScreenColors[index].Color.B.ToString();
            colorDialog.Color = MainForm.Script.ScreenColors[index].Color;
            this.index = index;
        }
        private void ok_Click(object sender, EventArgs e)
        {
            if (index == -1)
            {
                MainForm.Script.ScreenColors.Add(new ScreenColor(name.Text, colorDialog.Color));
            }
            else
            {
                MainForm.Script.ScreenColors[index] = new ScreenColor(name.Text, colorDialog.Color);
            }
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void colorPick_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                red.Text = colorDialog.Color.R.ToString();
                green.Text = colorDialog.Color.G.ToString();
                blue.Text = colorDialog.Color.B.ToString();
            }
        }
    }
}
