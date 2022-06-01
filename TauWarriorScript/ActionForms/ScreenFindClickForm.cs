using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TauWarriorCore.Actions;
using TauWarriorCore.Input;

namespace TauWarriorScript.ActionForms
{
    public partial class ScreenFindClickForm : Form
    {
        public ScreenFindClickForm()
        {
            InitializeComponent();
            SetUI();
        }
        public void LoadData(IAction? action)
        {
            if (action != null)
            {
                ScreenFindClick a = (ScreenFindClick)action;
                isFullScreen.Checked = a.FullScreen;
                if (isFullScreen.Checked)
                    areaList.Enabled = false;
                if (a.First)
                    option2.Checked = a.First;
                else if (a.Closest)
                    option3.Checked = a.Closest;
                else
                    option1.Checked = true;
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
                speedList.SelectedIndex = Enum.GetNames(typeof(MouseSpeed)).ToList().FindIndex(x => x == a.Speed.ToString());
                keyList.SelectedIndex = Enum.GetNames(typeof(MouseKeys)).ToList().FindIndex(x => x == a.Key.ToString());
                holdTime.Value = a.HoldTime;
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
            speedList.Items.AddRange(Enum.GetNames(typeof(MouseSpeed)));
            speedList.SelectedIndex = 3;
            keyList.Items.AddRange(Enum.GetNames(typeof(MouseKeys)));
            keyList.SelectedIndex = 0;
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
        private void option1_CheckedChanged(object sender, EventArgs e)
        {
            SetOption();
        }
        private void option2_CheckedChanged(object sender, EventArgs e)
        {
            SetOption();
        }
        private void option3_CheckedChanged(object sender, EventArgs e)
        {
            SetOption();
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
            if (option1.Checked)
            {
                if (radio1.Checked)
                {
                    colorList.Enabled = false;
                    imageList.Enabled = true;
                    radio2.Enabled = false;
                }
                if (radio2.Checked)
                {
                    colorList.Enabled = false;
                    imageList.Enabled = true;
                    radio1.Checked = true;
                    radio2.Enabled = false;
                }
            }
            if (option2.Checked)
            {
                if (radio1.Checked)
                {
                    colorList.Enabled = false;
                    imageList.Enabled = true;
                    radio2.Enabled = true;
                }
                if (radio2.Checked)
                {
                    colorList.Enabled = true;
                    imageList.Enabled = false;
                }
            }
            if (option3.Checked)
            {
                if (radio1.Checked)
                {
                    colorList.Enabled = false;
                    imageList.Enabled = true;
                    radio2.Enabled = true;
                }
                if (radio2.Checked)
                {
                    colorList.Enabled = true;
                    imageList.Enabled = false;
                }
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
            if(!isFullScreen.Checked)
                area = MainForm.Script.ScreenAreas[areaList.SelectedIndex].Name;
            MainForm.SetAction(new ScreenFindClick(image, isFullScreen.Checked, option2.Checked, option3.Checked, radio2.Checked, area, (MouseSpeed)Enum.Parse(typeof(MouseSpeed), speedList.Items[speedList.SelectedIndex].ToString()), (MouseKeys)Enum.Parse(typeof(MouseKeys), keyList.Items[keyList.SelectedIndex].ToString()), (int)holdTime.Value, (int)count.Value, color, (int)accuracy.Value));
            Close();
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
