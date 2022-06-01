using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TauWarriorCore.Actions;

namespace TauWarriorScript.ActionForms
{
    public partial class ScreenExistsForm : Form
    {
        public ScreenExistsForm()
        {
            InitializeComponent();
            SetUI();
        }
        public void LoadData(IAction? action)
        {
            if (action != null)
            {
                ScreenExists a = (ScreenExists)action;
                isFullScreen.Checked = a.FullScreen;
                if (isFullScreen.Checked)
                    areaList.Enabled = false;
                accuracy.Value = a.Accuracy;
                if (a.Area != string.Empty)
                    areaList.SelectedIndex = MainForm.Script.ScreenAreas.FindIndex(x => x.Name == a.Area);
                if (a.Image != string.Empty)
                {
                    radio1.Checked = true;
                    imageList.SelectedIndex = MainForm.Script.ScreenImages.FindIndex(x => x.Name == a.Image);
                }
                if (a.Color != string.Empty)
                {
                    radio2.Checked = true;
                    colorList.SelectedIndex = MainForm.Script.ScreenColors.FindIndex(x => x.Name == a.Color);
                }
                count.Value = a.Count;
            }
        }
        private void SetUI()
        {
            imageList.Items.Clear();
            imageList.Items.AddRange(MainForm.Script.ScreenImages.Select(x => $"{x.Name}").ToArray());
            areaList.Items.Clear();
            areaList.Items.AddRange(MainForm.Script.ScreenAreas.Select(x => $"Name: {x.Name} [{x.LeftTop.X},{x.LeftTop.Y}] -> [{x.RightBottom.X},{x.RightBottom.Y}]").ToArray());
            if (areaList.Items.Count > 0)
                areaList.SelectedIndex = 0;
            colorList.Items.Clear();
            colorList.Items.AddRange(MainForm.Script.ScreenColors.Select(x => $"Name: {x.Name} [R:{x.Color.R} G:{x.Color.G} B:{x.Color.B}]").ToArray());
            if (colorList.Items.Count > 0)
                colorList.SelectedIndex = 0;
        }
        private void isFullScreen_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckBox();
        }
        private void SetCheckBox()
        {
            if (isFullScreen.Checked)
            {
                areaList.Enabled = false;
            }
            else
            {
                areaList.Enabled = true;
            }
        }

        private void radio1_CheckedChanged(object sender, EventArgs e)
        {
            SetOption();
        }

        private void radio2_CheckedChanged(object sender, EventArgs e)
        {
            SetOption();
        }
        private void SetOption()
        {
            if (radio1.Checked)
            {
                colorList.Enabled = false;
                imageList.Enabled = true;
            }
            if (radio2.Checked)
            {
                colorList.Enabled = true;
                imageList.Enabled = false;
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            string image = string.Empty;
            string color = string.Empty;
            string area = string.Empty;
            if (radio1.Checked)
                image = MainForm.Script.ScreenImages[imageList.SelectedIndex].Name;
            else
                color = MainForm.Script.ScreenColors[colorList.SelectedIndex].Name;
            if (!isFullScreen.Checked)
                area = MainForm.Script.ScreenAreas[areaList.SelectedIndex].Name;
            MainForm.SetAction(new ScreenExists(image, isFullScreen.Checked, radio2.Checked, color, area, (int)count.Value, (int)accuracy.Value));
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
