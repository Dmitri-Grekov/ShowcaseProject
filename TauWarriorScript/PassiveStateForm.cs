using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TauWarriorCore.Actions;
using TauWarriorCore.Script;

namespace TauWarriorScript
{
    public partial class PassiveStateForm : Form
    {
        private int index = -1;
        private IAction? action = null;
        public PassiveStateForm()
        {
            InitializeComponent();
            SetUI();
        }
        public void LoadData(int index)
        {
            name.Text = MainForm.Script.PassiveStates[index].Name;
            stateList.SelectedIndex = MainForm.Script.States.FindIndex(x => x.Name == MainForm.Script.PassiveStates[index].NextState);
            action = MainForm.Script.PassiveStates[index].Action;
            statesActionList.Items.Clear();
            statesActionList.Items.Add(MainForm.Script.PassiveStates[index].Action.Info);
            time.Value = (decimal)MainForm.Script.PassiveStates[index].Time.TotalSeconds;
            this.index = index;
        }
        private void SetUI()
        {
            if (MainForm.Script.States.Count != 0)
                stateList.Items.AddRange(MainForm.Script.States.Select(x => x.Name).ToArray());
            else
                stateList.Items.Add("---");
            stateList.SelectedIndex = 0;
            statesActionPick.Items.AddRange(Enum.GetNames(typeof(ActionType)));
            statesActionPick.SelectedIndex = 0;
        }
        private void ok_Click(object sender, EventArgs e)
        {
            if (action != null)
            {
                if (index == -1)
                {
                    MainForm.Script.PassiveStates.Add(new ScriptPassiveState(name.Text, stateList.Items[stateList.SelectedIndex].ToString(), action, TimeSpan.FromSeconds((double)time.Value)));
                }
                else
                {
                    MainForm.Script.PassiveStates[index] = new ScriptPassiveState(name.Text, stateList.Items[stateList.SelectedIndex].ToString(), action, TimeSpan.FromSeconds((double)time.Value));
                }
                Close();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void statesEditAction_Click(object sender, EventArgs e)
        {
            MainForm.OpenForm(MainForm.Script.PassiveStates[index].Action.ActionType, MainForm.Script.PassiveStates[index].Action);
            IAction? temp = MainForm.GetAction();
            if (temp != null)
            {
                action = temp;
                statesActionList.Items.Clear();
                statesActionList.Items.Add(action.Info);
            }
        }

        private void statesSetAction_Click(object sender, EventArgs e)
        {
            MainForm.OpenForm((ActionType)Enum.Parse(typeof(ActionType), statesActionPick.Items[statesActionPick.SelectedIndex].ToString()), null);
            IAction? temp = MainForm.GetAction();
            if (temp != null)
            {
                action = temp;
                statesActionList.Items.Clear();
                statesActionList.Items.Add(action.Info);
            }
        }
    }
}
