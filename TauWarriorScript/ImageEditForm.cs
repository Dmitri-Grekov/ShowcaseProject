using System;
using System.Windows.Forms;
using TauWarriorCore.Script;

namespace TauWarriorScript
{
    public partial class ImageEditForm : Form
    {
        int index = -1;
        string oldName = "";
        public ImageEditForm()
        {
            InitializeComponent();
        }
        public void LoadData(int index)
        {
            name.Text = MainForm.Script.ScreenImages[index].Name;
            this.index = index;
            oldName = MainForm.Script.ScreenImages[index].Name;
        }
        private void ok_Click(object sender, EventArgs e)
        {
            MainForm.Script.ScreenImages[index] = new TauWarriorCore.Script.ScreenImage(name.Text, MainForm.Script.ScreenImages[index].Data);
            if (name.Text != oldName)
            {
                var index = MainForm.Script.ScreenAreas.FindIndex(x => x.Name == oldName);
                if (index != -1)
                    MainForm.Script.ScreenAreas[index] = new ScreenArea(name.Text, MainForm.Script.ScreenAreas[index].LeftTop, MainForm.Script.ScreenAreas[index].RightBottom);
            }
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
