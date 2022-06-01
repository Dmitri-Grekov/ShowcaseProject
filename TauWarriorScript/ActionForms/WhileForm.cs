using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TauWarriorCore.Actions;

namespace TauWarriorScript.ActionForms
{
    public partial class WhileForm : Form
    {
        List<IAction> Conditions = new List<IAction>();
        List<IAction> Actions = new List<IAction>();
        public WhileForm()
        {
            InitializeComponent();
            SetUI();
        }
        public void LoadData(IAction? action)
        {
            if (action != null)
            {
                While a = (While)action;
                allConditions.Checked = a.AllTrue;
                notTrue.Checked = a.NotTrue;
                Conditions = a.Conditions;
                Actions = a.Actions;
                count.Value = a.Count;
                UpdateUI(-1, -1);
            }
        }
        private void SetUI()
        {
            conditionActionPick.Items.AddRange(MainForm.ActionNames.Select(x => x.Name).ToArray());
            conditionActionPick.SelectedIndex = 0;
            actionPick.Items.AddRange(MainForm.ActionNames.Select(x => x.Name).ToArray());
            actionPick.SelectedIndex = 0;
        }
        private void ok_Click(object sender, EventArgs e)
        {
            MainForm.SetAction(new While(Conditions, Actions, allConditions.Checked, notTrue.Checked, (int)count.Value));
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void UpdateUI(int conditionIndex, int aIndex)
        {
            conditionActionList.Items.Clear();
            conditionActionList.Items.AddRange(Conditions.Select(x => x.Info).ToArray());
            conditionActionList.SelectedIndex = conditionIndex;
            actionList.Items.Clear();
            actionList.Items.AddRange(Actions.Select(x => x.Info).ToArray());
            actionList.SelectedIndex = aIndex;
        }
        private void conditionAddAction_Click(object sender, EventArgs e)
        {
            ActionType actionType = MainForm.ActionNames[conditionActionPick.SelectedIndex].Type;
            MainForm.OpenForm(actionType, null);
            IAction? temp = MainForm.GetAction();
            if (temp != null)
            {
                if (conditionActionList.SelectedIndex != -1)
                    Conditions.Insert(conditionActionList.SelectedIndex + 1, temp);
                else
                    Conditions.Add(temp);
                UpdateUI(conditionActionList.SelectedIndex + 1, actionList.SelectedIndex);
            }
        }

        private void conditionEditAction_Click(object sender, EventArgs e)
        {
            if (conditionActionList.SelectedIndex != -1)
            {
                ActionType actionType = Conditions[conditionActionList.SelectedIndex].ActionType;
                MainForm.OpenForm(actionType, Conditions[conditionActionList.SelectedIndex]);
                IAction? temp = MainForm.GetAction();
                if (temp != null)
                    Conditions[conditionActionList.SelectedIndex] = temp;
                UpdateUI(conditionActionList.SelectedIndex, actionList.SelectedIndex);
            }
        }

        private void conditionRemoveAction_Click(object sender, EventArgs e)
        {
            if (conditionActionList.SelectedIndex != -1)
            {
                int mod = 0;
                foreach (int i in conditionActionList.SelectedIndices)
                {
                    Conditions.RemoveAt(i - mod);
                    mod++;
                }
                UpdateUI(conditionActionList.SelectedIndex - 1, actionList.SelectedIndex);
            }
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
                UpdateUI(conditionActionList.SelectedIndex, actionList.SelectedIndex + 1);
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
                UpdateUI(conditionActionList.SelectedIndex, actionList.SelectedIndex);
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
                UpdateUI(conditionActionList.SelectedIndex, actionList.SelectedIndex - 1);
            }
        }

        private void conditionActionList_DoubleClick(object sender, EventArgs e)
        {
            if (conditionActionList.SelectedIndex != -1)
            {
                ActionType actionType = Conditions[conditionActionList.SelectedIndex].ActionType;
                MainForm.OpenForm(actionType, Conditions[conditionActionList.SelectedIndex]);
                IAction? temp = MainForm.GetAction();
                if (temp != null)
                    Conditions[conditionActionList.SelectedIndex] = temp;
                UpdateUI(conditionActionList.SelectedIndex, actionList.SelectedIndex);
            }
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
                UpdateUI(conditionActionList.SelectedIndex, actionList.SelectedIndex);
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
                    UpdateUI(conditionActionList.SelectedIndex, actionList.SelectedIndex - 1);
                }
            }
        }

        private void conditionUp_Click(object sender, EventArgs e)
        {
            if (conditionActionList.SelectedIndex != -1)
            {
                if (conditionActionList.SelectedIndex > 0)
                {
                    IAction temp = Conditions[conditionActionList.SelectedIndex];
                    Conditions.RemoveAt(conditionActionList.SelectedIndex);
                    Conditions.Insert(conditionActionList.SelectedIndex - 1, temp);
                    UpdateUI(conditionActionList.SelectedIndex - 1, actionList.SelectedIndex);
                }
            }
        }

        private void conditionCopy_Click(object sender, EventArgs e)
        {
            if (conditionActionList.SelectedIndex != -1)
            {
                List<IAction> data = new List<IAction>();
                foreach (int i in conditionActionList.SelectedIndices)
                {
                    data.Add(Conditions[i]);
                }
                Clipboard.SetData("TauWarrior", data);
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

        private void conditionPaste_Click(object sender, EventArgs e)
        {
            List<IAction> data = (List<IAction>)Clipboard.GetData("TauWarrior");
            int mod = 0;
            foreach (var action in data)
            {
                Conditions.Insert(conditionActionList.SelectedIndex + 1 + mod, action);
                mod++;
            }
            UpdateUI(conditionActionList.SelectedIndex, actionList.SelectedIndex);
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
            UpdateUI(conditionActionList.SelectedIndex, actionList.SelectedIndex);
        }
    }
}
