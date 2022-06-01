using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TauWarriorCore.Actions;
using TauWarriorCore.Script;

namespace TauWarriorScript
{
    public partial class StateForm : Form
    {
        int index = -1;
        string oldName = "";
        public StateForm()
        {
            InitializeComponent();
            SetUI();
        }
        public void LoadData(int index)
        {
            name.Text = MainForm.Script.States[index].Name;
            oldName = MainForm.Script.States[index].Name;
            stateList.SelectedIndex = MainForm.Script.States.FindIndex(x => x.Name == MainForm.Script.States[index].NextState);
            this.index = index;
        }
        private void SetUI()
        {
            if (MainForm.Script.States.Count != 0)
                stateList.Items.AddRange(MainForm.Script.States.Select(x => x.Name).ToArray());
            else
                stateList.Items.Add("---");
            stateList.SelectedIndex = 0;
        }
        private void ok_Click(object sender, EventArgs e)
        {
            if (index == -1)
            {
                MainForm.Script.States.Add(new ScriptState(name.Text, stateList.Items[stateList.SelectedIndex].ToString(), new List<IAction>()));
            }
            else
            {
                List<IAction> actions = MainForm.Script.States[index].Actions;
                string newName = name.Text;
                MainForm.Script.States[index] = new ScriptState(newName, stateList.Items[stateList.SelectedIndex].ToString(), actions);
                if (oldName != newName)
                {
                    foreach (var s in MainForm.Script.States)
                    {
                        if (s.NextState == oldName)
                            s.NextState = newName;
                    }
                    foreach (var s in MainForm.Script.PassiveStates)
                    {
                        if (s.NextState == oldName)
                            s.NextState = newName;
                    }
                    foreach (var s in MainForm.Script.MouseActions)
                    {
                        if (s.NextState == oldName)
                            s.NextState = newName;
                    }
                    foreach (var s in MainForm.Script.KeyboardActions)
                    {
                        if (s.NextState == oldName)
                            s.NextState = newName;
                    }
                    foreach (var s in MainForm.Script.GamePadActions)
                    {
                        if (s.NextState == oldName)
                            s.NextState = newName;
                    }
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
