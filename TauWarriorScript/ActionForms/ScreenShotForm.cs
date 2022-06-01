using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TauWarriorCore;
using TauWarriorCore.Actions;

namespace TauWarriorScript.ActionForms
{
    public partial class ScreenShotForm : Form
    {
        public ScreenShotForm()
        {
            InitializeComponent();
            SetUI();
        }
        public void LoadData(IAction? action)
        {
            if (action != null)
            {
                ScreenShot a = (ScreenShot)action;
                isFullScreen.Checked = a.FullScreen;
                if (isFullScreen.Checked)
                    areaList.Enabled = false;
                if (a.Area != string.Empty)
                    areaList.SelectedIndex = MainForm.Script.ScreenAreas.FindIndex(x => x.Name == a.Area);
                formatList.SelectedIndex = Enum.GetNames(typeof(ImgFormat)).ToList().FindIndex(x => x == a.Format.ToString());
                folder.Text = a.Folder;
                fileName.Text = a.FileName;
                addDate.Checked = a.AddDate;
                addTime.Checked = a.AddTime;
            }
        }
        private void SetUI()
        {
            areaList.Items.Clear();
            areaList.Items.AddRange(MainForm.Script.ScreenAreas.Select(x => $"Name: {x.Name} [{x.LeftTop.X},{x.LeftTop.Y}] -> [{x.RightBottom.X},{x.RightBottom.Y}]").ToArray());
            if (areaList.Items.Count > 0)
                areaList.SelectedIndex = 0;
            formatList.Items.AddRange(Enum.GetNames(typeof(ImgFormat)));
            formatList.SelectedIndex = 0;
        }
        private void ok_Click(object sender, EventArgs e)
        {
            string area = string.Empty;
            if (!isFullScreen.Checked)
                area = MainForm.Script.ScreenAreas[areaList.SelectedIndex].Name;
            MainForm.SetAction(new ScreenShot(folder.Text, fileName.Text, addTime.Checked, addDate.Checked, (ImgFormat)Enum.Parse(typeof(ImgFormat), formatList.Items[formatList.SelectedIndex].ToString()), isFullScreen.Checked, area));
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
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
    }
}
