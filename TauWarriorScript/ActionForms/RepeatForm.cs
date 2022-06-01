using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TauWarriorCore.Actions;

namespace TauWarriorScript.ActionForms
{
    public partial class RepeatForm : Form
    {
        List<IAction> Actions = new List<IAction>();
        public RepeatForm()
        {
            InitializeComponent();
            SetUI();
        }
        public void LoadData(IAction? action)
        {
            if (action != null)
            {
                Repeat a = (Repeat)action;
                Actions = a.Actions;
                count.Value = a.Count;
                UpdateUI(-1);
            }
        }
        private void UpdateUI(int aIndex)
        {
            actionList.Items.Clear();
            actionList.Items.AddRange(Actions.Select(x => x.Info).ToArray());
            actionList.SelectedIndex = aIndex;
        }
        private void SetUI()
        {
            actionPick.Items.AddRange(MainForm.ActionNames.Select(x => x.Name).ToArray());
            actionPick.SelectedIndex = 0;
        }
        private void addAction_Click(object sender, EventArgs e)
        {
            ActionType actionType = MainForm.ActionNames[actionPick.SelectedIndex].Type;
            MainForm.OpenForm(actionType, null);
            IAction? temp = MainForm.GetAction();
            if (temp != null)
            {
                if (actionList.SelectedIndex != -1)
                    Actions.Insert(actionList.SelectedIndex + 1, temp);
                else
                    Actions.Add(temp);
                UpdateUI(actionList.SelectedIndex + 1);
            }
        }

        private void editAction_Click(object sender, EventArgs e)
        {
            if (actionList.SelectedIndex != -1)
            {
                ActionType actionType = Actions[actionList.SelectedIndex].ActionType;
                MainForm.OpenForm(actionType, Actions[actionList.SelectedIndex]);
                IAction? temp = MainForm.GetAction();
                if (temp != null)
                    Actions[actionList.SelectedIndex] = temp;
                UpdateUI(actionList.SelectedIndex);
            }
        }

        private void removeAction_Click(object sender, EventArgs e)
        {
            if (actionList.SelectedIndex != -1)
            {
                int mod = 0;
                foreach (int i in actionList.SelectedIndices)
                {
                    Actions.RemoveAt(i - mod);
                    mod++;
                }
                UpdateUI(actionList.SelectedIndex - 1);
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            MainForm.SetAction(new Repeat(Actions, (int)count.Value));
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void actionList_DoubleClick(object sender, EventArgs e)
        {
            if (actionList.SelectedIndex != -1)
            {
                ActionType actionType = Actions[actionList.SelectedIndex].ActionType;
                MainForm.OpenForm(actionType, Actions[actionList.SelectedIndex]);
                IAction? temp = MainForm.GetAction();
                if (temp != null)
                    Actions[actionList.SelectedIndex] = temp;
                UpdateUI(actionList.SelectedIndex);
            }
        }

        private void actionUp_Click(object sender, EventArgs e)
        {
            if (actionList.SelectedIndex != -1)
            {
                if (actionList.SelectedIndex > 0)
                {
                    IAction temp = Actions[actionList.SelectedIndex];
                    Actions.RemoveAt(actionList.SelectedIndex);
                    Actions.Insert(actionList.SelectedIndex - 1, temp);
                    UpdateUI(actionList.SelectedIndex - 1);
                }
            }
        }

        private void actionCopy_Click(object sender, EventArgs e)
        {
            if (actionList.SelectedIndex != -1)
            {
                List<IAction> data = new List<IAction>();
                foreach (int i in actionList.SelectedIndices)
                {
                    data.Add(Actions[i]);
                }
                Clipboard.SetData("TauWarrior", data);
            }
        }

        private void actionPaste_Click(object sender, EventArgs e)
        {
            List<IAction> data = (List<IAction>)Clipboard.GetData("TauWarrior");
            int mod = 0;
            foreach (var action in data)
            {
                Actions.Insert(actionList.SelectedIndex + 1 + mod, action);
                mod++;
            }
            UpdateUI(actionList.SelectedIndex);
        }
    }
}
