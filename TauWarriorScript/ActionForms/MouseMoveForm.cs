using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TauWarriorCore.Actions;
using TauWarriorCore.Input;

namespace TauWarriorScript.ActionForms
{
    public partial class MouseMoveForm : Form
    {
        public MouseMoveForm()
        {
            InitializeComponent();
            SetUI();
        }
        public void LoadData(IAction? action)
        {
            if (action != null)
            {
                MouseMove a = (MouseMove)action;
                dataPointList.SelectedIndex = MainForm.Script.ScreenPoints.FindIndex(x => x.Name == a.Point);
                speedList.SelectedIndex = Enum.GetNames(typeof(MouseSpeed)).ToList().FindIndex(x => x == a.Speed.ToString());
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
        }
        private void ok_Click(object sender, EventArgs e)
        {
            MainForm.SetAction(new MouseMove(MainForm.Script.ScreenPoints[dataPointList.SelectedIndex].Name, (MouseSpeed)Enum.Parse(typeof(MouseSpeed), speedList.Items[speedList.SelectedIndex].ToString())));
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
