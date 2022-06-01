using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TauWarriorCore.Actions;
using TauWarriorCore.Input;

namespace TauWarriorScript.ActionForms
{
    public partial class MouseClickForm : Form
    {
        public MouseClickForm()
        {
            InitializeComponent();
            SetUI();
        }
        public void LoadData(IAction? action)
        {
            if (action != null)
            {
                MouseClick a = (MouseClick)action;
                usePoint.Checked = a.UsePoint;
                if (usePoint.Checked)
                {
                    dataPointList.SelectedIndex = MainForm.Script.ScreenPoints.FindIndex(x => x.Name == a.Point);
                    speedList.SelectedIndex = Enum.GetNames(typeof(MouseSpeed)).ToList().FindIndex(x => x == a.Speed.ToString());
                }
                keyList.SelectedIndex = Enum.GetNames(typeof(MouseKeys)).ToList().FindIndex(x => x == a.Key.ToString());
                holdTime.Value = a.HoldTime;
                count.Value = a.Count;
            }
        }
        private void SetUI()
        {
            dataPointList.Items.Clear();
            dataPointList.Items.AddRange(MainForm.Script.ScreenPoints.Select(x => $"Name: {x.Name} [{x.Point.X},{x.Point.Y}]").ToArray());
            if (dataPointList.Items.Count > 0)
                dataPointList.SelectedIndex = 0;
            speedList.Items.AddRange(Enum.GetNames(typeof(MouseSpeed)));
            speedList.SelectedIndex = 3;
            keyList.Items.AddRange(Enum.GetNames(typeof(MouseKeys)));
            keyList.SelectedIndex = 0;
        }
        private void ok_Click(object sender, EventArgs e)
        {
            if (usePoint.Checked)
                MainForm.SetAction(new MouseClick(usePoint.Checked, MainForm.Script.ScreenPoints[dataPointList.SelectedIndex].Name, (MouseSpeed)Enum.Parse(typeof(MouseSpeed), speedList.Items[speedList.SelectedIndex].ToString()), (MouseKeys)Enum.Parse(typeof(MouseKeys), keyList.Items[keyList.SelectedIndex].ToString()), (int)holdTime.Value, (int)count.Value));
            else
                MainForm.SetAction(new MouseClick(usePoint.Checked, "", MouseSpeed.Normal, (MouseKeys)Enum.Parse(typeof(MouseKeys), keyList.Items[keyList.SelectedIndex].ToString()), (int)holdTime.Value, (int)count.Value));
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void usePoint_CheckedChanged(object sender, EventArgs e)
        {
            if (usePoint.Checked)
            {
                dataPointList.Enabled = true;
                speedList.Enabled = true;
            }
            else
            {
                dataPointList.Enabled = false;
                speedList.Enabled = false;
            }
        }
    }
}
