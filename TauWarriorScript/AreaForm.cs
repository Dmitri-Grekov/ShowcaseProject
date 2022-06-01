using System;
using System.Drawing;
using System.Windows.Forms;
using TauWarriorCore.Script;

namespace TauWarriorScript
{
    public partial class AreaForm : Form
    {
        int index = -1;
        string oldName = "";
        public AreaForm()
        {
            InitializeComponent();
        }
        public void LoadData(int index)
        {
            name.Text = MainForm.Script.ScreenAreas[index].Name;
            x.Value = MainForm.Script.ScreenAreas[index].LeftTop.X;
            y.Value = MainForm.Script.ScreenAreas[index].LeftTop.Y;
            x2.Value = MainForm.Script.ScreenAreas[index].RightBottom.X;
            y2.Value = MainForm.Script.ScreenAreas[index].RightBottom.Y;
            this.index = index;
            oldName = MainForm.Script.ScreenAreas[index].Name;
        }
        private void ok_Click(object sender, EventArgs e)
        {
            if (index == -1)
            {
                MainForm.Script.ScreenAreas.Add(new ScreenArea(name.Text, new Point((int)x.Value, (int)y.Value), new Point((int)x2.Value, (int)y2.Value)));
            }
            else
            {
                MainForm.Script.ScreenAreas[index] = new ScreenArea(name.Text, new Point((int)x.Value, (int)y.Value), new Point((int)x2.Value, (int)y2.Value));
                if (name.Text != oldName)
                {
                    var index = MainForm.Script.ScreenImages.FindIndex(x => x.Name == oldName);
                    if (index != -1)
                        MainForm.Script.ScreenImages[index] = new ScreenImage(name.Text, MainForm.Script.ScreenImages[index].Data);
                }
            }
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
