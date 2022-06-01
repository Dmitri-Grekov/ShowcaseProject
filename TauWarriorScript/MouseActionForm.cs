using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TauWarriorCore.Input;
using TauWarriorCore.Script;

namespace TauWarriorScript
{
    public partial class MouseActionForm : Form
    {
        private int index = -1;
        public MouseActionForm()
        {
            InitializeComponent();
            SetUI();
        }
        public void LoadData(int index)
        {
            name.Text = MainForm.Script.MouseActions[index].Name;
            stateList.SelectedIndex = MainForm.Script.States.FindIndex(x => x.Name == MainForm.Script.MouseActions[index].NextState);
            keyList.SelectedIndex = keyList.Items.IndexOf(MainForm.Script.MouseActions[index].Key.ToString());
            holdTime.Value = MainForm.Script.MouseActions[index].HoldTime;
            this.index = index;
        }
        private void SetUI()
        {
            if (MainForm.Script.States.Count != 0)
                stateList.Items.AddRange(MainForm.Script.States.Select(x => x.Name).ToArray());
            else
                stateList.Items.Add("---");
            stateList.SelectedIndex = 0;
            keyList.Items.AddRange(Enum.GetNames(typeof(MouseKeys)));
            keyList.SelectedIndex = 0;
        }
        private void ok_Click(object sender, EventArgs e)
        {
            if (index == -1)
            {
                MainForm.Script.MouseActions.Add(new ScriptMouseAction(name.Text, stateList.Items[stateList.SelectedIndex].ToString(), (MouseKeys)Enum.Parse(typeof(MouseKeys), keyList.Items[keyList.SelectedIndex].ToString()), (long)holdTime.Value));
            }
            else
            {
                MainForm.Script.MouseActions[index] = new ScriptMouseAction(name.Text, stateList.Items[stateList.SelectedIndex].ToString(), (MouseKeys)Enum.Parse(typeof(MouseKeys), keyList.Items[keyList.SelectedIndex].ToString()), (long)holdTime.Value);
            }
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
