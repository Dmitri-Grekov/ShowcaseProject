using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TauWarriorCore.Actions;
using TauWarriorCore.Input;

namespace TauWarriorScript.ActionForms
{
    public partial class MouseDragDropForm : Form
    {
        public MouseDragDropForm()
        {
            InitializeComponent();
            SetUI();
        }
        public void LoadData(IAction? action)
        {
            if (action != null)
            {
                MouseDragDrop a = (MouseDragDrop)action;
                firstIsFullScreen.Checked = a.FirstFullScreen;
                secondIsFullScreen.Checked = a.SecondFullScreen;
                if (firstIsFullScreen.Checked)
                    firstAreaList.Enabled = false;
                if (secondIsFullScreen.Checked)
                    secondAreaList.Enabled = false;
                if (a.FirstArea != string.Empty)
                    firstAreaList.SelectedIndex = MainForm.Script.ScreenAreas.FindIndex(x => x.Name == a.FirstArea);
                if (a.SecondArea != string.Empty)
                    secondAreaList.SelectedIndex = MainForm.Script.ScreenAreas.FindIndex(x => x.Name == a.SecondArea);
                if (a.FirstPoint != string.Empty)
                {
                    firstRadio1.Checked = true;
                    firstPointList.SelectedIndex = MainForm.Script.ScreenPoints.FindIndex(x => x.Name == a.FirstPoint);
                }
                if (a.SecondPoint != string.Empty)
                {
                    secondRadio1.Checked = true;
                    secondPointList.SelectedIndex = MainForm.Script.ScreenPoints.FindIndex(x => x.Name == a.SecondPoint);
                }
                if (a.FirstImage != string.Empty)
                {
                    firstRadio2.Checked = true;
                    firstImageList.SelectedIndex = MainForm.Script.ScreenImages.FindIndex(x => x.Name == a.FirstImage);
                }
                if (a.SecondImage != string.Empty)
                {
                    secondRadio2.Checked = true;
                    secondImageList.SelectedIndex = MainForm.Script.ScreenImages.FindIndex(x => x.Name == a.SecondImage);
                }
                firstAccuracy.Value = a.FirstAccuracy;
                secondAccuracy.Value = a.SecondAccuracy;
                speedList.SelectedIndex = Enum.GetNames(typeof(MouseSpeed)).ToList().FindIndex(x => x == a.Speed.ToString());
            }
        }
        private void SetUI()
        {
            firstImageList.Items.Clear();
            firstImageList.Items.AddRange(MainForm.Script.ScreenImages.Select(x => $"{x.Name}").ToArray());
            firstAreaList.Items.Clear();
            firstAreaList.Items.AddRange(MainForm.Script.ScreenAreas.Select(x => $"Name: {x.Name} [{x.LeftTop.X},{x.LeftTop.Y}] -> [{x.RightBottom.X},{x.RightBottom.Y}]").ToArray());
            if (firstAreaList.Items.Count > 0)
                firstAreaList.SelectedIndex = 0;
            firstPointList.Items.Clear();
            firstPointList.Items.AddRange(MainForm.Script.ScreenPoints.Select(x => $"Name: {x.Name} [{x.Point.X},{x.Point.Y}]").ToArray());
            if (firstPointList.Items.Count > 0)
                firstPointList.SelectedIndex = 0;

            secondImageList.Items.Clear();
            secondImageList.Items.AddRange(MainForm.Script.ScreenImages.Select(x => $"{x.Name}").ToArray());
            secondAreaList.Items.Clear();
            secondAreaList.Items.AddRange(MainForm.Script.ScreenAreas.Select(x => $"Name: {x.Name} [{x.LeftTop.X},{x.LeftTop.Y}] -> [{x.RightBottom.X},{x.RightBottom.Y}]").ToArray());
            if (secondAreaList.Items.Count > 0)
                secondAreaList.SelectedIndex = 0;
            secondPointList.Items.Clear();
            secondPointList.Items.AddRange(MainForm.Script.ScreenPoints.Select(x => $"Name: {x.Name} [{x.Point.X},{x.Point.Y}]").ToArray());
            if (secondPointList.Items.Count > 0)
                secondPointList.SelectedIndex = 0;

            speedList.Items.AddRange(Enum.GetNames(typeof(MouseSpeed)));
            speedList.SelectedIndex = 3;
        }
        private void SetFirstCheckBox()
        {
            if (firstIsFullScreen.Checked)
            {
                firstAreaList.Enabled = false;
            }
            else
            {
                firstAreaList.Enabled = true;
            }
        }
        private void SetSecondCheckBox()
        {
            if (secondIsFullScreen.Checked)
            {
                secondAreaList.Enabled = false;
            }
            else
            {
                secondAreaList.Enabled = true;
            }
        }
        private void SetOption()
        {
            if (firstRadio1.Checked)
            {
                firstImageList.Enabled = false;
                firstPointList.Enabled = true;
                firstAccuracy.Enabled = false;
            }
            if (firstRadio2.Checked)
            {
                firstImageList.Enabled = true;
                firstPointList.Enabled = false;
                firstAccuracy.Enabled = true;
            }
            if (secondRadio1.Checked)
            {
                secondImageList.Enabled = false;
                secondPointList.Enabled = true;
                secondAccuracy.Enabled = false;
            }
            if (secondRadio2.Checked)
            {
                secondImageList.Enabled = true;
                secondPointList.Enabled = false;
                secondAccuracy.Enabled = true;
            }
        }
        private void ok_Click(object sender, EventArgs e)
        {
            string firstImage = string.Empty;
            string firstPoint = string.Empty;
            string firstArea = string.Empty;
            string secondImage = string.Empty;
            string secondPoint = string.Empty;
            string secondArea = string.Empty;
            if (firstRadio1.Checked)
            {
                firstPoint = MainForm.Script.ScreenPoints[firstPointList.SelectedIndex].Name;
            }
            else
            {
                firstImage = MainForm.Script.ScreenImages[firstImageList.SelectedIndex].Name;
            }
            if (secondRadio1.Checked)
            {
                secondPoint = MainForm.Script.ScreenPoints[secondPointList.SelectedIndex].Name;
            }
            else
            {
                secondImage = MainForm.Script.ScreenImages[secondImageList.SelectedIndex].Name;
            }
            if (!firstIsFullScreen.Checked)
                firstArea = MainForm.Script.ScreenAreas[firstAreaList.SelectedIndex].Name;
            if (!secondIsFullScreen.Checked)
                secondArea = MainForm.Script.ScreenAreas[secondAreaList.SelectedIndex].Name;
            MainForm.SetAction(new MouseDragDrop(firstIsFullScreen.Checked, secondIsFullScreen.Checked, firstArea, secondArea, firstRadio1.Checked, secondRadio1.Checked, firstPoint, secondPoint, firstImage, secondImage, (int)firstAccuracy.Value, (int)secondAccuracy.Value, (MouseSpeed)Enum.Parse(typeof(MouseSpeed), speedList.Items[speedList.SelectedIndex].ToString())));
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void firstIsFullScreen_CheckedChanged(object sender, EventArgs e)
        {
            SetFirstCheckBox();
        }

        private void secondIsFullScreen_CheckedChanged(object sender, EventArgs e)
        {
            SetSecondCheckBox();
        }

        private void firstRadio1_CheckedChanged(object sender, EventArgs e)
        {
            SetOption();
        }

        private void firstRadio2_CheckedChanged(object sender, EventArgs e)
        {
            SetOption();
        }

        private void secondRadio1_CheckedChanged(object sender, EventArgs e)
        {
            SetOption();
        }

        private void secondRadio2_CheckedChanged(object sender, EventArgs e)
        {
            SetOption();
        }
    }
}
